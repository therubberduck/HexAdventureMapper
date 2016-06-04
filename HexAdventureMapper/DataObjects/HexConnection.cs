using HexAdventureMapper.Visualizer;

namespace HexAdventureMapper.DataObjects
{
    public class HexConnection
    {
        public long Id { get; set; }
        public HexCoordinate Coordinate { get; set; }
        public int Type { get; set; }
        public Direction ToEdge { get; set; }

        public bool IsRiver => Type == 0 || Type == 1 || Type == 2;
    }
}
