using System.Diagnostics;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.Views;

namespace HexAdventureMapper.Painting
{
    public class Painter
    {
        private readonly IPainterUi _uiInterface;
        private readonly DbInterface _db;

        public Painter(IPainterUi uiInterface, DbInterface db)
        {
            _uiInterface = uiInterface;
            _db = db;
        }

        public bool TryPaint(MapEventArgs e)
        {
            MainWindow.DrawingTools drawingTool = _uiInterface.GetDrawingTool();
            if (drawingTool == MainWindow.DrawingTools.Terrain)
            {
                PaintTerrain(e.HexWorldCoordinate);
            }
            else if (drawingTool == MainWindow.DrawingTools.GmIcons)
            {
                PaintIcon(e.HexWorldCoordinate);
            }
            else if (drawingTool == MainWindow.DrawingTools.PlayerIcons)
            {
                PaintPlayerIcon(e.HexWorldCoordinate);
            }
            else if (drawingTool == MainWindow.DrawingTools.River)
            {
                return PaintRiver(e.HexWorldCoordinate, e.PartOfHexClicked);
            }
            else if (drawingTool == MainWindow.DrawingTools.Road)
            {
                return PaintRoad(e.HexWorldCoordinate, e.PartOfHexClicked);
            }
            else
            {
                return false;
            }
            return true;
        }

        public bool TryRemove(MapEventArgs e)
        {
            MainWindow.DrawingTools drawingTool = _uiInterface.GetDrawingTool();
            if (drawingTool == MainWindow.DrawingTools.Terrain)
            {
                ClearTerrain(e.HexWorldCoordinate);
            }
            else if (drawingTool == MainWindow.DrawingTools.GmIcons)
            {
                ClearIcons(e.HexWorldCoordinate);
            }
            else if (drawingTool == MainWindow.DrawingTools.PlayerIcons)
            {
                ClearPlayerIcons(e.HexWorldCoordinate);
            }
            else if (drawingTool == MainWindow.DrawingTools.River)
            {
                return RemoveRiver(e.HexWorldCoordinate, e.PartOfHexClicked);
            }
            else if (drawingTool == MainWindow.DrawingTools.Road)
            {
                return RemoveRoad(e.HexWorldCoordinate, e.PartOfHexClicked);
            }
            else
            {
                return false;
            }
            return true;
        }

        public void PaintTerrain(HexCoordinate worldCoordinate)
        {
            int terrainId = _uiInterface.GetTerrainId();
            int vegetationId = _uiInterface.GetVegetationId();

            if (_db.Hexes.HexExists(worldCoordinate))
            {
                _db.Hexes.UpdateTerrain(worldCoordinate, terrainId, vegetationId);
            }
            else
            {
                _db.Hexes.Create(worldCoordinate, terrainId, vegetationId);
            }
        }

        public void PaintIcon(HexCoordinate worldCoordinate)
        {
            int iconId = _uiInterface.GetIconId();

            if (!_db.Hexes.HexExists(worldCoordinate))
            {
                _db.Hexes.Create(worldCoordinate, 0, 0);
            }
            _db.Hexes.UpdateIcon(worldCoordinate, iconId);
        }

        public void PaintPlayerIcon(HexCoordinate worldCoordinate)
        {
            int iconId = _uiInterface.GetPlayerIconId();

            if (!_db.Hexes.HexExists(worldCoordinate))
            {
                _db.Hexes.Create(worldCoordinate, 0, 0);
            }
            _db.Hexes.UpdatePlayerIcon(worldCoordinate, iconId);
        }

        public bool PaintRiver(HexCoordinate worldCoordinate, Direction direction)
        {
            return DrawConnection(worldCoordinate, direction, _uiInterface.GetRiverId());
        }

        public bool PaintRoad(HexCoordinate worldCoordinate, Direction direction)
        {
            return DrawConnection(worldCoordinate, direction, _uiInterface.GetRoadId());
        }

        private void ClearTerrain(HexCoordinate worldCoordinate)
        {
            if (_db.Hexes.HexExists(worldCoordinate))
            {
                _db.Hexes.ClearTerrain(worldCoordinate);
            }
        }

        private void ClearIcons(HexCoordinate worldCoordinate)
        {
            if (_db.Hexes.HexExists(worldCoordinate))
            {
                _db.Hexes.ClearIcons(worldCoordinate);
            }
        }

        private void ClearPlayerIcons(HexCoordinate worldCoordinate)
        {
            if (_db.Hexes.HexExists(worldCoordinate))
            {
                _db.Hexes.ClearPlayerIcons(worldCoordinate);
            }
        }

        public bool RemoveRiver(HexCoordinate worldCoordinate, Direction direction)
        {
            return RemoveConnection(worldCoordinate, direction, _uiInterface.GetRiverId());
        }

        public bool RemoveRoad(HexCoordinate worldCoordinate, Direction direction)
        {
            return RemoveConnection(worldCoordinate, direction, _uiInterface.GetRoadId());
        }

        private bool DrawConnection(HexCoordinate worldCoordinate, Direction direction, int type)
        {
            if (direction != Direction.None)
            {
                _db.HexConnections.Create(worldCoordinate, type, direction);
                HexCoordinate mapNeighborCoordinate = DirectionManager.NeighborTo(worldCoordinate, direction);
                Debug.WriteLine("First is X: " + worldCoordinate.X + " Y: " + worldCoordinate.Y);
                Debug.WriteLine("Neighbor is X: " + mapNeighborCoordinate.X + " Y: " + mapNeighborCoordinate.Y);
                Direction oppositeDirection = DirectionManager.OppositeDirection(direction);
                _db.HexConnections.Create(mapNeighborCoordinate, type, oppositeDirection);
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool RemoveConnection(HexCoordinate worldCoordinate, Direction direction, int type)
        {
            if (direction != Direction.None)
            {
                _db.HexConnections.Remove(worldCoordinate, direction, type);
                HexCoordinate mapNeighborCoordinate = DirectionManager.NeighborTo(worldCoordinate, direction);
                Direction oppositeDirection = DirectionManager.OppositeDirection(direction);
                _db.HexConnections.Remove(mapNeighborCoordinate, oppositeDirection, type);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
