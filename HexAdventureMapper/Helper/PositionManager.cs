using System;
using System.Diagnostics;
using System.Drawing;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.Helper
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

        public static Point HexToScreen(HexCoordinate hexCoordinate, HexCoordinate topLeftCoordinate)
        {
            HexCoordinate positionOnVisibleMap = hexCoordinate.Minus(topLeftCoordinate);
            return HexToScreen(positionOnVisibleMap);
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

        public static HexArea ScreenAreaToHexArea(HexCoordinate globalTopLeft, Size screenSize)
        {
            var localBottomRight = ScreenToHex(screenSize.Width, screenSize.Height);
            //We want global for the location, and local for the width/height
            return new HexArea((int) globalTopLeft.X,(int) globalTopLeft.Y, (int) localBottomRight.X, (int) localBottomRight.Y);
        }

        public static HexCoordinate GetTopLeftCoordinateToCenter(HexCoordinate centerCoordinate, HexArea mapArea)
        {
            var newTopLeftCorner = centerCoordinate.Minus(new HexCoordinate(mapArea.Width / 2, mapArea.Height / 2));
            var adjustedTopLeftCorner = ConvertToValidTopLeftCoordinate(newTopLeftCorner);
            return adjustedTopLeftCorner;
        }

        //TopLeftCoordinate must be divisible by 3 or other calculations may screw up
        public static HexCoordinate ConvertToValidTopLeftCoordinate(HexCoordinate oldCoordinate)
        {
            var x = ClosestNumber(oldCoordinate.X, 2);
            var y = ClosestNumber(oldCoordinate.Y, 2);
            return new HexCoordinate(x,y);
        }

        private static long ClosestNumber(long targetNumber, int divisibleBy)
        {
            var q = targetNumber / divisibleBy;
            var n1 = divisibleBy * q;

            long n2;
            if (targetNumber * divisibleBy > 0)
            {
                n2 = divisibleBy * (q + 1);
            }
            else
            {
                n2 = divisibleBy * (q - 1);
            }

            if (Math.Abs(targetNumber - n1) < Math.Abs(targetNumber - n2))
            {
                return n1;
            }
            return n2;
        }
    }
}
