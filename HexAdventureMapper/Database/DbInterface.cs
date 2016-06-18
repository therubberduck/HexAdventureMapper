using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database.Modules;
using HexAdventureMapper.Database.WorkingClasses;

namespace HexAdventureMapper.Database
{
    public class DbInterface
    {
        public readonly DbHex Hexes;
        public readonly DbHexConnection HexConnections;

        private readonly IDbInstance _db ;

        public DbInterface()
        {
            _db = new SqLiteDb();

            Hexes = new DbHex(this, _db);
            HexConnections = new DbHexConnection(this, _db);

            DbUpdater.CheckForDbSchemaUpdates(_db, Hexes, HexConnections);
        }

        public void UpdateDbSchema()
        {
            _db.ReloadDb();
            DbUpdater.CheckForDbSchemaUpdates(_db, Hexes, HexConnections);
        }

        public void ClearDb()
        {
            _db.CreateTables(new IDbModule[] { Hexes, HexConnections });
            Hexes.ClearTable();
            HexConnections.ClearTable();
        }
    }
}
