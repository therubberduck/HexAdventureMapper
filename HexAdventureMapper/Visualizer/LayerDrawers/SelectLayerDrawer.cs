using System.Drawing;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Visualizer.LayerDrawers
{
   public class SelectLayerDrawer : BaseLayerDrawer
    {
       public SelectLayerDrawer(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db) : base(uiInterface, tiles, db)
       {
       }

       public override Layer GetLayerType()
       {
           return Layer.Selection;
       }

       protected override void DrawHex(Graphics graphics, Hex hex, int alpha)
       {
            HexCoordinate selectedCoordinate = hex.Coordinate;
            if (selectedCoordinate != null)
            {
                HexCoordinate positionOnVisibleMap = selectedCoordinate.Minus(UiInterface.GetMapBox().TopLeftCoordinate);
                Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
                var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

                using (var selectImage = Image.FromFile("Images/SelectBorder.png"))
                {
                    graphics.DrawImage(selectImage, pictureLocationAndSize);
                }
            }
        }
    }
}
