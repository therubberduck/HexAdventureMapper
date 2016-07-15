using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;
using HexAdventureMapper.Visualizer.LayerDrawers;

namespace HexAdventureMapper.Visualizer
{
    public class DrawingHandler
    {
        private readonly IDrawingUi _drawingUi;

        private readonly TerrainLayerDrawer _terrainLayerDrawer;
        private readonly RiverLayerDrawer _riverLayerDrawer;
        private readonly RoadLayerDrawer _roadLayerDrawer;
        private readonly GmIconLayerDrawer _gmIconLayerDrawer;
        private readonly PlayerIconLayerDrawer _playerIconLayerDrawer;
        private readonly FogOfWarLayerDrawer _fogOfWarLayerDrawer;
        private readonly SelectLayerDrawer _selectLayerDrawer;
        private readonly PartyLayerDrawer _partyLayerDrawer;
        private readonly OverlayGridLayerDrawer _overlayGridLayerDrawer;

        private readonly List<BaseLayerDrawer> _layerDrawers;
        
        public DrawingHandler(IDrawingUi drawingUi, TileConfigInterface tiles, DbInterface db)
        {
            _drawingUi = drawingUi;

            _terrainLayerDrawer = new TerrainLayerDrawer(drawingUi, tiles, db);
            _riverLayerDrawer = new RiverLayerDrawer(drawingUi, tiles, db);
            _roadLayerDrawer = new RoadLayerDrawer(drawingUi, tiles, db);
            _gmIconLayerDrawer = new GmIconLayerDrawer(drawingUi, tiles, db);
            _playerIconLayerDrawer = new PlayerIconLayerDrawer(drawingUi, tiles, db);
            _fogOfWarLayerDrawer = new FogOfWarLayerDrawer(drawingUi, tiles, db);
            _selectLayerDrawer = new SelectLayerDrawer(drawingUi, tiles, db);
            _partyLayerDrawer = new PartyLayerDrawer(drawingUi);
            _overlayGridLayerDrawer = new OverlayGridLayerDrawer(drawingUi);

            _layerDrawers = new List<BaseLayerDrawer>
            {
                _terrainLayerDrawer, _riverLayerDrawer, _roadLayerDrawer, _gmIconLayerDrawer,
                _playerIconLayerDrawer, _fogOfWarLayerDrawer
            };
        }

        public void DrawMap()
        {
            MapBox mapBox = _drawingUi.GetMapBox();

            var alphaList = GetAllAlphaValues();

            for (int i = 0; i < _layerDrawers.Count; i++)
            {
                var layerDrawer = _layerDrawers[i];
                mapBox.UpdateLayer(layerDrawer.GetLayerType(), layerDrawer.MakeLocalMap(alphaList[i]));
            }
            mapBox.UpdateLayer(Layer.OverlayGrid, _overlayGridLayerDrawer.DrawOverlay());
        }

        public void RedrawLayer(Layer layer)
        {
            MapBox mapBox = _drawingUi.GetMapBox();

            var alphaList = GetAllAlphaValues();

            var layerDrawer = _layerDrawers[(int)layer];
            mapBox.UpdateLayer(layerDrawer.GetLayerType(), layerDrawer.MakeLocalMap(alphaList[(int)layer]));
        }

        public void RedrawArea(HexCoordinate centerCoordinate)
        {
            MapBox mapBox = _drawingUi.GetMapBox();

            var alphaList = GetAllAlphaValues();

            for (int i = 0; i < _layerDrawers.Count; i++)
            {
                var layerDrawer = _layerDrawers[i];
                Layer layerType = layerDrawer.GetLayerType();
                Image oldMap = mapBox.GetLayer(layerType);
                if (oldMap != null)
                {
                    mapBox.UpdateLayer(layerType, _terrainLayerDrawer.RedrawArea(centerCoordinate, oldMap, alphaList[i]));
                }
            }
        }

        public void RedrawFogOfWar()
        {
            Image newFogOfWarMap = _fogOfWarLayerDrawer.MakeLocalMap(_drawingUi.GetFogOfWarIconAlpha());
            _drawingUi.GetMapBox().UpdateLayer(Layer.FogOfWar, newFogOfWarMap);
        }

        public void RedrawSelectedHex(HexCoordinate selectedCoordinate)
        {
            MapBox mapBox = _drawingUi.GetMapBox();
            Bitmap map = new Bitmap(mapBox.Width, mapBox.Height);
            Image newSelectedMap = _selectLayerDrawer.RedrawHex(selectedCoordinate, map, 0);
            mapBox.UpdateLayer(Layer.Selection, newSelectedMap);
        }

        public void RedrawPartyLocation(HexCoordinate partyLocation)
        {
            _partyLayerDrawer.UpdatePartyLocation(partyLocation);
        }

        public void RedrawHex(HexCoordinate worldCoordinate, Layer layer)
        {
            MapBox mapBox = _drawingUi.GetMapBox();

            var alphaList = GetAllAlphaValues();

            Image mapLayer = mapBox.GetLayer(layer);
            if (mapLayer != null)
            {
                int alpha = alphaList[(int)layer];
                mapBox.UpdateLayer(layer, _layerDrawers[(int)layer].RedrawHex(worldCoordinate, mapLayer, alpha));
            }
        }

        private List<int> GetAllAlphaValues()
        {
            return new List<int> {0, 0, 0, _drawingUi.GetGmIconAlpha(), _drawingUi.GetPlayerIconAlpha(), _drawingUi.GetFogOfWarIconAlpha(), _drawingUi.GetOverlayGridAlpha(), _drawingUi.GetPlayerIconAlpha(), 0};
        }
    }
}
