using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexAdventureMapper.DataObjects
{
    public class HexCoordinate : IComparable
    {
        public long X { get; }
        public long Y { get; }

        public HexCoordinate(long x, long y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "X = " + X + " Y = " + Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is HexCoordinate)
            {
                var hexCoordinate = (HexCoordinate) obj;
                return hexCoordinate.X == X && hexCoordinate.Y == Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            var otherCoor = (HexCoordinate) obj;

            if (X > otherCoor.X)
            {
                return 1;
            }
            if (X < otherCoor.X)
            {
                return -1;
            }

            if (Y > otherCoor.Y)
            {
                return 1;
            }

            if (Y < otherCoor.Y)
            {
                return -1;
            }

            return 0;
        }

        public HexCoordinate Plus(HexCoordinate otherCoor)
        {
            return new HexCoordinate(X + otherCoor.X, Y + otherCoor.Y);
        }

        public HexCoordinate Minus(HexCoordinate otherCoor)
        {
            return new HexCoordinate(X - otherCoor.X, Y - otherCoor.Y);
        }

        public HexArea HexArea(uint range)
        {
            return new HexArea(X, Y, range);
        }

        public string ToText()
        {
            return X.ToString("D4") + ", " + Y.ToString("D4");
        }
    }
}
