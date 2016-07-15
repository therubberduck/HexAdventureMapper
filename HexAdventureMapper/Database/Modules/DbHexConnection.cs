using System;
using System.Collections.Generic;
using System.Linq;
using HexAdventureMapper.Database.WorkingClasses;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;

namespace HexAdventureMapper.Database.Modules
{
    public class DbHexConnection : DbModule<HexConnection>
    {

        public override string TableName => "HexConnection";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(HexCoorX, DbColumn.Integer),
            new DbColumn(HexCoorY, DbColumn.Integer),
            new DbColumn(Type, DbColumn.Integer),
            new DbColumn(ToEdge, DbColumn.Integer)
        };

        public const string HexCoorX = "HexCoorX";
        public const string HexCoorY = "HexCoorY";
        public const string Type = "Type";
        public const string ToEdge = "ToEdge";

        public DbHexConnection(DbInterface dbInterface, IDbInstance db) : base(dbInterface, db)
        {
        }

        public int Create(HexCoordinate coor, int type, Direction toEdge)
        {
            return Db.Insert(TableName, new[] { HexCoorX, HexCoorY, Type, ToEdge }, new object[] { coor.X, coor.Y, type, (int)toEdge });
        }

        public void Remove(HexCoordinate coor, Direction toEdge, int type)
        {
            string whereString = HexCoorX + "=" + coor.X + " AND " + HexCoorY + "=" + coor.Y;
            whereString += " AND " + ToEdge + "=" + (int)toEdge;

            //If type is river, remove any kind of river from hex
            if (type == 0 || type == 1 || type == 2)
            {
                whereString += " AND (" + Type + "=0 OR " + Type + "=1 OR " + Type + "=2)";
            }
            //If type is road, remove any kind of road from hex
            else if (type == 3 || type == 4 || type == 5 || type == 6)
            {
                whereString += " AND (" + Type + "=3 OR " + Type + "=4 OR " + Type + "=5 OR " + Type + "=6)";
            }
            else
            {
                throw new IndexOutOfRangeException("Connection type index given does not match any known connection type");
            }
            Db.Delete(TableName, whereString);
        }

        public List<HexConnection> GetConnectionsForHex(HexCoordinate coor)
        {
            object[] dbObjects = Db.Select(TableName, AllColumnNames, new[] { HexCoorX, HexCoorY }, new object[] { coor.X, coor.Y });
            return dbObjects.Select(t => MakeObject((object[]) t)).ToList();
        }

        protected override HexConnection MakeObject(object[] dbObject)
        {
            var hexConnection = new HexConnection
            {
                Id = (long) dbObject[0],
                Coordinate = new HexCoordinate((long)dbObject[1], (long)dbObject[2]),
                Type = GetInt(dbObject[3]),
                ToEdge = (Direction)GetInt(dbObject[4])
            };
            return hexConnection;
        }
    }
}
