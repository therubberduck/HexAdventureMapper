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
        private IDrawingUi _uiInterface;
        private readonly TileCache _tileCache;

        public HexMapFactory(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db, TileCache tileCache)
        {
            _tileCache = tileCache;
            HexTileFactory = new HexTileFactory(uiInterface, tiles, _tileCache);
            _uiInterface = uiInterface;
            _db = db;
        }

        public Image MakeLocalMap()
        {
            var hexes = _db.Hexes.GetArea(_uiInterface.GetMapBox().MapArea);
            return MakeMapFromEntireArea(hexes);
        }

        public Image RedrawFogOfWar()
        {
            var hexes = _db.Hexes.GetArea(_uiInterface.GetMapBox().MapArea);
            return MakeMapFromEntireArea(hexes, Layer.FogOfWar);
        }

        public Image MakeMapFromEntireArea(List<Hex> hexes, Layer layer = Layer.Finished)
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
                    DrawHex(graphics, hex, layer);
                }

                TryDrawSelectedCoordinate(graphics);
                TryDrawPartyPosition(graphics);
            }
            return map;
        }

        public Image RedrawArea(HexCoordinate centerCoordinate, Image image)
        {
            List<HexCoordinate> areaCoordinates = PositionManager.GetTwoStepAreaAround(centerCoordinate);
            List<Hex> hexesInArea = _db.Hexes.GetForCoordinates(areaCoordinates);
            foreach (var hex in hexesInArea)
            {
                image = RedrawHex(hex.Coordinate, image);
            }
            return image;
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

                DrawHex(graphics, hex, Layer.Terrain);

                TryDrawSelectedCoordinate(graphics);
                TryDrawPartyPosition(graphics);
            }
            return map;
        }

        private void DrawHex(Graphics graphics, Hex hex, Layer layer = Layer.Finished)
        {
            HexCoordinate positionOnVisibleMap = hex.Coordinate.Minus(_uiInterface.GetMapBox().TopLeftCoordinate);
            Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
            var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));
            
            Image image = HexTileFactory.GenerateMapTile(hex, layer);
            graphics.DrawImage(image, pictureLocationAndSize);
        }

        private void TryDrawSelectedCoordinate(Graphics graphics)
        {
            HexCoordinate selectedCoordinate = _uiInterface.GetSelectedCoordinate();
            if (selectedCoordinate != null)
            {
                HexCoordinate positionOnVisibleMap = selectedCoordinate.Minus(_uiInterface.GetMapBox().TopLeftCoordinate);
                Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
                var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

                using (var selectImage = Image.FromFile("Images/SelectBorder.png"))
                {
                    graphics.DrawImage(selectImage, pictureLocationAndSize);
                }
            }
        }

        private void TryDrawPartyPosition(Graphics graphics)
        {
            HexCoordinate partyPosition = _uiInterface.GetPartyPosition();
            if (partyPosition != null)
            {
                Point positionOnScreen = PositionManager.HexToScreen(partyPosition);
                var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

                using (var selectImage = Image.FromFile("Images/PartyIndicator.png"))
                {
                    graphics.DrawImage(selectImage, pictureLocationAndSize);
                }
            }
        }
    }
}
