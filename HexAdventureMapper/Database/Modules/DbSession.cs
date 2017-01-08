using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database.WorkingClasses;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.Database.Modules
{
    public class DbSession : DbModule<Session>
    {
        public override string TableName => "Sessions";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(CurrentMapCornerX, DbColumn.Integer),
            new DbColumn(CurrentMapCornerY, DbColumn.Integer)
        };

        public const string CurrentMapCornerX = "CurrentMapCornerX";
        public const string CurrentMapCornerY = "CurrentMapCornerY";

        public DbSession(DbInterface dbInterface, IDbInstance db) : base(dbInterface, db)
        {
        }

        public int CreateDefault()
        {
            return Db.Insert(TableName,
                new[] { Id, CurrentMapCornerX, CurrentMapCornerY },
                new object[] { 1, 0, 0 });
        }

        public Session Get()
        {
            var results = Db.Select(TableName, AllColumnNames);

            if (results.Length > 0)
            {
                var session = MakeObject((object[])results[0]);
                return session;
            }
            return null;
        }

        public void UpdateLocation(HexCoordinate partyLocation)
        {
            Db.Update(TableName, new[] { CurrentMapCornerX, CurrentMapCornerY }, new object[] { partyLocation.X, partyLocation.Y }, new[] { Id }, new object[] { 1 });
        }

        protected override Session MakeObject(object[] dbObject)
        {
            var currentMapCorner = new HexCoordinate((long)dbObject[1], (long)dbObject[2]);

            var party = new Session() { CurrentMapCorner = currentMapCorner };

            return party;
        }
    }
}
