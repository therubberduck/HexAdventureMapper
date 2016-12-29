using System;
using System.Drawing;
using System.Windows.Forms;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.Painting;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;
using HexAdventureMapper.Visualizer;

namespace HexAdventureMapper
{
    public partial class PlayerWindow: Form, IDrawingUi, IFogOfWarUi
    {
        private DrawingHandler _drawingHandler;
        private FogOfWarPainter _fogOfWarPainter;

        private bool _lockControls;

        public PlayerWindow(TileConfigInterface tiles, DbInterface db)
        {
            InitializeComponent();
            
            _drawingHandler = new DrawingHandler("Player", this, tiles, db);

            _fogOfWarPainter = new FogOfWarPainter(this, db);

            imgPlayerMap.BackColor = ColorTranslator.FromHtml("#333333");

            DrawMap();
        }

        public MapBox GetMapBox()
        {
            return imgPlayerMap;
        }

        public HexCoordinate GetSelectedCoordinate()
        {
            return null;
        }

        public int GetGmIconAlpha()
        {
            return 0;
        }

        public int GetPlayerIconAlpha()
        {
            return 100;
        }

        public int GetFogOfWarIconAlpha()
        {
            return 100;
        }

        public int GetOverlayGridAlpha()
        {
            return 0;
        }

        public void StartBusyIndicator()
        {
            _lockControls = true;
            imgLoadingIndicator.Show();
        }

        public void StopBusyIndicator()
        {
            imgLoadingIndicator.Hide();
            _lockControls = false;
        }

        private void DrawMap()
        {
            _drawingHandler.DrawMap();
        }

        public void RedrawHex(HexCoordinate coordinate, Layer layer)
        {
            _drawingHandler.RedrawHex(coordinate, layer);
        }

        public void RedrawArea(HexCoordinate coordinate)
        {
            _drawingHandler.RedrawFogOfWar();
        }

        private void imgPlayerMap_Click(object sender, MapEventArgs e)
        {
            if (_lockControls)
            {
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                _fogOfWarPainter.ClearFogofWarAround(e.HexWorldCoordinate);
                _drawingHandler.RedrawFogOfWar();
                _drawingHandler.RedrawPartyLocation(e.HexWorldCoordinate);
            }
        }

        private void btnMoveNorth1_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.North, 2);
        }

        private void btnMoveNorth2_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.North, 8);
        }

        private void btnMoveNorth3_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.North, 24);
        }

        private void btnMoveEast1_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.East, 2);
        }

        private void btnMoveEast2_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.East, 8);
        }

        private void btnMoveEast3_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.East, 24);
        }

        private void btnMoveSouth1_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.South, 2);
        }

        private void btnMoveSouth2_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.South, 8);
        }

        private void btnMoveSouth3_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.South, 24);
        }

        private void btnMoveWest1_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.West, 2);
        }

        private void btnMoveWest2_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.West, 8);
        }

        private void btnMoveWest3_Click(object sender, EventArgs e)
        {
            MoveWindow(Direction.West, 24);
        }

        private void MoveWindow(Direction direction, int distance)
        {
            if (_lockControls)
            {
                return;
            }

            switch (direction)
            {
                case Direction.North:
                    imgPlayerMap.UpdateVerticalOffset(-distance);
                    break;
                case Direction.East:
                    imgPlayerMap.UpdateHorizontalOffset(distance);
                    break;
                case Direction.South:
                    imgPlayerMap.UpdateVerticalOffset(distance);
                    break;
                case Direction.West:
                    imgPlayerMap.UpdateHorizontalOffset(-distance);
                    break;
            }
            DrawMap();
        }

        public int GetFogOfWarId()
        {
            return -1;
        }
    }
}
