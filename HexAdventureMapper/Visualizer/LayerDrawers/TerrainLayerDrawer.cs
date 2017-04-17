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
            if (!_mapTileImages.ContainsKey(tileMarker))
            {
                Image terrainTile = CreateTerrainImage(hex);
                _mapTileImages[tileMarker] = terrainTile as Bitmap;
            }
            graphics.DrawImage((Bitmap)_mapTileImages[tileMarker].Clone(), pictureLocationAndSize);
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
                if (hex.TerrainId == TileId.TerrainSea)
                {
                    elevationImageString = "Images/BSea.png";
                }
                else if (hex.VegetationId == TileId.VegDesert)
                {
                    elevationImageString = "Images/BDesert.png";
                }
                else if (hex.TerrainId == TileId.TerrainHills)
                {
                    elevationImageString = "Images/BHills.png";
                }
                else if (hex.TerrainId == TileId.TerrainMountains)
                {
                    elevationImageString = "Images/BMountains.png";
                }
                else if (hex.TerrainId == TileId.TerrainSolidRock || hex.TerrainId == TileId.TerrainTunnels || hex.TerrainId == TileId.TerrainSmallCave || hex.TerrainId == TileId.StrCave)
                {
                    elevationImageString = "Images/BSolidRock.png";
                }
                else
                {
                    elevationImageString = "Images/BPlains.png";
                }
                using (var image = Tiles.GetImage(elevationImageString))
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
                var terrainImageLocation = Tiles.GetTerrain(hex.TerrainId).ImageLocation;
                using (var image = Tiles.GetImage(terrainImageLocation))
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
                var vegetationImageLocation = Tiles.GetVegetation(hex.VegetationId).ImageLocation;
                using (var image = Tiles.GetImage(vegetationImageLocation))
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
            }
            return tileImage;
        }
    }
}
