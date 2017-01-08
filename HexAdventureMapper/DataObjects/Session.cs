using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexAdventureMapper.DataObjects
{
    public class Session
    {
        public HexCoordinate CurrentMapCorner;
        public int Year;
        public int Day;
        public TimeSpan Time;

        public string TimeString => $"{Time.Hours:00}:{Time.Minutes:00}";
    }
}
