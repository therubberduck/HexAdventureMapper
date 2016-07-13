using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;

namespace HexAdventureMapper.Visualizer
{
    public class OverlayGridLayerDrawer
    {
        private IDrawingUi _drawingUi;

        public OverlayGridLayerDrawer(IDrawingUi drawingUi)
        {
            _drawingUi = drawingUi;
        }

        public Image DrawOverlay()
        {
            MapBox mapBox = _drawingUi.GetMapBox();

            Bitmap image = new Bitmap(mapBox.Width, mapBox.Height);

            //If there should be no grid, we return an empty image
            if (_drawingUi.GetOverlayGridAlpha() == 0)
            {
                return image;
            }

            Image overlayImage = Image.FromFile("Images/drawingguide.png");

            using (var graphics = Graphics.FromImage(image))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                int col = (int)((mapBox.TopLeftCoordinate.X / 3 ) % 2);

                HexCoordinate tlCoordinate = mapBox.TopLeftCoordinate;
                int x;
                if (tlCoordinate.X >= 0)
                {
                     x = 37 - 37 * (int)Math.Abs(tlCoordinate.X % 6);
                }
                else
                {
                    x = 37 - 37 * (int)Math.Abs(6 + (tlCoordinate.X % 6));
                }

                int y;
                if (tlCoordinate.Y >= 0)
                {
                    y = 22 - 44 * (int) Math.Abs(tlCoordinate.Y % 3) - col * 66;
                }
                else
                {
                    y = 22 - 44 * (int)Math.Abs(3 + tlCoordinate.Y % 3) - col * 66;
                }


                if (x > 0)
                {
                    x -= 111;
                    y -= 66;
                }

                if (y > 0)
                {
                    y -= 132;
                }
                else if (y < 132)
                {
                    y += 132;
                }

                int staticY = y;

                while (x < mapBox.Width)
                {
                    while (y < mapBox.Height)
                    {
                        var pictureLocationAndSize = new Rectangle(x, y, 112, 132);
                        graphics.DrawImage(overlayImage, pictureLocationAndSize);

                        y += 132;
                    }
                    x += 111;
                    col += 1;
                    if (col % 2 == 0)
                    {
                        y = staticY;
                    }
                    else
                    {
                        y = staticY - 66;
                    }
                }
            }

            return image;
        }
    }
}
