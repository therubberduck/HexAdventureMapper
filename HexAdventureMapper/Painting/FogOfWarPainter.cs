using System.Collections.Generic;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.TileConfig;

namespace HexAdventureMapper.Painting
{
    public class FogOfWarPainter
    {
        private readonly IFogOfWarUi _uiInterface;
        private readonly DbInterface _db;

        public FogOfWarPainter(IFogOfWarUi uiInterface, DbInterface db)
        {
            _uiInterface = uiInterface;
            _db = db;
        }
        
        public void PaintFogOfWar(HexCoordinate worldCoordinate)
        {
            int fogId = _uiInterface.GetFogOfWarId();

            if (_db.Hexes.HexExists(worldCoordinate))
            {
                _db.Hexes.UpdateFogOfWar(worldCoordinate, fogId);
            }
        }

        public void RemoveFogOfWar(HexCoordinate worldCoordinate)
        {
            if (_db.Hexes.HexExists(worldCoordinate))
            {
                _db.Hexes.UpdateFogOfWar(worldCoordinate, TileId.NoFogOfWar);
            }
        }

        public void ClearFogofWarAround(HexCoordinate worldCoordinate)
        {
            List<Hex> revealArea = _db.Hexes.GetForCoordinates(DirectionManager.GetTwoStepAreaAround(worldCoordinate));

            _db.Hexes.UpdateFogOfWar(worldCoordinate, TileId.NoFogOfWar);

            Hex centerHex = revealArea.Find(h => Equals(h.Coordinate, worldCoordinate));

            if (centerHex == null)
            {
                return;
            }

            Hex northHex = DirectionManager.GetHexNeighbor(revealArea, centerHex, Direction.North);
            SetOuterHexFogOfWar(revealArea, centerHex, northHex, Direction.North);

            Hex northEastHex = DirectionManager.GetHexNeighbor(revealArea, centerHex, Direction.NorthEast);
            SetOuterHexFogOfWar(revealArea, centerHex, northEastHex, Direction.NorthEast);

            Hex southEastHex = DirectionManager.GetHexNeighbor(revealArea, centerHex, Direction.SouthEast);
            SetOuterHexFogOfWar(revealArea, centerHex, southEastHex, Direction.SouthEast);

            Hex southHex = DirectionManager.GetHexNeighbor(revealArea, centerHex, Direction.South);
            SetOuterHexFogOfWar(revealArea, centerHex, southHex, Direction.South);

            Hex southWestHex = DirectionManager.GetHexNeighbor(revealArea, centerHex, Direction.SouthWest);
            SetOuterHexFogOfWar(revealArea, centerHex, southWestHex, Direction.SouthWest);

            Hex northWestHex = DirectionManager.GetHexNeighbor(revealArea, centerHex, Direction.NorthWest);
            SetOuterHexFogOfWar(revealArea, centerHex, northWestHex, Direction.NorthWest);

            //Reveal inner hexes, based on the outer hexes revealed
            SetInnerHexFogOfWar(revealArea, northHex, Direction.North);
            SetInnerHexFogOfWar(revealArea, northEastHex, Direction.NorthEast);
            SetInnerHexFogOfWar(revealArea, southEastHex, Direction.SouthEast);
            SetInnerHexFogOfWar(revealArea, southHex, Direction.South);
            SetInnerHexFogOfWar(revealArea, southWestHex, Direction.SouthWest);
            SetInnerHexFogOfWar(revealArea, northWestHex, Direction.NorthWest);

            _db.Hexes.UpdateFogOfWar(revealArea);
        }

        public void SetOuterHexFogOfWar(List<Hex> hexes, Hex startingHex, Hex innerHex, Direction innerDirection)
        {
            if (innerHex == null)
            {
                return;
            }

            var outerDirections = DirectionManager.OuterDirectionsForDirection(innerDirection);
            foreach (var direction in outerDirections)
            {
                Hex outerHex = DirectionManager.GetHexNeighbor(hexes, innerHex, direction);
                SetOuterHexFogOfWar(innerHex, outerHex, startingHex);
            }
        }

        public void SetOuterHexFogOfWar(Hex innerHex, Hex outerHex, Hex startingHex)
        {
            if (innerHex == null || outerHex == null || startingHex == null)
            {
                return;
            }

            if (outerHex.FogOfWar == TileId.PartialFogOfWar || outerHex.FogOfWar == TileId.NoFogOfWar)
            {
                //Fog of war has already been removed as much as it can
                return;
            }

            if (startingHex.TerrainId == TileId.TerrainMountains || startingHex.TerrainId == TileId.TerrainVolcano)
            {
                //View from mountains see past everything, except other mountains
                if (innerHex.TerrainId != TileId.TerrainMountains && innerHex.TerrainId != TileId.TerrainVolcano)
                {
                    outerHex.FogOfWar = TileId.PartialFogOfWar;
                }
            }
            else if (startingHex.TerrainId == TileId.TerrainHills)
            {
                //View from hills see past lower-lying plains and water
                if (innerHex.TerrainId == TileId.TerrainPlains || innerHex.TerrainId == TileId.TerrainSea)
                {
                    outerHex.FogOfWar = TileId.PartialFogOfWar;
                }
                //Also, if outer hex is taller than inner hex, we also see it
                else if (innerHex.TerrainId == TileId.TerrainHills &&
                         (outerHex.TerrainId == TileId.TerrainMountains || outerHex.TerrainId == TileId.TerrainVolcano))
                {
                    outerHex.FogOfWar = TileId.PartialFogOfWar;
                }
                //Otherwise the neighboring hills or mountains block the view
            }
            //
            //All starting terrain from here on are plains or water
            //

            //If outer hex is taller than inner hex, we also see it
            else if (innerHex.TerrainId == TileId.TerrainHills &&
                         (outerHex.TerrainId == TileId.TerrainMountains || outerHex.TerrainId == TileId.TerrainVolcano))
            {
                outerHex.FogOfWar = TileId.PartialFogOfWar;
            }
            else if ((innerHex.TerrainId == TileId.TerrainPlains || innerHex.TerrainId == TileId.TerrainSea) &&
                         (outerHex.TerrainId != TileId.TerrainPlains && outerHex.TerrainId != TileId.TerrainSea))
            {
                outerHex.FogOfWar = TileId.PartialFogOfWar;
            }
            //We can't see past forests of same elevation, but otherwise we are golden
            else if ((innerHex.TerrainId == TileId.TerrainPlains || innerHex.TerrainId == TileId.TerrainSea) 
                && (innerHex.VegetationId != TileId.VegForest && innerHex.VegetationId != TileId.VegConForest && innerHex.VegetationId != TileId.VegJungle))
            {
                outerHex.FogOfWar = TileId.PartialFogOfWar;
            }
        }

        public void SetInnerHexFogOfWar(List<Hex> hexes, Hex innerHex, Direction innerDirection)
        {
            if (innerHex == null)
            {
                return;
            }

            bool allOuterHexesRevealed = true;

            var outerDirections = DirectionManager.OuterDirectionsForDirection(innerDirection);
            foreach (var outerDirection in outerDirections)
            {
                Hex outerHex = DirectionManager.GetHexNeighbor(hexes, innerHex, outerDirection);
                if (outerHex == null || outerHex.FogOfWar == TileId.FullFogOfWar)
                {
                    allOuterHexesRevealed = false;
                }
            }
            if (allOuterHexesRevealed)
            {
                innerHex.FogOfWar = TileId.NoFogOfWar;
            }
            else
            {
                innerHex.FogOfWar = TileId.PartialFogOfWar;
            }
        }
    }
}
