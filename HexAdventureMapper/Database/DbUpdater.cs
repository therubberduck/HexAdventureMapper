using HexAdventureMapper.Database.Modules;
using HexAdventureMapper.Database.WorkingClasses;

namespace HexAdventureMapper.Database
{
    public static class DbUpdater
    {
        private const long CurrentVersion = 2;

        public static void CheckForDbSchemaUpdates(IDbInstance db, DbHex hexes, DbHexConnection hexConnections)
        {
            long version = db.GetVersion();

            if (version == 0)
            {
                //db.CreateTables(new IDbModule[] { hexes, hexConnections });
            }
            if (version <= 1)
            {
                db.AlterAddColumn(hexes.TableName, DbHex.PlayerIcons, DbColumn.Text, true, "'0'");
            }

            db.SetVersion(CurrentVersion);
        }
    }
}
