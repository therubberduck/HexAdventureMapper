using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexAdventureMapper.DataObjects
{
    public class TileComponent
    {
        public enum Type
        {
            Terrain,
            Vegetation,
            Icon
        };

        public Type TileType;
        public int Id;
        public string Name;
        public string ImageLocation;
    }
}
