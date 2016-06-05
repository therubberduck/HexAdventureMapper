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

        private DbWrapper _dbWrapper ;

        public DbInterface()
        {
            _dbWrapper = new DbWrapper();

            Hexes = new DbHex(this, _dbWrapper);
            HexConnections = new DbHexConnection(this, _dbWrapper);

            //
            //TestData.AddTestData(this);
        }

        public void ClearDb()
        {
            _dbWrapper.CreateTables(new IDbModule[] { Hexes, HexConnections });
            Hexes.ClearTable();
            HexConnections.ClearTable();
        }
    }
}
