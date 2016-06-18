using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database.WorkingClasses;
using HexAdventureMapper.Visualizer;

namespace HexAdventureMapper.DataObjects
{
    public class Hex
    {
        public long Id { get; set; }
        public HexCoordinate Coordinate { get; set; }
        public int TerrainId { get; set; }
        public int VegetationId { get; set; }
        public List<int> Icons { get; set; }
        public List<int> PlayerIcons { get; set; }

        public int FogOfWar { get; set; }

        public List<HexConnection> RiverSections { get; set; } 
        public Point RiverOffset { get; set; }

        public List<HexConnection> RoadSections { get; set; } 
        public Point RoadOffset { get; set; }

        public string Detail { get; set; }
    }
}
