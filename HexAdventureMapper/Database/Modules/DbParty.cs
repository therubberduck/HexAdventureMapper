using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database.WorkingClasses;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.Database.Modules
{
    public class DbParty : DbModule<Party>
    {
        public override string TableName => "Hexes";

        public override DbColumn[] AllColumns => new[]
        {
            new DbColumn(Id, DbColumn.Integer, true),
            new DbColumn(CoordinateX, DbColumn.Integer),
            new DbColumn(CoordinateY, DbColumn.Integer)
        };

        public const string CoordinateX = "CoordinateX";
        public const string CoordinateY = "CoordinateY";

        public DbParty(DbInterface dbInterface, IDbInstance db) : base(dbInterface, db)
        {
        }

        public int CreateDefault()
        {
            return Db.Insert(TableName,
                new[] { Id, CoordinateX, CoordinateY },
                new object[] {1, 0, 0 });
        }

        public Party Get()
        {
            var results = Db.Select(TableName, AllColumnNames);

            if (results.Length > 0)
            {
                var party = MakeObject((object[])results[0]);
                return party;
            }
            return null;
        }

        public void UpdateLocation(HexCoordinate partyLocation)
        {
            Db.Update(TableName, new[] { CoordinateX, CoordinateY }, new object[] { partyLocation.X, partyLocation.Y }, new[] { Id }, new object[] { 1 });
        }

        protected override Party MakeObject(object[] dbObject)
        {
            var location = new HexCoordinate((long)dbObject[1], (long)dbObject[2]);

            var party = new Party() {Location = location};

            return party;
        }
    }
}
