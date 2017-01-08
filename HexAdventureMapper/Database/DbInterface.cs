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
        private readonly IDbInstance _campaignDb;
        private readonly IDbInstance _mapDb;

        public readonly DbParty Party;
        public readonly DbSession Session;

        public readonly DbHex Hexes;
        public readonly DbHexConnection HexConnections;

        public DbInterface()
        {
            _campaignDb = new SqLiteDb(Properties.Settings.Default.CampaignDatabaseName);
            _mapDb = new SqLiteDb(Properties.Settings.Default.MapDatabaseName);

            Party = new DbParty(this, _campaignDb);
            Session = new DbSession(this, _campaignDb);


            Hexes = new DbHex(this, _mapDb);
            HexConnections = new DbHexConnection(this, _mapDb);
            DbUpdater.CheckForCampaignDbSchemaUpdates(_campaignDb, Party, Session);
            DbUpdater.CheckForMapDbSchemaUpdates(_mapDb, Hexes, HexConnections);
        }

        public void UpdateDbSchema()
        {
            _mapDb.ReloadDb();
            DbUpdater.CheckForCampaignDbSchemaUpdates(_campaignDb, Party, Session);
            DbUpdater.CheckForMapDbSchemaUpdates(_mapDb, Hexes, HexConnections);
        }

        public void ClearDb()
        {
            //_mapDb.CreateTables(new IDbModule[] { Hexes, HexConnections });
            Hexes.ClearTable();
            HexConnections.ClearTable();

            Party.ClearTable();
        }
    }
}
