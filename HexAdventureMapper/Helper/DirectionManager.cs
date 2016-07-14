using System;
using System.Collections.Generic;
using System.Linq;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.Helper
{
    public static class DirectionManager
    {
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

        public static Hex GetHexNeighbor(List<Hex> hexes, Hex hex, Direction direction)
        {
            var neighborCoordinate = DirectionManager.NeighborTo(hex.Coordinate, direction);
            Hex neighbor = hexes.Find(h => Equals(h.Coordinate, neighborCoordinate));
            return neighbor;
        }

        public static List<HexCoordinate> GetNeighborsTo(HexCoordinate hexcoordinate)
        {
            var neighbors = new List<HexCoordinate>();
            foreach (var direction in Enum.GetValues(typeof(Direction)).Cast<Direction>())
            {
                neighbors.Add(NeighborTo(hexcoordinate, direction));
            }
            return neighbors;
        }

        public static List<HexCoordinate> GetTwoStepAreaAround(HexCoordinate hexcoordinate)
        {
            var neighbors = new List<HexCoordinate>();

            var northHex = NeighborTo(hexcoordinate, Direction.North);
            var northeastHex = NeighborTo(hexcoordinate, Direction.NorthEast);
            var southeastHex = NeighborTo(hexcoordinate, Direction.SouthEast);
            var southHex = NeighborTo(hexcoordinate, Direction.South);
            var southwestHex = NeighborTo(hexcoordinate, Direction.SouthWest);
            var northwestHex = NeighborTo(hexcoordinate, Direction.NorthWest);

            neighbors.Add(northHex);
            neighbors.Add(NeighborTo(northHex, Direction.NorthWest));
            neighbors.Add(NeighborTo(northHex, Direction.North));
            neighbors.Add(NeighborTo(northHex, Direction.NorthEast));

            neighbors.Add(northeastHex);
            neighbors.Add(NeighborTo(northeastHex, Direction.NorthEast));

            neighbors.Add(southeastHex);
            neighbors.Add(NeighborTo(southeastHex, Direction.NorthEast));
            neighbors.Add(NeighborTo(southeastHex, Direction.SouthEast));
            neighbors.Add(NeighborTo(southeastHex, Direction.South));

            neighbors.Add(southHex);
            neighbors.Add(NeighborTo(southHex, Direction.South));

            neighbors.Add(southwestHex);
            neighbors.Add(NeighborTo(southwestHex, Direction.South));
            neighbors.Add(NeighborTo(southwestHex, Direction.SouthWest));
            neighbors.Add(NeighborTo(southwestHex, Direction.NorthWest));

            neighbors.Add(northwestHex);
            neighbors.Add(NeighborTo(northwestHex, Direction.NorthWest));
            
            neighbors.Add(hexcoordinate);

            return neighbors;
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

        public static Direction[] OuterDirectionsForDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new[] {Direction.NorthWest, Direction.North, Direction.NorthEast};
                case Direction.NorthEast:
                    return new[] {Direction.North, Direction.NorthEast, Direction.SouthEast};
                case Direction.SouthEast:
                    return new[] {Direction.NorthEast, Direction.SouthEast, Direction.South};
                case Direction.South:
                    return new[] {Direction.SouthEast, Direction.South, Direction.SouthWest};
                case Direction.SouthWest:
                    return new[] {Direction.South, Direction.SouthWest, Direction.NorthWest};
                case Direction.NorthWest:
                    return new[] {Direction.SouthWest, Direction.NorthWest, Direction.North};
                default:
                    return new Direction[] {};
            }
        }
    }
}
