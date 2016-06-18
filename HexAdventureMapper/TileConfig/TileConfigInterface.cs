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
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 2, Name = "Hills", ImageLocation = "Images/THills.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 3, Name = "Mountains", ImageLocation = "Images/TMountains.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 4, Name = "Volcano", ImageLocation = "Images/TVolcano.png" });

            _vegetation = new List<TileComponent>();
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 1, Name = "Grassland", ImageLocation = "Images/VGrassland.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 4, Name = "Farmland", ImageLocation = "Images/VFarmland.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 2, Name = "Copse", ImageLocation = "Images/VCopse.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 3, Name = "Forest", ImageLocation = "Images/VForest.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 5, Name = "Coniferous Copse", ImageLocation = "Images/VCCopse.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 6, Name = "Coniferous Forest", ImageLocation = "Images/VCForest.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 7, Name = "Jungle", ImageLocation = "Images/VJungle.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 8, Name = "Swamp", ImageLocation = "Images/VSwamp.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 9, Name = "Desert", ImageLocation = "Images/VDesert.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 10, Name = "Rocky", ImageLocation = "Images/VRocky.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegatation, Id = 0, Name = "None", ImageLocation = "Images/Transparent.png" });

            _icons = new List<TileComponent>();
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 0, Name = "None", ImageLocation = "Images/Transparent.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 1, Name = "Structure", ImageLocation = "Images/IcStructure.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 9, Name = "Hamlet", ImageLocation = "Images/IcHamlet.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 18, Name = "Village", ImageLocation = "Images/IcVillage.png" }); ;
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 17, Name = "Town", ImageLocation = "Images/IcTown.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 6, Name = "City", ImageLocation = "Images/IcCity.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 3, Name = "Landmark, Small", ImageLocation = "Images/IcLandmarkSmall.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 11, Name = "Landmark, Large", ImageLocation = "Images/IcLandmarkLarge.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 10, Name = "Landmark, Huge", ImageLocation = "Images/IcLandmarkHuge.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 7, Name = "Flags", ImageLocation = "Images/IcFlags.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 12, Name = "Monument", ImageLocation = "Images/IcMonument.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 5, Name = "Cave", ImageLocation = "Images/IcCave.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 2, Name = "Ruin", ImageLocation = "Images/IcRuinStructure.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 15, Name = "Ruined Tower", ImageLocation = "Images/IcRuinTower.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 14, Name = "Ruined Settlement", ImageLocation = "Images/IcRuinSettlement.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 13, Name = "Ruined City", ImageLocation = "Images/IcRuinCity.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 16, Name = "Tower", ImageLocation = "Images/IcTower.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 8, Name = "Fort", ImageLocation = "Images/IcFort.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 4, Name = "Castle", ImageLocation = "Images/IcCastle.png" });
        }

        public List<TileComponent> GetTerrain()
        {
            return _terrain;
        }

        public string[] GetTerrainNames()
        {
            return _terrain.ConvertAll(x => x.Name).ToArray();
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

        public string[] GetVegetationNames()
        {
            return _vegetation.ConvertAll(x => x.Name).ToArray();
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

        public string[] GetIconNames()
        {
            return _icons.ConvertAll(x => x.Name).ToArray();
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
