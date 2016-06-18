using HexAdventureMapper.Database.Modules;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Visualizer;

namespace HexAdventureMapper.Database
{
    public static class TestData
    {
        public static void AddTestData(DbInterface db)
        {
            db.Hexes.ClearTable();
            var hex1 = new HexCoordinate(0, 0);
            var hex2 = new HexCoordinate(0, 1);
            var hex3 = new HexCoordinate(0, 2);
            var hex4 = new HexCoordinate(1, 0);
            var hex5 = new HexCoordinate(1, 1);
            var hex6 = new HexCoordinate(1, 2);
            var hex7 = new HexCoordinate(2, 0);
            var hex8 = new HexCoordinate(2, 1);
            var hex9 = new HexCoordinate(2, 2);
            var hex10 = new HexCoordinate(3, 0);
            var hex11 = new HexCoordinate(3, 1);
            var hex12 = new HexCoordinate(3, 2);

            db.Hexes.Create(hex1, 0, 1);
            db.Hexes.Create(hex2, 0, 2);
            db.Hexes.Create(hex3, 0, 3);
            db.Hexes.Create(hex4, 2, 1);
            db.Hexes.Create(hex5, 2, 2);
            db.Hexes.Create(hex6, 2, 3);
            db.Hexes.Create(hex7, 3, 1);
            db.Hexes.Create(hex8, 3, 2);
            db.Hexes.Create(hex9, 3, 3);
            db.Hexes.Create(hex10, 0, 1);
            db.Hexes.Create(hex11, 0, 2);
            db.Hexes.Create(hex12, 0, 3);

            db.Hexes.UpdateIcon(hex5, 1);
            db.Hexes.UpdateIcon(hex7, 2);

            db.Hexes.UpdateDetail(hex5, "Mansion of Howard Grey");
            db.Hexes.UpdateDetail(hex7, "Ruined tower");

            db.HexConnections.ClearTable();
            //db.HexConnections.Create(hex1, 0, Direction.South);
            //db.HexConnections.Create(hex1, 1, Direction.SouthEast);

            //db.HexConnections.Create(hex2, 0, Direction.North);
            //db.HexConnections.Create(hex2, 0, Direction.South);
            //db.HexConnections.Create(hex2, 0, Direction.NorthEast);

            //db.HexConnections.Create(hex3, 0, Direction.North);

            //db.HexConnections.Create(hex4, 0, Direction.SouthWest);
            //db.HexConnections.Create(hex4, 1, Direction.NorthWest);

            //db.HexConnections.Create(hex1, 4, Direction.South);
            //db.HexConnections.Create(hex1, 5, Direction.SouthEast);

            //db.HexConnections.Create(hex2, 3, Direction.SouthEast);
            //db.HexConnections.Create(hex2, 4, Direction.North);
            //db.HexConnections.Create(hex2, 5, Direction.NorthEast);

            //db.HexConnections.Create(hex4, 5, Direction.SouthWest);
            //db.HexConnections.Create(hex4, 5, Direction.NorthWest);
            
            //db.HexConnections.Create(hex5, 3, Direction.SouthEast);
            //db.HexConnections.Create(hex5, 3, Direction.NorthWest);

            //db.HexConnections.Create(hex9, 3, Direction.NorthWest);
        }
    }
}
