﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        private BackgroundWorker _backgroundWorker;

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

        private readonly string _handlerTag;
        
        public DrawingHandler(string tag, IDrawingUi drawingUi, TileConfigInterface tiles, DbInterface db)
        {
            _handlerTag = tag;

            _drawingUi = drawingUi;

            _terrainLayerDrawer = new TerrainLayerDrawer(drawingUi, tiles, db);
            _riverLayerDrawer = new RiverLayerDrawer(drawingUi, tiles, db);
            _roadLayerDrawer = new RoadLayerDrawer(drawingUi, tiles, db);
            _gmIconLayerDrawer = new GmIconLayerDrawer(drawingUi, tiles, db);
            _playerIconLayerDrawer = new PlayerIconLayerDrawer(drawingUi, tiles, db);
            _fogOfWarLayerDrawer = new FogOfWarLayerDrawer(drawingUi, tiles, db);
            _selectLayerDrawer = new SelectLayerDrawer(drawingUi, tiles, db);
            _partyLayerDrawer = new PartyLayerDrawer(drawingUi, db);
            _overlayGridLayerDrawer = new OverlayGridLayerDrawer(drawingUi);

            _layerDrawers = new List<BaseLayerDrawer>
            {
                _terrainLayerDrawer, _riverLayerDrawer, _roadLayerDrawer, _gmIconLayerDrawer,
                _playerIconLayerDrawer, _fogOfWarLayerDrawer
            };
        }

        public void DrawMap()
        {
            _drawingUi.StartBusyIndicator();
            
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += DrawMapAsynchronously;
            _backgroundWorker.RunWorkerCompleted += DrawMapAsynchronouslyFinished;
            _backgroundWorker.RunWorkerAsync();
        }

        private void DrawMapAsynchronously(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            MapBox mapBox = _drawingUi.GetMapBox();

            var alphaList = GetAllAlphaValues();
            
            for (int i = 0; i < _layerDrawers.Count; i++)
            {
                var layerDrawer = _layerDrawers[i];
                if (alphaList[i] == 0)
                {
                    mapBox.UpdateLayer(layerDrawer.GetLayerType(), null);
                }
                else
                {
                    var layerImage = layerDrawer.MakeLocalMap(_handlerTag, alphaList[i]);
                    if (layerImage != null)
                    {
                        mapBox.UpdateLayer(layerDrawer.GetLayerType(), layerImage);
                    }
                }
            }
            _partyLayerDrawer.RedrawPartyLocation();
            mapBox.UpdateLayer(Layer.OverlayGrid, _overlayGridLayerDrawer.DrawOverlay());
            
            mapBox.RedrawMap();
        }

        public void DrawMapAsynchronouslyFinished(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            _drawingUi.StopBusyIndicator();
        }

        public void RedrawLayer(Layer layer)
        {
            MapBox mapBox = _drawingUi.GetMapBox();

            var alphaList = GetAllAlphaValues();

            var layerDrawer = _layerDrawers[(int)layer];
            mapBox.UpdateLayerAndMap(layerDrawer.GetLayerType(), layerDrawer.MakeLocalMap(_handlerTag, alphaList[(int)layer]));
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
            mapBox.RedrawMap();
        }

        public void RedrawFogOfWar()
        {
            Image newFogOfWarMap = _fogOfWarLayerDrawer.MakeLocalMap(_handlerTag, _drawingUi.GetFogOfWarIconAlpha(), false);
            _drawingUi.GetMapBox().UpdateLayerAndMap(Layer.FogOfWar, newFogOfWarMap);
        }

        public void RedrawSelectedHex(HexCoordinate selectedCoordinate)
        {
            MapBox mapBox = _drawingUi.GetMapBox();
            Bitmap map = new Bitmap(mapBox.Width, mapBox.Height);
            Image newSelectedMap = _selectLayerDrawer.RedrawHex(selectedCoordinate, map, 0);
            mapBox.UpdateLayerAndMap(Layer.Selection, newSelectedMap);
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
                mapBox.UpdateLayerAndMap(layer, _layerDrawers[(int)layer].RedrawHex(worldCoordinate, mapLayer, alpha));
            }
        }

        private List<int> GetAllAlphaValues()
        {
            return new List<int> {100, 100, 100, _drawingUi.GetGmIconAlpha(), _drawingUi.GetPlayerIconAlpha(), _drawingUi.GetFogOfWarIconAlpha(), _drawingUi.GetOverlayGridAlpha(), _drawingUi.GetPlayerIconAlpha(), 100};
        }
    }
}
