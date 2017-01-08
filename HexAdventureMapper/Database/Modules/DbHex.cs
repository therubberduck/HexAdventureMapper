using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database.WorkingClasses;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Database.Modules
{
    public class DbHex : DbModule<Hex>
    {
        public override string TableName => "Hexes";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(CoordinateX, DbColumn.Integer),
            new DbColumn(CoordinateY, DbColumn.Integer),
            new DbColumn(Terrain, DbColumn.Integer),
            new DbColumn(Vegetation, DbColumn.Integer),
            new DbColumn(Icons, DbColumn.Text),
            new DbColumn(PlayerIcons, DbColumn.Text),
            new DbColumn(FogOfWar, DbColumn.Integer),
            new DbColumn(Detail, DbColumn.Text),
            new DbColumn(RiverOffsetX, DbColumn.Integer),
            new DbColumn(RiverOffsetY, DbColumn.Integer),
            new DbColumn(RoadOffsetX, DbColumn.Integer),
            new DbColumn(RoadOffsetY, DbColumn.Integer),
        };

        public const string CoordinateX = "CoordinateX";
        public const string CoordinateY = "CoordinateY";
        public const string Terrain = "Terrain";
        public const string Vegetation = "Vegetation";
        public const string Icons = "Icons";
        public const string PlayerIcons = "PlayerIcons";
        public const string FogOfWar = "FogOfWar";
        public const string Detail = "Detail";
        public const string RiverOffsetX = "RiverOffsetX";
        public const string RiverOffsetY = "RiverOffsetY";
        public const string RoadOffsetX = "RoadOffsetX";
        public const string RoadOffsetY = "RoadOffsetY";

        private readonly Dictionary<string, KeyValuePair<Rectangle, List<Hex>>> _oneItemCache;

        public DbHex(DbInterface dbInterface, IDbInstance db) : base(dbInterface, db)
        {
            _oneItemCache = new Dictionary<string, KeyValuePair<Rectangle, List<Hex>>>();
        }

        public int Create(HexCoordinate coor, int terrainId, int vegetationId)
        {
            return Db.Insert(TableName, 
                new [] {CoordinateX, CoordinateY, Terrain, Vegetation, Icons, PlayerIcons, FogOfWar, Detail, RiverOffsetX, RiverOffsetY, RoadOffsetX, RoadOffsetY}, 
                new object[] { coor.X, coor.Y, terrainId, vegetationId, 0, 0, 0, "", -10, 0, 0, 0});
        }

        public bool HexExists(HexCoordinate coordinate)
        {
            Hex hex = GetForCoordinate(coordinate);
            return hex != null;
        }

        public List<Hex> GetArea(string handlerTag, Rectangle hexArea, bool useCache = true)
        {
            if (useCache && _oneItemCache.ContainsKey(handlerTag) && _oneItemCache[handlerTag].Key.Equals(hexArea))
            {
                return _oneItemCache[handlerTag].Value;
            }

            string otherClauses = "WHERE " + CoordinateX + " >= " + hexArea.Left + " AND " + CoordinateX + " <= " +
                                  hexArea.Right +
                                  " AND " + CoordinateY + " >= " + hexArea.Top + " AND " + CoordinateY + " <= " +
                                  hexArea.Bottom;
            otherClauses += " ORDER BY " + CoordinateX + "," + CoordinateY;
            var results = Db.Select(TableName, AllColumnNames, otherClauses);

            var returnList = new List<Hex>();
            foreach (object[] o in results)
            {
                var resultObject = MakeObject(o);
                returnList.Add(resultObject);
            }
            _oneItemCache[handlerTag] = new KeyValuePair<Rectangle, List<Hex>>(hexArea, returnList);
            return returnList;
        }

        public List<Hex> GetForCoordinates(List<HexCoordinate> areaCoordinates)
        {
            string otherClauses = "";
            foreach (var coordinate in areaCoordinates)
            {
                otherClauses += " OR (" + CoordinateX + " = " + coordinate.X + " AND " + CoordinateY + " = " + coordinate.Y +
                                ")";
            }
            otherClauses = "WHERE " + otherClauses.Substring(4);
            otherClauses += " ORDER BY " + CoordinateX + "," + CoordinateY;
            var results = Db.Select(TableName, AllColumnNames, otherClauses);

            var returnList = new List<Hex>();
            foreach (object[] o in results)
            {
                var resultObject = MakeObject(o);
                returnList.Add(resultObject);
            }
            return returnList;
        }

        public Hex GetForCoordinate(HexCoordinate coor)
        {
            object[] results = Db.Select(TableName, AllColumnNames, new[] {CoordinateX, CoordinateY},
                new object[] {coor.X, coor.Y});
            if (results.Length == 0)
            {
                return null;
            }
            return MakeObject((object[]) results[0]);
        }

        public void UpdateTerrain(HexCoordinate coor, int terrainId, int vegetationId)
        {
            Db.Update(TableName, new[] {Terrain, Vegetation}, new object[] {terrainId, vegetationId}, new [] {CoordinateX, CoordinateY}, new object[] { coor.X, coor.Y});
        }

        public void UpdateIcon(HexCoordinate coor, int iconId)
        {
            Db.Update(TableName, new[] {Icons}, new object[] {iconId.ToString()}, new[] { CoordinateX, CoordinateY }, new object[] { coor.X, coor.Y });
        }

        public void UpdatePlayerIcon(HexCoordinate coor, int iconId)
        {
            Db.Update(TableName, new[] { PlayerIcons }, new object[] { iconId.ToString() }, new[] { CoordinateX, CoordinateY }, new object[] { coor.X, coor.Y });
        }

        public void UpdateDetail(HexCoordinate coor, string detail)
        {
            Db.Update(TableName, new[] { Detail }, new object[] { detail }, new[] { CoordinateX, CoordinateY }, new object[] { coor.X, coor.Y });
        }

        public void UpdateFogOfWar(List<Hex> revealArea)
        {
            List<HexCoordinate> fullyRevealedHexes = new List<HexCoordinate>();
            List<HexCoordinate> partiallyRevealedHexes = new List<HexCoordinate>();

            foreach (var hex in revealArea)
            {
                if (hex.FogOfWar == TileId.NoFogOfWar)
                {
                    fullyRevealedHexes.Add(hex.Coordinate);
                }
                else if (hex.FogOfWar == TileId.PartialFogOfWar)
                {
                    partiallyRevealedHexes.Add(hex.Coordinate);
                }
            }

            //First we update the fully revealed hexes
            string whereClause = "";
            foreach (var coordinate in fullyRevealedHexes)
            {
                whereClause += " OR (" + CoordinateX + " = " + coordinate.X + " AND " + CoordinateY + " = " + coordinate.Y +
                                ")";
            }
            whereClause = "WHERE " + whereClause.Substring(4);

            Db.Update(TableName, FogOfWar, TileId.NoFogOfWar, whereClause);

            //Then we update the partially revealed hexes
            whereClause = "";
            foreach (var coordinate in partiallyRevealedHexes)
            {
                whereClause += " OR (" + CoordinateX + " = " + coordinate.X + " AND " + CoordinateY + " = " + coordinate.Y +
                                ")";
            }
            whereClause = "WHERE " + whereClause.Substring(4);

            Db.Update(TableName, FogOfWar, TileId.PartialFogOfWar, whereClause);
        }

        public void UpdateFogOfWar(HexCoordinate coor, int fogId)
        {
            Db.Update(TableName, new[] { FogOfWar }, new object[] { fogId.ToString() }, new[] { CoordinateX, CoordinateY }, new object[] { coor.X, coor.Y });
        }

        public void ClearTerrain(HexCoordinate worldCoordinate)
        {
            UpdateTerrain(worldCoordinate, 0, 0);
        }

        public void ClearIcons(HexCoordinate worldCoordinate)
        {
            UpdateIcon(worldCoordinate, 0);
        }

        public void ClearPlayerIcons(HexCoordinate worldCoordinate)
        {
            UpdatePlayerIcon(worldCoordinate, 0);
        }

        protected override Hex MakeObject(object[] dbObject)
        {
            var id = (long) dbObject[0];
            var coordinate = new HexCoordinate((long) dbObject[1], (long) dbObject[2]);
            var terrain = GetInt(dbObject[3]);
            var vegetation = GetInt(dbObject[4]);
            var icons = ((string) dbObject[5]).Split(',').Select(str => int.Parse(str)).ToList();
            var playericons = ((string)dbObject[6]).Split(',').Select(s => int.Parse(s)).ToList();
            var fogofwar = GetInt(dbObject[7]);
            var detail = (string) dbObject[8];
            var riverOffset = new Point(GetInt(dbObject[9]), GetInt(dbObject[10]));
            var roadOffset = new Point(GetInt(dbObject[11]), GetInt(dbObject[12]));

            var hex = new Hex
            {
                Id = id,
                Coordinate = coordinate,
                TerrainId =  terrain,
                VegetationId = vegetation,
                Icons = icons,
                PlayerIcons = playericons,
                FogOfWar = fogofwar,
                Detail = detail,
                RiverOffset = riverOffset,
                RoadOffset = roadOffset
            };


            hex.RiverSections = new List<HexConnection>();
            hex.RoadSections = new List<HexConnection>();

            var connections = DbInterface.HexConnections.GetConnectionsForHex(hex.Coordinate);
            foreach (var hexConnection in connections)
            {
                if (hexConnection.IsRiver)
                {
                    hex.RiverSections.Add(hexConnection);
                }
                else
                {
                    hex.RoadSections.Add(hexConnection);
                }
            }

            return hex;
        }
    }
}
