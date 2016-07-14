using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Visualizer.LayerDrawers
{
    public class TerrainLayerDrawer : BaseLayerDrawer
    {
        private readonly Dictionary<String, Bitmap> _mapTileImages;

        public TerrainLayerDrawer(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db) : base(uiInterface, tiles, db)
        {
            _mapTileImages = new Dictionary<string, Bitmap>();
        }

        public override Layer GetLayerType()
        {
            return Layer.Terrain;
        }

        protected override void DrawHex(Graphics graphics, Hex hex, int alpha = 100)
        {
            HexCoordinate positionOnVisibleMap = hex.Coordinate.Minus(UiInterface.GetMapBox().TopLeftCoordinate);
            Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
            var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(TileConfigInterface.HexWidth, TileConfigInterface.HexHeight));

            var tileMarker = hex.TerrainId + "|" + hex.VegetationId;
            if (_mapTileImages.ContainsKey(tileMarker))
            {
                graphics.DrawImage(_mapTileImages[tileMarker], pictureLocationAndSize);
            }
            else
            {
                Image terrainTile = CreateTerrainImage(hex);
                _mapTileImages[tileMarker] = terrainTile as Bitmap;
                graphics.DrawImage(terrainTile, pictureLocationAndSize);
            }
        }

        private Image CreateTerrainImage(Hex hex)
        {
            Bitmap tileImage = new Bitmap(TileConfigInterface.HexWidth, TileConfigInterface.HexHeight);
            var pictureLocationAndSize = new Rectangle(0, 0, TileConfigInterface.HexWidth, TileConfigInterface.HexHeight);

            using (var graphics = Graphics.FromImage(tileImage))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                string elevationImageString;
                if (hex.TerrainId == 1)
                {
                    elevationImageString = "Images/Elevation0.png";
                }
                else if (hex.TerrainId == 2)
                {
                    elevationImageString = "Images/Elevation1000.png";
                }
                else if (hex.TerrainId == 3)
                {
                    elevationImageString = "Images/Elevation17600.png";
                }
                else
                {
                    elevationImageString = "Images/Elevation200.png";
                }
                using (var image = Image.FromFile(elevationImageString))
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
                var terrainImageLocation = Tiles.GetTerrain(hex.TerrainId).ImageLocation;
                using (var image = Image.FromFile(terrainImageLocation))
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
                var vegetationImageLocation = Tiles.GetVegetation(hex.VegetationId).ImageLocation;
                using (var image = Image.FromFile(vegetationImageLocation))
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
            }
            return tileImage;
        }
    }
}
