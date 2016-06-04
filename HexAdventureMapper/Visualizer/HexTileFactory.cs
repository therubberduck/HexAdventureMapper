﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Visualizer
{
    public class HexTileFactory
    {
        private const int hexWidth = 50;
        private const int hexHeight = 44;

        private TileConfigInterface _tiles;
        private readonly Dictionary<String, Bitmap> _mapTileImages;

        public HexTileFactory(TileConfigInterface tiles)
        {
            _tiles = tiles;
            _mapTileImages = new Dictionary<string, Bitmap>();
        }

        public Bitmap GetMapTileFor(Hex hex)
        {
             Bitmap mapTile = GenerateMapTile(hex);
            //_mapTileImages[tileMarker] = mapTile;
            return mapTile;
        }

        public Bitmap GenerateMapTile(Hex hex)
        {
            var image = new Bitmap(hexWidth, hexHeight);
            using (var graphics = Graphics.FromImage(image))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var tileMarker = hex.TerrainId + "|" + hex.VegetationId;
                if (_mapTileImages.ContainsKey(tileMarker))
                {
                    var pictureLocationAndSize = new Rectangle(0, 0, hexWidth, hexHeight);
                    graphics.DrawImage(_mapTileImages[tileMarker], pictureLocationAndSize);
                }
                else
                {
                    AddTerrainLayers(graphics, hex);
                    _mapTileImages[tileMarker] = image;
                }

                AddRiverLayer(graphics, hex);
                AddRoadLayer(graphics, hex);
                AddIconLayer(graphics, hex);
            }
            return image;
        }

        private void AddTerrainLayers(Graphics graphics, Hex hex)
        {
            var pictureLocationAndSize = new Rectangle(0, 0, hexWidth, hexHeight);

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
            ;
            var terrainImageLocation = _tiles.GetTerrain(hex.TerrainId).ImageLocation;
            using (var image = Image.FromFile(terrainImageLocation))
            {
                graphics.DrawImage(image, pictureLocationAndSize);
            }
            var vegetationImageLocation = _tiles.GetVegetation(hex.VegetationId).ImageLocation;
            using (var image = Image.FromFile(vegetationImageLocation))
            {
                graphics.DrawImage(image, pictureLocationAndSize);
            }
        }

        private void AddRiverLayer(Graphics graphics, Hex hex)
        {
            foreach (var riverSection in hex.RiverSections)
            {
                var points = HexConnectionPointsFor(riverSection, hex.RiverOffset);
                int riverWidth;
                Color color;
                switch (riverSection.Type)
                {
                    case 0:
                        color = Color.Blue;
                        riverWidth = 1;
                        break;
                    case 1:
                        color = Color.Blue;
                        riverWidth = 3;
                        break;
                    case 2:
                        color = Color.Blue;
                        riverWidth = 5;
                        break;
                    default:
                        color = Color.DodgerBlue;
                        riverWidth = 1;
                        break;
                }
                var pen = new Pen(color, riverWidth);
                graphics.DrawLine(pen, points[0], points[1], points[2], points[3]);
            }
        }

        private void AddRoadLayer(Graphics graphics, Hex hex)
        {
            foreach (var roadSection in hex.RoadSections)
            {
                var points = HexConnectionPointsFor(roadSection, hex.RoadOffset);
                int roadWidth;
                Color color;
                switch (roadSection.Type)
                {
                    case 3:
                        color = Color.Brown;
                        roadWidth = 2;
                        break;
                    case 4:
                        color = Color.SandyBrown;
                        roadWidth = 3;
                        break;
                    case 5:
                        color = Color.DimGray;
                        roadWidth = 4;
                        break;
                    default:
                        color = Color.Brown;
                        roadWidth = 1;
                        break;
                }
                var pen = new Pen(color, roadWidth);
                graphics.DrawLine(pen, points[0], points[1], points[2], points[3]);
            }
        }

        private int[] HexConnectionPointsFor(HexConnection hexConnection, Point offset)
        {
            int midPointX = hexWidth/2 + offset.X;
            int midPointY = hexHeight/2 + offset.Y;

            int edgeX;
            int edgeY;
            double angle;
            switch (hexConnection.ToEdge)
            {
                case Direction.North:
                    angle = Math.PI * 180 / 180;
                    break;
                case Direction.NorthEast:
                    angle = Math.PI * 120 / 180;
                    break;
                case Direction.SouthEast:
                    angle = Math.PI * 60 / 180;
                    break;
                case Direction.South:
                    angle = Math.PI * 0 / 180;
                    break;
                case Direction.SouthWest:
                    angle = Math.PI * 300 / 180;
                    break;
                case Direction.NorthWest:
                    angle = Math.PI * 240 / 180;
                    break;
                default:
                    angle = 0;
                    break;
            }

            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);

            edgeX = (int)(midPointX + sin * 22);
            edgeY = (int)(midPointY + cos * 22);

            var points = new int[] {midPointX, midPointY, edgeX, edgeY};

            return points;
        }

        private void AddIconLayer(Graphics graphics, Hex hex)
        {
            var pictureLocationAndSize = new Rectangle(0, 0, hexWidth, hexHeight);

            var iconImageLocation = _tiles.GetIcon(hex.Icons[0]).ImageLocation;
            using (var image = Image.FromFile(iconImageLocation))
            {
                graphics.DrawImage(image, pictureLocationAndSize);
            }
        }
    }
}
