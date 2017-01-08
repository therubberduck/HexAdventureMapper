using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;

namespace HexAdventureMapper.Visualizer
{
    public abstract class BaseLayerDrawer
    {
        protected readonly DbInterface Db;
        protected readonly IDrawingUi UiInterface;
        protected readonly TileConfigInterface Tiles;

        protected BaseLayerDrawer(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db)
        {
            UiInterface = uiInterface;
            Tiles = tiles;
            Db = db;
        }

        public abstract Layer GetLayerType();

        public Image MakeLocalMap(string handlerTag, int alpha, bool useCache = true)
        {
            var hexes = Db.Hexes.GetArea(handlerTag, UiInterface.GetMapBox().MapArea, useCache);
            return MakeMapFromEntireArea(hexes, alpha);
        }

        public Image MakeMapFromEntireArea(List<Hex> hexes, int alpha)
        {
            MapBox mapBox = UiInterface.GetMapBox();
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
            List<Hex> hexesInArea = Db.Hexes.GetForCoordinates(areaCoordinates);
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

                var hex = Db.Hexes.GetForCoordinate(worldCoordinate);

                if (hex == null)
                {
                    return map;
                }

                DrawHex(graphics, hex, alpha);
            }
            return map;
        }

        protected abstract void DrawHex(Graphics graphics, Hex hex, int alpha);
    }
}
