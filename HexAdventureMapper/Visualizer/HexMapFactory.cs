using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Painting;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;

namespace HexAdventureMapper.Visualizer
{
    public class HexMapFactory
    {
        public HexTileFactory HexTileFactory;
        private DbInterface _db;
        private MapBox _mapBox;

        public HexCoordinate SelectedCoordinate { get; set; }

        public HexMapFactory(IPainterUi uiInterface, TileConfigInterface tiles, DbInterface db, MapBox mapBox)
        {
            HexTileFactory = new HexTileFactory(uiInterface, tiles);
            _db = db;
            _mapBox = mapBox;
        }

        public Image MakeLocalMap()
        {
            var hexes = _db.Hexes.GetArea(_mapBox.MapArea);
            return MakeMapFromEntireArea(hexes);
        }

        public Image MakeMapFromEntireArea(List<Hex> hexes)
        {
            if (_mapBox.Width == 0 || _mapBox.Height == 0)
            {
                return null;
            }
            var map = new Bitmap(_mapBox.Width, _mapBox.Height);
            using (Graphics graphics = Graphics.FromImage(map))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                foreach (var hex in hexes)
                {
                    HexCoordinate positionOnVisibleMap = hex.Coordinate.Minus(_mapBox.TopLeftCoordinate);
                    Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
                    var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

                    Image image = HexTileFactory.GetMapTileFor(hex);
                    graphics.DrawImage(image, pictureLocationAndSize);
                }

                if (SelectedCoordinate != null)
                {
                    HexCoordinate positionOnVisibleMap = SelectedCoordinate.Minus(_mapBox.TopLeftCoordinate);
                    Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
                    var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

                    using (var image = Image.FromFile("Images/SelectBorder.png"))
                    {
                        graphics.DrawImage(image, pictureLocationAndSize);
                    }
                }

            }
            return map;
        }

        public Image RedrawHex(HexCoordinate worldCoordinate, Image map)
        {
            using (Graphics graphics = Graphics.FromImage(map))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var hex = _db.Hexes.GetForCoordinate(worldCoordinate);

                if (hex == null)
                {
                    return null;
                }

                HexCoordinate positionOnVisibleMap = hex.Coordinate.Minus(_mapBox.TopLeftCoordinate);
                Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
                var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

                Image image = HexTileFactory.GetMapTileFor(hex);
                graphics.DrawImage(image, pictureLocationAndSize);

                if (SelectedCoordinate != null)
                {
                    positionOnVisibleMap = SelectedCoordinate.Minus(_mapBox.TopLeftCoordinate);
                    positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
                    pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

                    using (var selectImage = Image.FromFile("Images/SelectBorder.png"))
                    {
                        graphics.DrawImage(selectImage, pictureLocationAndSize);
                    }
                }
            }
            return map;
        }
    }
}
