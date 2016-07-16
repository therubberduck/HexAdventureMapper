using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;

namespace HexAdventureMapper.Visualizer.LayerDrawers
{
    public class PartyLayerDrawer
    {
        private IDrawingUi _drawingUi;

        private HexCoordinate _partyLocation;

        public PartyLayerDrawer(IDrawingUi drawingUi)
        {
            _drawingUi = drawingUi;
            _partyLocation = new HexCoordinate(Properties.Settings.Default.PartyLocation);
        }

        public void UpdatePartyLocation(HexCoordinate partyLocation)
        {
            _partyLocation = partyLocation;
            Properties.Settings.Default.PartyLocation = new Point((int) _partyLocation.X, (int) _partyLocation.Y);

            RedrawPartyLocation();
        }

        public void RedrawPartyLocation()
        {
            MapBox mapBox = _drawingUi.GetMapBox();
            
            if (mapBox.Width > 0 && mapBox.Height > 0)
            {
                Bitmap map = new Bitmap(mapBox.Width, mapBox.Height);

                using (Graphics graphics = Graphics.FromImage(map))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    if (_partyLocation != null)
                    {
                        Point positionOnScreen = PositionManager.HexToScreen(_partyLocation, mapBox.TopLeftCoordinate);
                        var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

                        using (var selectImage = Image.FromFile("Images/PartyIndicator.png"))
                        {
                            graphics.DrawImage(selectImage, pictureLocationAndSize);
                        }
                    }
                }

                mapBox.UpdateLayerAndMap(Layer.PartyLocation, map);
            }
        }
    }
}
