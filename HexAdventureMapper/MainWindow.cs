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

        private System.Threading.Timer _autoSaveTimer;

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

            _autoSaveTimer = new System.Threading.Timer(e => AutoSave(), null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
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
            imgHexMap.Image = _hexMapFactory.MakeLocalMap();

        }

        private void imgHexMap_MapDrag(object sender, MapEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_lastDraggedHex == null || !_lastDraggedHex.Equals(e.HexScreenCoordinate))
                {
                    _lastDraggedHex = e.HexScreenCoordinate;
                    imgHexMap_MapClick(sender, e);
                }
            }
        }

        private void imgHexMap_MapClick(object sender, MapEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_currentDrawingTools == DrawingTools.Select)
                {
                    _hexMapFactory.SelectedCoordinate = e.HexWorldCoordinate;
                    DrawMap();

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
                    DrawMap();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_painter.TryRemove(e))
                {
                    DrawMap();
                }
            }
        }

        private void Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == cmbTerrain || sender == cmbVegetation)
            {
                rbTerrain.Checked = true;
            }
            else if (sender == cmbIcon)
            {
                rbIcons.Checked = true;
            }
            else if (sender == cmbRiver)
            {
                rbRiver.Checked = true;
            }
            else if (sender == cmbRoad)
            {
                rbRoad.Checked = true;
            }
        }

        private void RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (sender == rbSelect)
            {
                _currentDrawingTools = DrawingTools.Select;
            }
            else
            {
                if (sender == rbTerrain)
                {
                    _currentDrawingTools = DrawingTools.Terrain;
                }
                else if (sender == rbIcons)
                {
                    _currentDrawingTools = DrawingTools.Icons;
                }
                else if (sender == rbRiver)
                {
                    _currentDrawingTools = DrawingTools.River;
                }
                else if (sender == rbRoad)
                {
                    _currentDrawingTools = DrawingTools.Road;
                }
                _hexMapFactory.SelectedCoordinate = null;
            }
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want a new map? You will lose all unsaved work.", "New Map", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Stop);
            if (result == DialogResult.OK)
            {
                _db.ClearDb();
                DrawMap();
            }
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
                DialogResult result2 = MessageBox.Show("Do you really want to load the map? You will lose all unsaved work.", "Load Map", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Stop);
                if (result2 == DialogResult.OK)
                {
                    string dbPath = "db.sqlite";
                    string savePath = fileDialog.FileName;
                    File.Copy(savePath, dbPath, true);
                    DrawMap();
                }
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

        private void AutoSave()
        {
            string dbPath = "db.sqlite";
            string savePath = "autosave.ham";
            File.Copy(dbPath, savePath, true);
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
