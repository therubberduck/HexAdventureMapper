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
    public class RiverLayerDrawer : BaseLayerDrawer
    {
        public RiverLayerDrawer(IDrawingUi uiInterface, TileConfigInterface tiles, DbInterface db) : base(uiInterface, tiles, db)
        {
        }

        public override Layer GetLayerType()
        {
            return Layer.River;
        }

        protected override void DrawHex(Graphics graphics, Hex hex, int alpha = 0)
        {
            HexCoordinate positionOnVisibleMap = hex.Coordinate.Minus(_uiInterface.GetMapBox().TopLeftCoordinate);
            Point positionOnScreen = PositionManager.HexToScreen(positionOnVisibleMap);
            var pictureLocationAndSize = new Rectangle(positionOnScreen, new Size(50, 44));

            if (hex.RiverSections.Count == 0)
            {
                return;
            }
            else if (hex.RiverSections.Count == 1)
            {
                var river = hex.RiverSections[0];
                DrawSection(graphics, river, pictureLocationAndSize);
            }
            //else if (hex.RiverSections.Count == 2 && hex.RiverSections[0].Type == hex.RiverSections[1].Type)
            //{
            //    graphics.DrawArc();
            //}
            else
            {
                foreach (var riverSection in hex.RiverSections)
                {
                    DrawSection(graphics, riverSection, pictureLocationAndSize);
                }
            }
        }

        private void DrawSection(Graphics graphics, HexConnection riverSection, Rectangle pictureLocationAndSize)
        {
            var points = HexConnectionPointsFor(riverSection);
            var pen = GetPenForRiver(riverSection);
            var from = new Point(pictureLocationAndSize.X + points[0], pictureLocationAndSize.Y + points[1]);
            var to = new Point(pictureLocationAndSize.X + points[2], pictureLocationAndSize.Y + points[3]);
            graphics.DrawLine(pen, from, to);
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

        private int[] HexConnectionPointsFor(HexConnection hexConnection)
        {
            //Same offset for all river hexes
            Point offset = new Point(-10, 0);

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
