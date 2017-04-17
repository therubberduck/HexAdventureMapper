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

        private DbInterface _db;

        private HexCoordinate _partyLocation;

        public PartyLayerDrawer(IDrawingUi drawingUi, DbInterface db)
        {
            _drawingUi = drawingUi;
            _db = db;

            Party party = _db.Party.Get();
            if (party != null)
            {
                _partyLocation = party.Location;
            }
            
        }

        public void UpdatePartyLocation(HexCoordinate partyLocation)
        {
            _partyLocation = partyLocation;
            _db.Party.UpdateLocation(partyLocation);

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
