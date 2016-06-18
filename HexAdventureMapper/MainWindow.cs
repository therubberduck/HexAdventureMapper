using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Painting;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;
using HexAdventureMapper.Visualizer;
using Timer = System.Threading.Timer;

namespace HexAdventureMapper
{

    public partial class MainWindow : Form, IPainterUi
    {
        public enum DrawingTools
        {
            Select,
            Terrain,
            GmIcons,
            PlayerIcons,
            River,
            Road,
            FogOfWar
        };

        private DbInterface _db;
        private TileConfigInterface _tiles;
        private HexMapFactory _hexMapFactory;
        private Painter _painter;
        
        private DrawingTools _currentDrawingTools;

        private HexCoordinate _lastDraggedHex;
        private bool _drawingDisabled;

        private HexCoordinate _lastScheduledDetailSave;
        private Timer _saveDetailTimer;

        private System.Threading.Timer _autoSaveTimer;

        public MainWindow()
        {
            InitializeComponent();

            imgHexMap.MapClick += imgHexMap_MapClick;
            imgHexMap.MapDrag += imgHexMap_MapDrag;

            _db = new DbInterface();
            _tiles = new TileConfigInterface();
            _hexMapFactory = new HexMapFactory(this, _tiles, _db, imgHexMap);
            _painter = new Painter(this, _db);

            imgHexMap.BackColor = ColorTranslator.FromHtml("#333333");

            cmbTerrain.Items.AddRange(_tiles.GetTerrainNames());
            cmbTerrain.SelectedIndex = 1;
            
            cmbVegetation.Items.AddRange(_tiles.GetVegetationNames());
            cmbVegetation.SelectedIndex = 0;

            cmbIcon.Items.AddRange(_tiles.GetIconNames());
            cmbIcon.SelectedIndex = 0;

            cmbPlayerIcon.Items.AddRange(_tiles.GetIconNames());
            cmbPlayerIcon.SelectedIndex = 0;

            object[] riverSizes = {"Stream", "River, Small", "River, Large"};
            cmbRiver.Items.AddRange(riverSizes);
            cmbRiver.SelectedIndex = 0;

            object[] roadSizes = { "Trail", "Dirt Road", "Cobbled Road", "Ancient Road" };
            cmbRoad.Items.AddRange(roadSizes);
            cmbRoad.SelectedIndex = 0;

            object[] fogOfWarTypes = { "Full", "Half" };
            cmbFogOfWar.Items.AddRange(fogOfWarTypes);
            cmbFogOfWar.SelectedIndex = 0;

            rbSelect.Checked = true;

            chk100GmIcons.Checked = true;
            chk100PlayerIcons.Checked = true;

            DrawMap();

            _autoSaveTimer = new Timer(e => AutoSave(), null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
        }

        public DrawingTools GetDrawingTool()
        {
            return _currentDrawingTools;
        }

        public int GetGmIconAlpha()
        {
            return GetLayerAlphaFor(chk50GmIcons, chk100GmIcons);
        }

        public int GetPlayerIconAlpha()
        {
            return GetLayerAlphaFor(chk50PlayerIcons, chk100PlayerIcons);
        }

        public int GetFogOfWarIconAlpha()
        {
            return GetLayerAlphaFor(chk50FogOfWar, chk100FogOfWar);
        }

        private int GetLayerAlphaFor(CheckBox chk50, CheckBox chk100)
        {
            if (chk50.Checked)
            {
                return 50;
            }
            else if (chk100.Checked)
            {
                return 100;
            }
            else
            {
                return 0;
            }
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

        public int GetPlayerIconId()
        {
            return _tiles.GetIcons()[cmbPlayerIcon.SelectedIndex].Id;
        }

        public int GetRiverId()
        {
            return cmbRiver.SelectedIndex;
        }

        public int GetRoadId()
        {
            return cmbRoad.SelectedIndex + 3;
        }

        public int GetFogOfWarId()
        {
            return cmbFogOfWar.SelectedIndex;
        }

        private void DrawMap()
        {
            Image map = _hexMapFactory.MakeLocalMap();
            if (map != null)
            {
                imgHexMap.Image = map;
            }
        }

        private void DrawHex(HexCoordinate coordinate)
        {
            Image map = _hexMapFactory.RedrawHex(coordinate, imgHexMap.Image);
            if (map != null)
            {
                imgHexMap.Image = map;
            }
        }

        private void imgHexMap_MapDrag(object sender, MapEventArgs e)
        {
            if (e.Button == MouseButtons.Left ||
                (e.Button == MouseButtons.Right && _currentDrawingTools == DrawingTools.FogOfWar))
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
                SelectHex(e);
                if (_painter.TryPaint(e)) //Since we are not selecting, we are painting. Try to paint
                {
                    if (_currentDrawingTools == DrawingTools.River || _currentDrawingTools == DrawingTools.Road)
                    {
                        //For connections, we also redraw the neighboring hex, since it also gets a connection that needs drawing
                        var neighborHex = PositionManager.NeighborTo(e.HexWorldCoordinate, e.PartOfHexClicked);
                        DrawHex(neighborHex); 
                    }
                }
                DrawHex(e.HexWorldCoordinate); //Redraw the changed hex
                txtDetail.Focus();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_painter.TryRemove(e)) //Try to delete
                {
                    if (_currentDrawingTools == DrawingTools.River || _currentDrawingTools == DrawingTools.Road)
                    {
                        //For connections, we also redraw the neighboring hex, since it also has a connection removed that needs drawing
                        var neighborHex = PositionManager.NeighborTo(e.HexWorldCoordinate, e.PartOfHexClicked);
                        DrawHex(e.HexWorldCoordinate);
                        DrawHex(neighborHex);
                    }
                    else
                    {
                        DrawHex(e.HexWorldCoordinate); //Redraw the changed hex
                    }
                }
            }
        }

        private void SelectHex(MapEventArgs e)
        {
            if (_hexMapFactory.SelectedCoordinate != null) //Redraw the previously selected hex (deselect) if there was a previously selected hex
            {
                var selectedCoordinate = _hexMapFactory.SelectedCoordinate;
                _hexMapFactory.SelectedCoordinate = null; //We set the SelectedCoordinate to null, so that hexMapFactory knows it is not selected
                DrawHex(selectedCoordinate);
            }

            _hexMapFactory.SelectedCoordinate = e.HexWorldCoordinate; //Mark the new hex as selected

            //Update the textfield with the hex's detail (if any)
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
            else if (sender == cmbPlayerIcon)
            {
                rbPlayerIcon.Checked = true;
            }
            else if (sender == cmbRiver)
            {
                rbRiver.Checked = true;
            }
            else if (sender == cmbRoad)
            {
                rbRoad.Checked = true;
            }
            else if (sender == cmbFogOfWar)
            {
                rbFogOfWar.Checked = true;
            }
        }

        private void ComboBox_Clicked(object sender, EventArgs e)
        {
            ((ComboBox)sender).DroppedDown = true;
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
                    _currentDrawingTools = DrawingTools.GmIcons;

                    _drawingDisabled = true;
                    chk100GmIcons.Checked = true;
                    chk50PlayerIcons.Checked = false;
                    chk100PlayerIcons.Checked = false;
                    _drawingDisabled = false;

                    DrawMap();
                }
                else if (sender == rbPlayerIcon)
                {
                    _currentDrawingTools = DrawingTools.PlayerIcons;

                    _drawingDisabled = true;
                    chk50GmIcons.Checked = true;
                    chk100PlayerIcons.Checked = true;
                    _drawingDisabled = false;

                    DrawMap();
                }
                else if (sender == rbRiver)
                {
                    _currentDrawingTools = DrawingTools.River;
                }
                else if (sender == rbRoad)
                {
                    _currentDrawingTools = DrawingTools.Road;
                }
                else if (sender == rbFogOfWar)
                {
                    _currentDrawingTools = DrawingTools.FogOfWar;
                }
            }
        }

        private void txtDetail_TextChanged(object sender, System.EventArgs e)
        {
            //If the last scheduled detail update was to this hex, unschedule it, since we are making a new one (for this hex)
            if (_saveDetailTimer != null && _lastScheduledDetailSave.Equals(_hexMapFactory.SelectedCoordinate))
            {
                _saveDetailTimer.Dispose();
            }
            //Schedule a detail update after 1 second (so we wait to update until the user is done typing)
            TimerCallback callback = SaveDetailText;
            object[] state = {_hexMapFactory.SelectedCoordinate, txtDetail.Text};
            _saveDetailTimer = new Timer(callback, state, TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(-1));

            //Update which hex is scheduled for an update, for use next time this event gets called
            _lastScheduledDetailSave = _hexMapFactory.SelectedCoordinate;
        }

        private void SaveDetailText(object state)
        {
            object[] stateArray = (object[]) state;
            HexCoordinate hex = (HexCoordinate)stateArray[0];
            string detail = (string)stateArray[1];

            _db.Hexes.UpdateDetail(hex, detail);
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
                    _db.UpdateDbSchema();
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

        private void btnMoveNorth1_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.North, 2);
        }

        private void btnMoveNorth2_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.North, 8);
        }

        private void btnMoveNorth3_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.North, 24);
        }

        private void btnMoveWest1_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.West, 2);
        }

        private void btnMoveWest2_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.West, 8);
        }

        private void btnMoveWest3_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.West, 24);
        }

        private void btnMoveSouth1_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.South, 2);
        }

        private void btnMoveSouth2_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.South, 8);
        }

        private void btnMoveSouth3_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.South, 24);
        }

        private void btnMoveEast1_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.East, 2);
        }

        private void btnMoveEast2_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.East, 8);
        }

        private void btnMoveEast3_MouseClick(object sender, MouseEventArgs e)
        {
            MoveWindow(Direction.East, 24);
        }

        private void MoveWindow(Direction direction, int distance)
        {
            _hexMapFactory.SelectedCoordinate = null;
            switch (direction)
            {
                    case Direction.North:
                    imgHexMap.UpdateVerticalOffset(-distance);
                    break;
                    case Direction.East:
                    imgHexMap.UpdateHorizontalOffset(distance);
                    break;
                    case Direction.South:
                    imgHexMap.UpdateVerticalOffset(distance);
                    break;
                    case Direction.West:
                    imgHexMap.UpdateHorizontalOffset(-distance);
                    break;
            }
            DrawMap();
        }

        private void CheckBox_LayerChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox) sender;

            if (checkBox.Checked)
            {
                if (checkBox == chk50GmIcons)
                {
                    chk100GmIcons.Checked = false;
                }
                else if (checkBox == chk100GmIcons)
                {
                    chk50GmIcons.Checked = false;
                }
                else if (checkBox == chk50PlayerIcons)
                {
                    chk100PlayerIcons.Checked = false;
                }
                else if (checkBox == chk100PlayerIcons)
                {
                    chk50PlayerIcons.Checked = false;
                }
                else if (checkBox == chk50FogOfWar)
                {
                    chk100FogOfWar.Checked = false;
                }
                else if (checkBox == chk100FogOfWar)
                {
                    chk50FogOfWar.Checked = false;
                }
            }
            if (!_drawingDisabled)
            {
                DrawMap();
            }
        }
    }
}
