﻿using System.Drawing;
using System.Drawing.Imaging;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Visualizer.LayerDrawers
{
    public class FogOfWarLayerDrawer : BaseLayerDrawer
    {
        public FogOfWarLayerDrawer(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db) : base(uiInterface, tiles, db)
        {
        }

        public override Layer GetLayerType()
        {
            return Layer.FogOfWar;
        }

        protected override void DrawHex(Graphics graphics, Hex hex, int alpha = 100)
        {
            HexCoordinate positionOnVisibleMap = hex.Coordinate.Minus(UiInterface.GetMapBox().TopLeftCoordinate);
            Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
            positionOnScreen.Offset(-1, -1);
            var size = new Size(TileConfigInterface.HexWidth + 2, TileConfigInterface.HexHeight + 2);

            var pictureLocationAndSize = new Rectangle(positionOnScreen, size);

            int typeAlpha = 100;
            if (hex.FogOfWar == 1) //Draw partially transparent fog of war
            {
                typeAlpha = 50;
            }
            else if (hex.FogOfWar == 2) //Don't draw any fog of war
            {
                return;
            }

            float dAlpha = (typeAlpha / 100.0f) * (alpha / 100.0f);

            var iconImageLocation = "Images/FogOfWar.png";
            using (var image = Tiles.GetImage(iconImageLocation))
            {
                if (typeAlpha == 100 && alpha == 100)
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
                else
                {
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = dAlpha;

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
