﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Visualizer
{
    public class PlayerIconLayerDrawer : BaseLayerDrawer
    {
        public PlayerIconLayerDrawer(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db) : base(uiInterface, tiles, db)
        {
        }

        public override Layer GetLayerType()
        {
            return Layer.PlayerIcon;
        }

        protected override void DrawHex(Graphics graphics, Hex hex, int alpha = 100)
        {
            HexCoordinate positionOnVisibleMap = hex.Coordinate.Minus(_uiInterface.GetMapBox().TopLeftCoordinate);
            Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
            positionOnScreen.Offset(TileConfigInterface.HexWidth / 4, TileConfigInterface.HexHeight / 4);
            var size = new Size(TileConfigInterface.HexWidth / 2, TileConfigInterface.HexHeight / 2);

            var pictureLocationAndSize = new Rectangle(positionOnScreen, size);

            var iconImageLocation = _tiles.GetIcon(hex.PlayerIcons[0]).ImageLocation;
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