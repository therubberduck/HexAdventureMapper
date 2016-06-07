using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.Visualizer
{
    public static class PositionManager
    {
        public static Point HexToScreen(HexCoordinate hex)
        {
            return HexToScreen(hex.X, hex.Y);
        }

        public static Point HexToScreen(long x, long y)
        {
            return new Point((int)x * 37, (int)y * 44 + (int)Math.Abs(x % 2) * 22);
        }

        public static HexCoordinate ScreenToHex(long x, long y)
        {
            long xCoor = x/37;
            long yCoor = (y - (xCoor % 2 * 22))/44;
            return new HexCoordinate(xCoor, yCoor);
        }

        public static Direction PartOfHexClicked(int x, int y)
        {
            HexCoordinate hexCoordinates = ScreenToHex(x, y);
            int westEdge = (int) (37 * hexCoordinates.X);
            int northEdge = (int) (44 * hexCoordinates.Y + hexCoordinates.X % 2 * 22);
            
            Debug.WriteLine("hexX: " + hexCoordinates.X + " hexY: " + hexCoordinates.Y);

            Rectangle northWest = new Rectangle(westEdge, northEdge, 12, 22);
            if (northWest.Contains(x, y))
            {
                Debug.WriteLine("Northwest");
                return Direction.NorthWest;
            }

            Rectangle north = new Rectangle(westEdge + 16, northEdge, 13, 22);
            if (north.Contains(x, y))
            {
                Debug.WriteLine("North");
                return Direction.North;
            }

            Rectangle northEast = new Rectangle(westEdge + 32, northEdge, 12, 22);
            if (northEast.Contains(x, y))
            {
                Debug.WriteLine("Northeast");
                return Direction.NorthEast;
            }

            Rectangle southWest = new Rectangle(westEdge, northEdge + 22, 12, 22);
            if (southWest.Contains(x, y))
            {
                Debug.WriteLine("Southwest");
                return Direction.SouthWest;
            }
            Rectangle south = new Rectangle(westEdge + 16, northEdge + 22, 13, 22);
            if (south.Contains(x, y))
            {
                Debug.WriteLine("South");
                return Direction.South;
            }

            Rectangle southEast = new Rectangle(westEdge + 32, northEdge + 22, 12, 22);
            if (southEast.Contains(x, y))
            {
                Debug.WriteLine("Southeast");
                return Direction.SouthEast;
            }

            return Direction.None;
        }

        public static HexCoordinate NeighborTo(HexCoordinate hexcoordinate, Direction direction)
        {
            long xCoor = hexcoordinate.X;
            long yCoor = hexcoordinate.Y;

            switch (direction)
            {
                case Direction.North:
                    yCoor -= 1;
                    break;
                case Direction.NorthEast:
                    yCoor -= (1 - Math.Abs(xCoor % 2));
                    xCoor += 1;
                    break;
                case Direction.SouthEast:
                    yCoor += Math.Abs(xCoor%2);
                    xCoor += 1;
                    break;
                case Direction.South:
                    yCoor += 1;
                    break;
                case Direction.SouthWest:
                    yCoor += Math.Abs(xCoor % 2);
                    xCoor -= 1;
                    break;
                case Direction.NorthWest:
                    yCoor -= (1 - Math.Abs(xCoor%2));
                    xCoor -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }

            return new HexCoordinate(xCoor, yCoor);
        }

        public static Direction OppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return Direction.South;
                case Direction.NorthEast:
                    return Direction.SouthWest;
                case Direction.SouthEast:
                    return Direction.NorthWest;
                case Direction.South:
                    return Direction.North;
                case Direction.SouthWest:
                    return Direction.NorthEast;
                case Direction.NorthWest:
                    return Direction.SouthEast;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public static Rectangle ScreenAreaToHexArea(HexCoordinate globalTopLeft, Size screenSize)
        {
            var localBottomRight = ScreenToHex(screenSize.Width, screenSize.Height);
            //We want global for the location, and local for the width/height
            return new Rectangle((int) globalTopLeft.X,(int) globalTopLeft.Y, (int) localBottomRight.X, (int) localBottomRight.Y);
        }
    }
}
