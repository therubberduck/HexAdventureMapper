using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Views;
using HexAdventureMapper.Visualizer;

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
            else if (drawingTool == MainWindow.DrawingTools.Icons)
            {
                PaintIcon(e.HexWorldCoordinate);
            }
            else if (drawingTool == MainWindow.DrawingTools.River)
            {
                PaintRiver(e.HexWorldCoordinate, e.PartOfHexClicked);
            }
            else if (drawingTool == MainWindow.DrawingTools.Road)
            {
                PaintRoad(e.HexWorldCoordinate, e.PartOfHexClicked);
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
            else if (drawingTool == MainWindow.DrawingTools.Icons)
            {
                ClearIcons(e.HexWorldCoordinate);
            }
            else if (drawingTool == MainWindow.DrawingTools.River)
            {
                RemoveRiver(e.HexWorldCoordinate, e.PartOfHexClicked);
            }
            else if (drawingTool == MainWindow.DrawingTools.Road)
            {
                RemoveRoad(e.HexWorldCoordinate, e.PartOfHexClicked);
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

        public void PaintRiver(HexCoordinate worldCoordinate, Direction direction)
        {
            DrawConnection(worldCoordinate, direction, _uiInterface.GetRiverId());
        }

        public void PaintRoad(HexCoordinate worldCoordinate, Direction direction)
        {
            DrawConnection(worldCoordinate, direction, _uiInterface.GetRoadId());
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

        public void RemoveRiver(HexCoordinate worldCoordinate, Direction direction)
        {
            RemoveConnection(worldCoordinate, direction, _uiInterface.GetRiverId());
        }

        public void RemoveRoad(HexCoordinate worldCoordinate, Direction direction)
        {
            RemoveConnection(worldCoordinate, direction, _uiInterface.GetRoadId());
        }

        private void DrawConnection(HexCoordinate worldCoordinate, Direction direction, int type)
        {
            if (direction != Direction.None)
            {
                _db.HexConnections.Create(worldCoordinate, type, direction);
                HexCoordinate mapNeighborCoordinate = PositionManager.NeighborTo(worldCoordinate, direction);
                Debug.WriteLine("First is X: " + worldCoordinate.X + " Y: " + worldCoordinate.Y);
                Debug.WriteLine("Neighbor is X: " + mapNeighborCoordinate.X + " Y: " + mapNeighborCoordinate.Y);
                Direction oppositeDirection = PositionManager.OppositeDirection(direction);
                _db.HexConnections.Create(mapNeighborCoordinate, type, oppositeDirection);
            }
        }

        private void RemoveConnection(HexCoordinate worldCoordinate, Direction direction, int type)
        {
            if (direction != Direction.None)
            {
                _db.HexConnections.Remove(worldCoordinate, direction);
                HexCoordinate mapNeighborCoordinate = PositionManager.NeighborTo(worldCoordinate, direction);
                Direction oppositeDirection = PositionManager.OppositeDirection(direction);
                _db.HexConnections.Remove(mapNeighborCoordinate, oppositeDirection);
            }
        }
    }
}
