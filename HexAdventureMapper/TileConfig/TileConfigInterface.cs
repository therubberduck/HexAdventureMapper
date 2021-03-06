﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.TileConfig
{
    public class TileConfigInterface
    {
        public const int HexWidth = 50;
        public const int HexHeight = 44;

        List<TileComponent> _terrain;
        List<TileComponent> _vegetation;
        List<TileComponent> _icons;

        public TileConfigInterface()
        {
            _imageCache = new Dictionary<string, Image>();

            _terrain = new List<TileComponent>();
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 1, Name = "Sea", ImageLocation = "Images/Transparent.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 0, Name = "Plains", ImageLocation = "Images/Transparent.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 2, Name = "Hills", ImageLocation = "Images/THills.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 3, Name = "Mountains", ImageLocation = "Images/TMountains.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = 4, Name = "Volcano", ImageLocation = "Images/TVolcano.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = TileId.TerrainSolidRock, Name = "Solid Rock", ImageLocation = "Images/Transparent.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = TileId.TerrainTunnels, Name = "Cave Tunnels", ImageLocation = "Images/TTunnels.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = TileId.TerrainSmallCave, Name = "Small Cave", ImageLocation = "Images/TSmallCave.png" });
            _terrain.Add(new TileComponent { TileType = TileComponent.Type.Terrain, Id = TileId.TerrainLargeCave, Name = "Large Cave", ImageLocation = "Images/TCave.png" });

            _vegetation = new List<TileComponent>();
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 1, Name = "Grassland", ImageLocation = "Images/VGrassland.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 4, Name = "Farmland", ImageLocation = "Images/VFarmland.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 2, Name = "Copse", ImageLocation = "Images/VCopse.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 3, Name = "Forest", ImageLocation = "Images/VForest.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 5, Name = "Coniferous Copse", ImageLocation = "Images/VCCopse.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 6, Name = "Coniferous Forest", ImageLocation = "Images/VCForest.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 7, Name = "Jungle", ImageLocation = "Images/VJungle.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 8, Name = "Swamp", ImageLocation = "Images/VSwamp.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 9, Name = "Desert", ImageLocation = "Images/VDesert.png" });
            _vegetation.Add(new TileComponent {TileType = TileComponent.Type.Vegetation, Id = TileId.VegSnow, Name = "Snow", ImageLocation = "Images/VSnow.png"});
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 10, Name = "Rocky", ImageLocation = "Images/VRocky.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = TileId.VegMushCopse, Name = "Mushroom Copse", ImageLocation = "Images/VMCopse.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = TileId.VegMushForest, Name = "Mushroom Forest", ImageLocation = "Images/VMForest.png" });
            _vegetation.Add(new TileComponent { TileType = TileComponent.Type.Vegetation, Id = 0, Name = "None", ImageLocation = "Images/Transparent.png" });

            _icons = new List<TileComponent>();
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 0, Name = "None", ImageLocation = "Images/Transparent.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 1, Name = "Structure", ImageLocation = "Images/IcStructure.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 9, Name = "Hamlet", ImageLocation = "Images/IcHamlet.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 18, Name = "Village", ImageLocation = "Images/IcVillage.png" }); ;
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 17, Name = "Town", ImageLocation = "Images/IcTown.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 6, Name = "City", ImageLocation = "Images/IcCity.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = TileId.StrMining, Name = "Mining", ImageLocation = "Images/IcMining.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 3, Name = "Landmark, Small", ImageLocation = "Images/IcLandmarkSmall.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 11, Name = "Landmark, Large", ImageLocation = "Images/IcLandmarkLarge.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 10, Name = "Landmark, Huge", ImageLocation = "Images/IcLandmarkHuge.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 12, Name = "Monument", ImageLocation = "Images/IcMonument.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = TileId.StrHut, Name = "Hut", ImageLocation = "Images/IcHut.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = TileId.StrTribe, Name = "Tribe", ImageLocation = "Images/IcTribe.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 5, Name = "Cave", ImageLocation = "Images/IcCave.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 2, Name = "Ruin", ImageLocation = "Images/IcRuinStructure.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 15, Name = "Ruined Tower", ImageLocation = "Images/IcRuinTower.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = TileId.StrRuinedFort, Name = "Ruined Fort", ImageLocation = "Images/IcRuinFort.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 14, Name = "Ruined Settlement", ImageLocation = "Images/IcRuinSettlement.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 13, Name = "Ruined City", ImageLocation = "Images/IcRuinCity.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 19, Name = "Lake", ImageLocation = "Images/IcLake.png" });
            _icons.Add(new TileComponent { TileType = TileComponent.Type.Icon, Id = 7, Name = "Flags", ImageLocation = "Images/IcFlags.png" });
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

        private Dictionary<string, Image> _imageCache;

        public Image GetImage(string imageLocation)
        {
            if (!_imageCache.ContainsKey(imageLocation))
            {
                _imageCache[imageLocation] = Image.FromFile(imageLocation);
            }
            var image = _imageCache[imageLocation];
            return image.Clone() as Bitmap;
        }
    }
}
