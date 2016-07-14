using System;
using System.Drawing;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Visualizer.LayerDrawers
{
    public class RoadLayerDrawer : BaseLayerDrawer
    {
        public RoadLayerDrawer(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db) : base(uiInterface, tiles, db)
        {
        }

        public override Layer GetLayerType()
        {
            return Layer.Road;
        }

        protected override void DrawHex(Graphics graphics, Hex hex, int alpha = 0)
        {
            HexCoordinate positionOnVisibleMap = hex.Coordinate.Minus(UiInterface.GetMapBox().TopLeftCoordinate);
            Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
            var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

            foreach (var roadSection in hex.RoadSections)
            {
                var points = HexConnectionPointsFor(roadSection);
                var pen = GetRoadPen(roadSection.Type);
                var from = new Point(pictureLocationAndSize.X + points[0], pictureLocationAndSize.Y + points[1]);
                var to = new Point(pictureLocationAndSize.X + points[2], pictureLocationAndSize.Y + points[3]);
                graphics.DrawLine(pen, from, to);
            }
        }

        private Pen GetRoadPen(int type)
        {
            int roadWidth;
            Color color;
            switch (type)
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
            return pen;
        }

        private int[] HexConnectionPointsFor(HexConnection hexConnection)
        {
            Point offset = new Point(0, 0);

            int midPointX = TileConfigInterface.HexWidth / 2 + offset.X;
            int midPointY = TileConfigInterface.HexHeight / 2 + offset.Y;

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

            var points = new int[] { midPointX, midPointY, edgeX, edgeY };

            return points;
        }
    }
}
