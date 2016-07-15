using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Visualizer.LayerDrawers
{
    public class GmIconLayerDrawer : BaseLayerDrawer
    {
        public GmIconLayerDrawer(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db) : base(uiInterface, tiles, db)
        {
        }

        public override Layer GetLayerType()
        {
            return Layer.GmIcon;
        }

        protected override void DrawHex(Graphics graphics, Hex hex, int alpha = 100)
        {
            //Change composite mode so that previous image in that hex gets overwritten, ignoring transparency
            graphics.CompositingMode = CompositingMode.SourceCopy;

            HexCoordinate positionOnVisibleMap = hex.Coordinate.Minus(UiInterface.GetMapBox().TopLeftCoordinate);
            Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
            positionOnScreen.Offset(TileConfigInterface.HexWidth/4, TileConfigInterface.HexHeight/4);
            var size = new Size(TileConfigInterface.HexWidth/2, TileConfigInterface.HexHeight/2);

            var pictureLocationAndSize = new Rectangle(positionOnScreen, size);
            
            var iconImageLocation = Tiles.GetIcon(hex.Icons[0]).ImageLocation;
            using (var image = Image.FromFile(iconImageLocation))
            {
                if (alpha == 100)
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
                else
                {
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = alpha / 100.0f;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    graphics.DrawImage(image, pictureLocationAndSize, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
            }
        }
    }
}
