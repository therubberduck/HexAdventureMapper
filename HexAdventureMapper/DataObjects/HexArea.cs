using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexAdventureMapper.DataObjects
{
    public class HexArea
    {
        public long X { get; }
        public long Y { get; }
        public long Width { get; }
        public long Height { get; }

        public long Bottom => Y + Height;
        public long Left => X;
        public long Right => X + Width;
        public long Top => Y;

        public HexArea(long x, long y, long width, long height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public HexArea(long x, long y, uint range)
        {
            X = x - range;
            Y = y - range;
            Width = range * 2 + 1;
            Height = range * 2 + 1;
        }
    }
}
