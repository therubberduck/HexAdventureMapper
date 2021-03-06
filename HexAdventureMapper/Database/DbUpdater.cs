﻿using HexAdventureMapper.Database.Modules;
using HexAdventureMapper.Database.WorkingClasses;

namespace HexAdventureMapper.Database
{
    public static class DbUpdater
    {
        private const long CurrentCampaignDbVersion = 3;
        private const long CurrentMapDbVersion = 3;

        public static void CheckForMapDbSchemaUpdates(IDbInstance db, DbHex hexes, DbHexConnection hexConnections)
        {
            long version = db.GetVersion();

            if (version == 0)
            {
                db.CreateTables(new IDbModule[] { hexes, hexConnections });
            }
            else
            {
                if (version <= 1)
                {
                    db.AlterAddColumn(hexes.TableName, DbHex.PlayerIcons, DbColumn.Text, true, "'0'");
                }
                if (version <= 2)
                {
                    db.AlterAddColumn(hexes.TableName, DbHex.FogOfWar, DbColumn.Integer, true, "0");
                }
            }
            

            db.SetVersion(CurrentMapDbVersion);
        }

        public static void CheckForCampaignDbSchemaUpdates(IDbInstance db, DbParty party, DbSession session)
        {
            long version = db.GetVersion();

            if (version == 0)
            {
                db.CreateTables(new IDbModule[] { party });
                party.CreateDefault();
            }
            if (version <= 1)
            {
                db.CreateTables(new IDbModule[] { session });

                session.CreateDefault();
            }
            if (version == 2)
            {
                db.AlterAddColumn(session.TableName, DbSession.Year, DbColumn.Integer, true, "382");
                db.AlterAddColumn(session.TableName, DbSession.Day, DbColumn.Integer, true, "218");
                db.AlterAddColumn(session.TableName, DbSession.Minutes, DbColumn.Integer, true, "1080");
            }

            db.SetVersion(CurrentCampaignDbVersion);
        }
    }
}
