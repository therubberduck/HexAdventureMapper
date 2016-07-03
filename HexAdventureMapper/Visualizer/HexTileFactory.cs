using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Painting;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Visualizer
{
    public class HexTileFactory
    {
        private const int hexWidth = 50;
        private const int hexHeight = 44;

        private readonly IDrawingUi _uiInterface;
        private readonly TileConfigInterface _tiles;
        private readonly TileCache _tileCache;
        private readonly Dictionary<String, Bitmap> _mapTileImages;

        public HexTileFactory(IDrawingUi uiInterface, TileConfigInterface tiles, TileCache tileCache)
        {
            _uiInterface = uiInterface;
            _tiles = tiles;
            _tileCache = tileCache;
            _mapTileImages = new Dictionary<string, Bitmap>();
        }

        public Bitmap GenerateMapTile(Hex hex, Layer layer)
        {
            if (layer == Layer.Finished)
            {
                //Check if the tile is already cached
                if (_tileCache.GetFinishedTile(hex.Coordinate) != null)
                {
                    return _tileCache.GetFinishedTile(hex.Coordinate);
                }
                else //If not cached create the tile from scratch
                {
                    layer = Layer.Terrain;
                }
            }

            Bitmap image;
            Layer activeLayer;
            if (layer == Layer.FogOfWar)
            {
                image = _tileCache.GetIconTile(hex.Coordinate);
                if (image != null)
                {
                    image = image.Clone() as Bitmap;
                    activeLayer = Layer.FogOfWar;
                }
                else
                {
                    image = _tileCache.GetConnectionTile(hex.Coordinate);
                    if (image != null)
                    {
                        image = image.Clone() as Bitmap;
                        activeLayer = Layer.GmIcon;
                    }
                    else
                    {
                        image = new Bitmap(hexWidth, hexHeight);
                        activeLayer = Layer.Terrain;
                    }
                }
            }
            else if (layer == Layer.GmIcon || layer == Layer.PlayerIcon)
            {
                image = _tileCache.GetConnectionTile(hex.Coordinate);
                if (image != null)
                {
                    image = image.Clone() as Bitmap;
                    activeLayer = Layer.GmIcon;
                }
                else
                {
                    image = new Bitmap(hexWidth, hexHeight);
                    activeLayer = Layer.Terrain;
                }
            }
            else
            {
                image = new Bitmap(hexWidth, hexHeight);
                activeLayer = Layer.Terrain;
            }

            using (var graphics = Graphics.FromImage(image))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                if (activeLayer == Layer.Terrain)
                {
                    var tileMarker = hex.TerrainId + "|" + hex.VegetationId;
                    if (_mapTileImages.ContainsKey(tileMarker))
                    {
                        var pictureLocationAndSize = new Rectangle(0, 0, hexWidth, hexHeight);
                        graphics.DrawImage(_mapTileImages[tileMarker], pictureLocationAndSize);
                    }
                    else
                    {
                        AddTerrainLayers(graphics, hex);
                        _mapTileImages[tileMarker] = image.Clone() as Bitmap;
                    }

                    AddRiverLayer(graphics, hex);
                    AddRoadLayer(graphics, hex);

                    _tileCache.SetConnectionTile(hex.Coordinate, image.Clone() as Bitmap);
                }
                if (activeLayer <= Layer.GmIcon)
                {
                    if (_uiInterface.GetGmIconAlpha() != 0)
                    {
                        AddIconLayer(graphics, hex, _uiInterface.GetGmIconAlpha());
                    }
                    if (_uiInterface.GetPlayerIconAlpha() != 0)
                    {
                        AddPlayerIconLayer(graphics, hex, _uiInterface.GetPlayerIconAlpha());
                    }

                    _tileCache.SetIconTile(hex.Coordinate, image.Clone() as Bitmap);
                }
                if (_uiInterface.GetFogOfWarIconAlpha() != 0)
                {
                    AddFogOfWar(graphics, hex, _uiInterface.GetFogOfWarIconAlpha());
                }
                _tileCache.SetFinishedTile(hex.Coordinate, image.Clone() as Bitmap);
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
            if (hex.RiverSections.Count == 0)
            {
                return;
            }
            else if (hex.RiverSections.Count == 1)
            {
                var river = hex.RiverSections[0];
                var pen = GetPenForRiver(river);
                var points = HexConnectionPointsFor(river, hex.RiverOffset);
                graphics.DrawLine(pen, points[0], points[1], points[2], points[3]);
            }
            //else if (hex.RiverSections.Count == 2 && hex.RiverSections[0].Type == hex.RiverSections[1].Type)
            //{
            //    graphics.DrawArc();
            //}
            else
            {
                foreach (var riverSection in hex.RiverSections)
                {
                    var points = HexConnectionPointsFor(riverSection, hex.RiverOffset);
                    var pen = GetPenForRiver(riverSection);
                    graphics.DrawLine(pen, points[0], points[1], points[2], points[3]);
                }
            }
        }

        private Pen GetPenForRiver(HexConnection riverSection)
        {
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
            return new Pen(color, riverWidth);
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
                    case 6:
                        color = Color.DarkSeaGreen;
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
            //Same offset for all river hexes
            if (offset.X != 0)
            {
                offset.X = -10;
            }

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

            edgeX = (int)(midPointX + sin * 30); //30 is the length of the river piece
            edgeY = (int)(midPointY + cos * 30); //it is longer than we need, but the precise value (22) leaves gaps

            var points = new int[] {midPointX, midPointY, edgeX, edgeY};

            return points;
        }

        private void AddIconLayer(Graphics graphics, Hex hex, int alpha)
        {
            var pictureLocationAndSize = new Rectangle(hexWidth/4, hexHeight/4, hexWidth/2, hexHeight/2);

            var iconImageLocation = _tiles.GetIcon(hex.Icons[0]).ImageLocation;
            using (var image = Image.FromFile(iconImageLocation))
            {
                if (alpha == 100)
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
                else
                {
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = alpha / 100.0f;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    graphics.DrawImage(image, pictureLocationAndSize, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
            }
        }

        private void AddPlayerIconLayer(Graphics graphics, Hex hex, int alpha)
        {
            var pictureLocationAndSize = new Rectangle(hexWidth / 4, hexHeight / 4, hexWidth / 2, hexHeight / 2);

            var iconImageLocation = _tiles.GetIcon(hex.PlayerIcons[0]).ImageLocation;
            using (var image = Image.FromFile(iconImageLocation))
            {
                if (alpha == 100)
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
                else
                {
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = alpha / 100.0f;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    graphics.DrawImage(image, pictureLocationAndSize, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
            }
        }

        private void AddFogOfWar(Graphics graphics, Hex hex, int alpha)
        {
            int typeAlpha = 100;
            if (hex.FogOfWar == 1) //Draw partially transparent fog of war
            {
                typeAlpha = 50;
            }
            else if (hex.FogOfWar == 2) //Don't draw any fog of war
            {
                return;
            }

            float dAlpha = (typeAlpha/100.0f)*(alpha/100.0f);

            var pictureLocationAndSize = new Rectangle(0, 0, hexWidth, hexHeight);

            var iconImageLocation = "Images/FogOfWar.png";
            using (var image = Image.FromFile(iconImageLocation))
            {
                if (typeAlpha == 100 && alpha == 100)
                {
                    graphics.DrawImage(image, pictureLocationAndSize);
                }
                else
                {
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = dAlpha;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    graphics.DrawImage(image, pictureLocationAndSize, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
            }
        }
    }
}
