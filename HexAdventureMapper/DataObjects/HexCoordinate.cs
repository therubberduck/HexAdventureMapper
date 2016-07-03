using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexAdventureMapper.DataObjects
{
    public class HexCoordinate
    {
        public long X { get; set; }
        public long Y { get; set; }

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

        public HexCoordinate Plus(HexCoordinate otherCoor)
        {
            return new HexCoordinate(X + otherCoor.X, Y + otherCoor.Y);
        }

        public HexCoordinate Minus(HexCoordinate otherCoor)
        {
            return new HexCoordinate(X - otherCoor.X, Y - otherCoor.Y);
        }

        public string ToText()
        {
            return X.ToString("D4") + ", " + Y.ToString("D4");
        }
    }
}
