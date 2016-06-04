using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;
using HexAdventureMapper.Visualizer;

namespace HexAdventureMapper
{

    public partial class MainWindow : Form
    {
        private enum DrawingTools
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

            List<string> riverSizes = new List<string> {"Small", "Medium", "Large"};
            foreach (string riverSize in riverSizes)
            {
                cmbRiver.Items.Add(riverSize);
            }
            cmbRiver.SelectedIndex = 1;

            List<string> roadSizes = new List<string> { "Small", "Medium", "Large" };
            foreach (string roadSize in roadSizes)
            {
                cmbRoad.Items.Add(roadSize);
            }
            cmbRoad.SelectedIndex = 1;


            rbTerrain.Checked = true;

            DrawMap();
        }

        private void DrawMap()
        {
            //var hexes = _db.Hexes.GetAll();
            //var map = _hexMapFactory.MakeMapFromEntireArea(hexes);
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
                _hexMapFactory.SelectedCoordinate = e.HexMapCoordinate;
                
                Hex hex = _db.Hexes.GetForCoordinate(e.HexMapCoordinate);
                if (hex != null)
                {
                    txtDetail.Text = hex.Detail;
                }
                else
                {
                    txtDetail.Text = "";
                }
            }
            else if (_currentDrawingTools == DrawingTools.Terrain)
            {
                int terrainId = _tiles.GetTerrain()[cmbTerrain.SelectedIndex].Id;
                int vegetationId = _tiles.GetVegetation()[cmbVegetation.SelectedIndex].Id;

                if (_db.Hexes.HexExists(e.HexMapCoordinate))
                {
                    _db.Hexes.UpdateTerrain(e.HexMapCoordinate, terrainId, vegetationId);
                }
                else
                {
                    _db.Hexes.Create(e.HexMapCoordinate, terrainId, vegetationId);
                }
                
            }
            else if (_currentDrawingTools == DrawingTools.Icons)
            {
                int iconId = _tiles.GetIcons()[cmbIcon.SelectedIndex].Id;

                if (!_db.Hexes.HexExists(e.HexMapCoordinate))
                {
                    _db.Hexes.Create(e.HexMapCoordinate, 0, 0);
                }
                _db.Hexes.UpdateIcon(e.HexMapCoordinate, iconId);
            }
            else if (_currentDrawingTools == DrawingTools.River)
            {
                DrawConnection(e, cmbRiver.SelectedIndex);
            }
            else if (_currentDrawingTools == DrawingTools.Road)
            {
                DrawConnection(e, cmbRoad.SelectedIndex + 3);
            }

            DrawMap();
        }

        private void RemoveTerrain(MapEventArgs e)
        {
            if (_currentDrawingTools == DrawingTools.River)
            {
                RemoveConnection(e, cmbRiver.SelectedIndex);
            }
            else if (_currentDrawingTools == DrawingTools.Road)
            {
                RemoveConnection(e, cmbRoad.SelectedIndex + 3);
            }

            DrawMap();
        }

        private void DrawConnection(MapEventArgs e, int type)
        {
            Direction direction = PositionManager.PartOfHexClicked((int)e.X, (int)e.Y);
            if (direction != Direction.None)
            {
                _db.HexConnections.Create(e.HexMapCoordinate, type, direction);
                HexCoordinate mapNeighborCoordinate = PositionManager.NeighborTo(e.HexMapCoordinate, direction);
                Debug.WriteLine("First is X: " + e.HexMapCoordinate.X + " Y: " + e.HexMapCoordinate.Y);
                Debug.WriteLine("Neighbor is X: " + mapNeighborCoordinate.X + " Y: " + mapNeighborCoordinate.Y);
                Direction oppositeDirection = PositionManager.OppositeDirection(direction);
                _db.HexConnections.Create(mapNeighborCoordinate, type, oppositeDirection);
            }
        }

        private void RemoveConnection(MapEventArgs e, int type)
        {
            Direction direction = PositionManager.PartOfHexClicked((int)e.X, (int)e.Y);
            if (direction != Direction.None)
            {
                _db.HexConnections.Remove(e.HexMapCoordinate, direction);
                HexCoordinate mapNeighborCoordinate = PositionManager.NeighborTo(e.HexMapCoordinate, direction);
                Direction oppositeDirection = PositionManager.OppositeDirection(direction);
                _db.HexConnections.Remove(mapNeighborCoordinate, oppositeDirection);
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

        //private void imgHexMap_Resize(object sender, System.EventArgs e)
        //{
        //    _hexMapFactory.SelectedCoordinate = null;
        //    DrawMap();
        //}
    }
}
