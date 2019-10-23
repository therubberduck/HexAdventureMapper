using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database;
using HexAdventureMapper.Database.Modules;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper
{
    public delegate void SearchResultSelectedHandler(HexCoordinate searchCoordinate);
    
    public class SearchWindowHandler
    {
        public DbHex Db { get; private set; }

        public SearchWindowHandler(DbHex db)
        {
            Db = db;
        }

        public HexCoordinate SelectedCoordinate { get; set; }

        public event SearchResultSelectedHandler SearchResultSelected;

        public void TriggerSearchResult(HexCoordinate hexCoordinate)
        {
            SearchResultSelected?.Invoke(hexCoordinate);
        }
    }
}
