using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.TileConfig
{
    public class TileConfigInterface
    {
        List<TileComponent> _terrain;
        List<TileComponent> _vegetation;
        List<TileComponent> _icons;

        public TileConfigInterface()
        {
            _terrain = new List<TileComponent>();
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 1, Name = "Sea", ImageLocation = "Images/Transparent.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 0, Name = "Plains", ImageLocation = "Images/Transparent.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 2, Name = "Hills", ImageLocation = "Images/Hills.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 3, Name = "Mountains", ImageLocation = "Images/Mountains.png" });

            _vegetation = new List<TileComponent>();
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 1, Name = "Grassland", ImageLocation = "Images/Grassland.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 2, Name = "Copse", ImageLocation = "Images/Copse.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 3, Name = "Forest", ImageLocation = "Images/Forest.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 0, Name = "None", ImageLocation = "Images/Transparent.png" });

            _icons = new List<TileComponent>();
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 0, Name = "None", ImageLocation = "Images/Transparent.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 1, Name = "Structure", ImageLocation = "Images/IconStructure.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 2, Name = "Ruin", ImageLocation = "Images/IconRuin.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 3, Name = "Landmark", ImageLocation = "Images/IconLandmark.png" });
        }

        public List<TileComponent> GetTerrain()
        {
            return _terrain;
        }

        public TileComponent GetTerrain(int id)
        {
            return _terrain.First(T => T.Id.Equals(id));
        }

        public TileComponent GetTerrain(string name)
        {
            return _terrain.First(T => T.Name.Equals(name));
        }

        public List<TileComponent> GetVegetation()
        {
            return _vegetation;
        }

        public TileComponent GetVegetation(int id)
        {
            return _vegetation.First(T => T.Id.Equals(id));
        }

        public TileComponent GetVegetation(string name)
        {
            return _vegetation.First(T => T.Name.Equals(name));
        }

        public List<TileComponent> GetIcons()
        {
            return _icons;
        }

        public TileComponent GetIcon(int id)
        {
            return _icons.First(T => T.Id.Equals(id));
        }

        public TileComponent GetIcon(string name)
        {
            return _icons.First(T => T.Name.Equals(name));
        }
    }
}
