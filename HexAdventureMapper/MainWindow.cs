using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Painting;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;
using HexAdventureMapper.Visualizer;

namespace HexAdventureMapper
{

    public partial class MainWindow : Form, IPainterUi
    {
        public enum DrawingTools
        {
            Select,
            Terrain,
            Icons,
            River,
            Road
        };

        private DbInterface _db;
        private TileConfigInterface _tiles;
        private HexMapFactory _hexMapFactory;
        private Painter _painter;

        private DrawingTools _currentDrawingTools;
        private HexCoordinate _lastDraggedHex;

        public MainWindow()
        {
            InitializeComponent();

            imgHexMap.MapClick += imgHexMap_MapClick;
            imgHexMap.MapDrag += imgHexMap_MapDrag;

            _db = new DbInterface();
            _tiles = new TileConfigInterface();
            _hexMapFactory = new HexMapFactory(_tiles, _db, imgHexMap);
            _painter = new Painter(this, _db);

            foreach (TileComponent terrain in _tiles.GetTerrain())
            {
                cmbTerrain.Items.Add(terrain.Name);
            }
            cmbTerrain.SelectedIndex = 1;

            foreach (TileComponent vegetation in _tiles.GetVegetation())
            {
                cmbVegetation.Items.Add(vegetation.Name);
            }
            cmbVegetation.SelectedIndex = 0;

            foreach (TileComponent icon in _tiles.GetIcons())
            {
                cmbIcon.Items.Add(icon.Name);
            }
            cmbIcon.SelectedIndex = 0;

            List<string> riverSizes = new List<string> {"Stream", "River, Small", "River, Large"};
            foreach (string riverSize in riverSizes)
            {
                cmbRiver.Items.Add(riverSize);
            }
            cmbRiver.SelectedIndex = 1;

            List<string> roadSizes = new List<string> { "Trail", "Dirt Road", "Cobbled Road" };
            foreach (string roadSize in roadSizes)
            {
                cmbRoad.Items.Add(roadSize);
            }
            cmbRoad.SelectedIndex = 1;


            rbTerrain.Checked = true;

            DrawMap();
        }

        public DrawingTools GetDrawingTool()
        {
            return _currentDrawingTools;
        }

        public int GetTerrainId()
        {
            return _tiles.GetTerrain()[cmbTerrain.SelectedIndex].Id;
        }

        public int GetVegetationId()
        {
            return _tiles.GetVegetation()[cmbVegetation.SelectedIndex].Id;
        }

        public int GetIconId()
        {
            return _tiles.GetIcons()[cmbIcon.SelectedIndex].Id;
        }

        public int GetRiverId()
        {
            return cmbRiver.SelectedIndex;
        }

        public int GetRoadId()
        {
            return cmbRoad.SelectedIndex + 3;
        }

        private void DrawMap()
        {
            var map = _hexMapFactory.MakeLocalMap();
            imgHexMap.Image = map;

        }

        private void imgHexMap_MapDrag(object sender, MapEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                HexCoordinate currentCoordinate = PositionManager.ScreenToHex(e.X, e.Y);
                if (_lastDraggedHex == null || !_lastDraggedHex.Equals(currentCoordinate))
                {
                    _lastDraggedHex = currentCoordinate;
                    PaintTerrain(e);
                }
            }
        }

        private void imgHexMap_MapClick(object sender, MapEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PaintTerrain(e);
            }
            else if (e.Button == MouseButtons.Right)
            {
                RemoveTerrain(e);
            }
        }

        private void PaintTerrain(MapEventArgs e)
        {
            if (_currentDrawingTools == DrawingTools.Select)
            {
                _hexMapFactory.SelectedCoordinate = e.HexWorldCoordinate;
                
                Hex hex = _db.Hexes.GetForCoordinate(e.HexWorldCoordinate);
                if (hex != null)
                {
                    txtDetail.Text = hex.Detail;
                }
                else
                {
                    txtDetail.Text = "";
                }
            }
            else if (_painter.TryPaint(e))
            {
                //Successfully painted
            }

            DrawMap();
        }

        private void RemoveTerrain(MapEventArgs e)
        {
            if (_painter.TryRemove(e))
            {
                DrawMap();
            }
        }

        private void cmbTerrain_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            rbTerrain.Checked = true;
        }

        private void cmbVegetation_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            rbTerrain.Checked = true;
        }

        private void cmbIcon_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            rbIcons.Checked = true;
        }

        private void cmbRiver_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            rbRiver.Checked = true;
        }

        private void cmbRoad_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            rdRoad.Checked = true;
        }

        private void rbSelect_CheckedChanged(object sender, System.EventArgs e)
        {
            _currentDrawingTools = DrawingTools.Select;
        }

        private void rbTerrain_CheckedChanged(object sender, System.EventArgs e)
        {
            _currentDrawingTools = DrawingTools.Terrain;
            _hexMapFactory.SelectedCoordinate = null;
        }

        private void rbIcons_CheckedChanged(object sender, System.EventArgs e)
        {
            _currentDrawingTools = DrawingTools.Icons;
            _hexMapFactory.SelectedCoordinate = null;
        }

        private void rbRiver_CheckedChanged(object sender, System.EventArgs e)
        {
            _currentDrawingTools = DrawingTools.River;
            _hexMapFactory.SelectedCoordinate = null;
        }

        private void rdRoad_CheckedChanged(object sender, System.EventArgs e)
        {
            _currentDrawingTools = DrawingTools.Road;
            _hexMapFactory.SelectedCoordinate = null;
        }

        private void txtDetail_TextChanged(object sender, System.EventArgs e)
        {
            _db.Hexes.UpdateDetail(_hexMapFactory.SelectedCoordinate, txtDetail.Text);
        }

        private void btnMoveNorth_Click(object sender, System.EventArgs e)
        {
            imgHexMap.UpdateVerticalOffset(-2);
            _hexMapFactory.SelectedCoordinate = null;
            DrawMap();
        }

        private void btnMoveWest_Click(object sender, System.EventArgs e)
        {
            imgHexMap.UpdateHorizontalOffset(-2);
            _hexMapFactory.SelectedCoordinate = null;
            DrawMap();
        }

        private void btnMoveSouth_Click(object sender, System.EventArgs e)
        {
            imgHexMap.UpdateVerticalOffset(2);
            _hexMapFactory.SelectedCoordinate = null;
            DrawMap();
        }

        private void btnMoveEast_Click(object sender, System.EventArgs e)
        {
            imgHexMap.UpdateHorizontalOffset(2);
            _hexMapFactory.SelectedCoordinate = null;
            DrawMap();
        }

        private void imgHexMap_SizeChanged(object sender, System.EventArgs e)
        {
            _hexMapFactory.SelectedCoordinate = null;
            DrawMap();
        }

        private void loadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            fileDialog.AddExtension = true;
            fileDialog.DefaultExt = "ham";
            fileDialog.Filter = "Save File|*.ham";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string dbPath = "db.sqlite";
                string savePath = fileDialog.FileName;
                File.Copy(savePath, dbPath, true);
                DrawMap();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            fileDialog.AddExtension = true;
            fileDialog.DefaultExt = "ham";
            fileDialog.Filter = "Save File|*.ham";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string dbPath = "db.sqlite";
                string savePath = fileDialog.FileName;
                File.Copy(dbPath, savePath, true);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit Hex Adventure Mapper", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Stop);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
