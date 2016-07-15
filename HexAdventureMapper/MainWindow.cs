using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using HexAdventureMapper.Database;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Helper;
using HexAdventureMapper.Painting;
using HexAdventureMapper.TileConfig;
using HexAdventureMapper.Views;
using HexAdventureMapper.Visualizer;
using Timer = System.Threading.Timer;

namespace HexAdventureMapper
{

    public partial class MainWindow : Form, IDrawingUi, IPainterUi, IFogOfWarUi
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

        private PlayerWindow _playerWindow;

        private DbInterface _db;
        private TileConfigInterface _tiles;
        private DrawingHandler _drawingHandler;
        private Painter _painter;
        private FogOfWarPainter _fogOfWarPainter;
        
        private DrawingTools _currentDrawingTool;
        private HexCoordinate _selectedCoordinate;

        private HexCoordinate _lastDraggedHex;
        private bool _drawingDisabled;

        private HexCoordinate _lastScheduledDetailSave;
        private Timer _saveDetailTimer;

        private Timer _autoSaveTimer;

        public MainWindow()
        {
            InitializeComponent();
            
            _db = new DbInterface();
            _tiles = new TileConfigInterface();
            _drawingHandler = new DrawingHandler(this, _tiles, _db);
            _painter = new Painter(this, _db);
            _fogOfWarPainter = new FogOfWarPainter(this, _db);

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
            return _currentDrawingTool;
        }

        public MapBox GetMapBox()
        {
            return imgHexMap;
        }

        public HexCoordinate GetSelectedCoordinate()
        {
            return _selectedCoordinate;
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

        public int GetOverlayGridAlpha()
        {
            if (chkOverlayGrid.Checked)
            {
                return 100;
            }
            else
            {
                return 0;
            }
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
            _drawingHandler.DrawMap();
        }

        private void DrawFogOfWar()
        {
            _drawingHandler.RedrawFogOfWar();
        }

        private void DrawHex(HexCoordinate coordinate, Layer layer, bool redrawPlayerWindow = true)
        {
            _drawingHandler.RedrawHex(coordinate, layer);
            if (_playerWindow != null && redrawPlayerWindow)
            {
                _playerWindow.RedrawHex(coordinate, layer);
            }
        }

        private void imgHexMap_MapDrag(object sender, MapEventArgs e)
        {
            if (e.Button == MouseButtons.Left ||
                (e.Button == MouseButtons.Right && _currentDrawingTool == DrawingTools.FogOfWar))
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
                if (_currentDrawingTool == DrawingTools.Select)
                {
                    SelectHex(e);
                }
                else
                {
                    if (GetDrawingTool() == DrawingTools.FogOfWar)
                    {
                        _fogOfWarPainter.PaintFogOfWar(e.HexWorldCoordinate);
                    }
                    else if (_painter.TryPaint(e)) //Since we are not selecting, we are painting. Try to paint
                    {
                        if (_currentDrawingTool == DrawingTools.River || _currentDrawingTool == DrawingTools.Road)
                        {
                            //For connections, we also redraw the neighboring hex, since it also gets a connection that needs drawing
                            var neighborHex = DirectionManager.NeighborTo(e.HexWorldCoordinate, e.PartOfHexClicked);
                            DrawHex(neighborHex, DrawingToolToLayer(_currentDrawingTool));
                        }
                    }
                    DrawHex(e.HexWorldCoordinate, DrawingToolToLayer(_currentDrawingTool)); //Redraw the changed hex
                    SelectHex(e);
                    txtDetail.Focus();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (GetDrawingTool() == DrawingTools.FogOfWar)
                {
                    _fogOfWarPainter.RemoveFogOfWar(e.HexWorldCoordinate);
                }
                else if (_painter.TryRemove(e)) //Try to delete
                {
                    if (_currentDrawingTool == DrawingTools.River || _currentDrawingTool == DrawingTools.Road)
                    {
                        //For connections, we also redraw the neighboring hex, since it also has a connection removed that needs drawing
                        var neighborHex = DirectionManager.NeighborTo(e.HexWorldCoordinate, e.PartOfHexClicked);
                        DrawHex(neighborHex, DrawingToolToLayer(_currentDrawingTool));
                    }
                    DrawHex(e.HexWorldCoordinate, DrawingToolToLayer(_currentDrawingTool)); //Redraw the changed hex
                }
            }
        }

        private Layer DrawingToolToLayer(DrawingTools drawingTool)
        {
            switch (drawingTool)
            {
                case DrawingTools.Select:
                    return Layer.Selection;
                case DrawingTools.Terrain:
                    return Layer.Terrain;
                case DrawingTools.GmIcons:
                    return Layer.GmIcon;
                case DrawingTools.PlayerIcons:
                    return Layer.PlayerIcon;
                case DrawingTools.River:
                    return Layer.River;
                case DrawingTools.Road:
                    return Layer.Road;
                case DrawingTools.FogOfWar:
                    return Layer.FogOfWar;
                default:
                    throw new ArgumentOutOfRangeException(nameof(drawingTool), drawingTool, null);
            }
        }

        private void SelectHex(MapEventArgs e)
        {
            if (_selectedCoordinate != null) //Redraw the previously selected hex (deselect) if there was a previously selected hex
            {
                var oldSelectedCoordinate = _selectedCoordinate;
                _selectedCoordinate = null; //We set the SelectedCoordinate to null, so that hexMapFactory knows it is not selected
                _drawingHandler.RedrawSelectedHex(oldSelectedCoordinate);
            }

            _selectedCoordinate = e.HexWorldCoordinate; //Mark the new hex as selected
            _drawingHandler.RedrawSelectedHex(_selectedCoordinate);

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

            lblCoordinates.Text = _selectedCoordinate.ToText();
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
            ((ComboBox) sender).DroppedDown = true;
        }

        private void RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (sender == rbSelect)
            {
                _currentDrawingTool = DrawingTools.Select;
            }
            else
            {
                if (sender == rbTerrain)
                {
                    _currentDrawingTool = DrawingTools.Terrain;
                }
                else if (sender == rbIcons)
                {
                    _currentDrawingTool = DrawingTools.GmIcons;

                    _drawingDisabled = true;
                    chk100GmIcons.Checked = true;
                    chk50PlayerIcons.Checked = false;
                    chk100PlayerIcons.Checked = false;
                    _drawingDisabled = false;

                    DrawMap();
                }
                else if (sender == rbPlayerIcon)
                {
                    _currentDrawingTool = DrawingTools.PlayerIcons;

                    _drawingDisabled = true;
                    chk50GmIcons.Checked = true;
                    chk100PlayerIcons.Checked = true;
                    _drawingDisabled = false;

                    DrawMap();
                }
                else if (sender == rbRiver)
                {
                    _currentDrawingTool = DrawingTools.River;
                }
                else if (sender == rbRoad)
                {
                    _currentDrawingTool = DrawingTools.Road;
                }
                else if (sender == rbFogOfWar)
                {
                    _currentDrawingTool = DrawingTools.FogOfWar;
                }
            }
        }

        private void txtDetail_TextChanged(object sender, System.EventArgs e)
        {
            if (_selectedCoordinate == null)
            {
                txtDetail.Text = "No hex selected";
                return;
            }

            //If the last scheduled detail update was to this hex, unschedule it, since we are making a new one (for this hex)
            if (_saveDetailTimer != null && _lastScheduledDetailSave.Equals(_selectedCoordinate))
            {
                _saveDetailTimer.Dispose();
            }
            //Schedule a detail update after 1 second (so we wait to update until the user is done typing)
            TimerCallback callback = SaveDetailText;
            object[] state = {_selectedCoordinate, txtDetail.Text};
            _saveDetailTimer = new Timer(callback, state, TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(-1));

            //Update which hex is scheduled for an update, for use next time this event gets called
            _lastScheduledDetailSave = _selectedCoordinate;
        }

        private void SaveDetailText(object state)
        {
            object[] stateArray = (object[]) state;
            HexCoordinate hex = (HexCoordinate) stateArray[0];
            string detail = (string) stateArray[1];

            _db.Hexes.UpdateDetail(hex, detail);
        }

        private void imgHexMap_SizeChanged(object sender, System.EventArgs e)
        {
            _selectedCoordinate = null;
            DrawMap();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want a new map? You will lose all unsaved work.", "New Map", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (result == DialogResult.OK)
            {
                _db.ClearDb();
                DrawMap();
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage(ImageFormat.Bmp);
        }

        private void bitmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage(ImageFormat.Bmp);
        }

        private void pngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage(ImageFormat.Png);
        }

        private void saveImage(ImageFormat imageFormat)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            fileDialog.AddExtension = true;
            if (imageFormat == ImageFormat.Png)
            {
                fileDialog.DefaultExt = "png";
                fileDialog.Filter = "Png File|*.png";
            }
            else
            {
                fileDialog.DefaultExt = "bmp";
                fileDialog.Filter = "Bmp File|*.bmp";
            }
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string savePath = fileDialog.FileName;
                imgHexMap.GetMapImage().Save(savePath, imageFormat);
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
                DialogResult result2 = MessageBox.Show("Do you really want to load the map? You will lose all unsaved work.", "Load Map", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _playerWindow = new PlayerWindow(_tiles, _db);
            _playerWindow.Show();
        }

        private void AutoSave()
        {
            string dbPath = "db.sqlite";
            string savePath = "autosave.ham";
            File.Copy(dbPath, savePath, true);
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Exit Hex Adventure Mapper", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
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
            _selectedCoordinate = null;
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

            //Play radio button
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
            CheckBox[] iconBoxes = {chk50GmIcons, chk100GmIcons, chk50PlayerIcons, chk100PlayerIcons};
            if (iconBoxes.Contains(checkBox))
            {
                if (!_drawingDisabled)
                {
                    DrawMap();
                }
            }
            else if(checkBox == chk50FogOfWar || checkBox == chk100FogOfWar)
            {
                if (!_drawingDisabled)
                {
                    DrawFogOfWar();
                }
            }
            else if (checkBox == chkOverlayGrid)
            {
                DrawMap();
            }
        }

        private void lblCoordinates_Click(object sender, EventArgs e)
        {
            if (_selectedCoordinate != null)
            {
                Clipboard.SetText(_selectedCoordinate.ToText());
            }
        }
    }
}
