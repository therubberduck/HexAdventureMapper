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

        public DbInterface()
        {
            var dbWrapper = new DbWrapper();

            Hexes = new DbHex(this, dbWrapper);
            HexConnections = new DbHexConnection(this, dbWrapper);

            dbWrapper.CreateTables(new IDbModule[] {Hexes, HexConnections});

            TestData.AddTestData(this);
        }

        public void SaveDb()
        {
            
        }
    }
}
