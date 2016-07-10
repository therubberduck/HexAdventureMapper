using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;

namespace HexAdventureMapper.Visualizer
{
    public abstract class BaseLayerDrawer
    {
        protected readonly DbInterface _db;
        protected readonly IDrawingUi _uiInterface;
        protected readonly TileConfigInterface _tiles;

        public BaseLayerDrawer(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db)
        {
            _uiInterface = uiInterface;
            _tiles = tiles;
            _db = db;
        }

        public abstract Layer GetLayerType();

        public Image MakeLocalMap(int alpha)
        {
            var hexes = _db.Hexes.GetArea(_uiInterface.GetMapBox().MapArea);
            return MakeMapFromEntireArea(hexes, alpha);
        }

        public Image MakeMapFromEntireArea(List<Hex> hexes, int alpha)
        {
            MapBox mapBox = _uiInterface.GetMapBox();
            if (mapBox.Width == 0 || mapBox.Height == 0)
            {
                return null;
            }
            var map = new Bitmap(mapBox.Width, mapBox.Height);
            using (Graphics graphics = Graphics.FromImage(map))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                foreach (var hex in hexes)
                {
                    DrawHex(graphics, hex, alpha);
                }
            }
            return map;
        }

        public Image RedrawArea(HexCoordinate centerCoordinate, Image image, int alpha)
        {
            List<HexCoordinate> areaCoordinates = DirectionManager.GetTwoStepAreaAround(centerCoordinate);
            List<Hex> hexesInArea = _db.Hexes.GetForCoordinates(areaCoordinates);
            hexesInArea.ForEach(h => RedrawHex(h.Coordinate, image, alpha));
            return image;
        }

        public Image RedrawHex(HexCoordinate worldCoordinate, Image map, int alpha)
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

                DrawHex(graphics, hex, alpha);
            }
            return map;
        }

        protected abstract void DrawHex(Graphics graphics, Hex hex, int alpha);
    }
}
