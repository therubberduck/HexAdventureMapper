using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Visualizer;

namespace HexAdventureMapper.Views
{
    public partial class MapBox : UserControl
    {
        public event MapEventHandler MapClick;
        public event MapEventHandler MapDrag;

        private readonly Dictionary<Layer, TransparentControl> _layers; 

        public HexCoordinate TopLeftCoordinate { get; }

        public Rectangle MapArea
        {
            get
            {
                HexCoordinate mapSizeInHexes = PositionManager.ScreenToHex(Size.Width + 1, Size.Height + 1);
                return new Rectangle((int) TopLeftCoordinate.X - 1, (int)TopLeftCoordinate.Y - 1, (int) mapSizeInHexes.X + 1, (int) mapSizeInHexes.Y + 1);
            }
        }

        public MapBox()
        {
            InitializeComponent();
            _layers = new Dictionary<Layer, TransparentControl>();
            TopLeftCoordinate = new HexCoordinate(0, 0);
            MouseClick += HandleMapClicked;
            MouseMove += HandleMapDragging;
        }

        public Image GetMapImage()
        {
            Image image = new Bitmap(Size.Width, Size.Height);
            using (var graphics = Graphics.FromImage(image))
            {
                foreach (var layer in _layers)
                {
                    graphics.DrawImage(layer.Value.Image, new Point(0,0));
                }
            }
            return image;
        }

        public Image GetLayer(Layer layer)
        {
            if (_layers.ContainsKey(layer))
            {
                TransparentControl layerBox = _layers[layer];
                return layerBox.Image;
            }
            return null;
        }

        public void UpdateLayer(Layer layer, Image image)
        {
            if (!_layers.ContainsKey(layer))
            {
                TransparentControl pictureBox = new TransparentControl();
                pictureBox.Size = Size;
                pictureBox.Anchor = AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Bottom;
                
                pictureBox.MouseClick += HandleMapClicked;
                pictureBox.MouseMove += HandleMapDragging;
                Controls.Add(pictureBox);
                Controls.SetChildIndex(pictureBox, (int)layer);
                _layers.Add(layer, pictureBox);
            }
            TransparentControl layerBox = _layers[layer];
            layerBox.Image = image;
        }

        public void UpdateVerticalOffset(long offsetY)
        {
            TopLeftCoordinate.Y += offsetY;
        }

        public void UpdateHorizontalOffset(long offsetX)
        {
            TopLeftCoordinate.X += offsetX;
        }

        private void HandleMapClicked(object sender, MouseEventArgs e)
        {
            OnMapClicked(e);
        }

        private void HandleMapDragging(object sender, MouseEventArgs e)
        {
            OnMapDrag(e);
        }

        protected virtual void OnMapClicked(MouseEventArgs e)
        {
            MapEventHandler handler = MapClick;
            if (handler != null)
            {
                HexCoordinate hexMapCoordinate = PositionManager.ScreenToHex(e.X, e.Y).Plus(TopLeftCoordinate);
                MapEventArgs args = new MapEventArgs(e.X, e.Y, e.Button, e.Clicks, hexMapCoordinate);
                handler(this, args);
            }
        }

        protected virtual void OnMapDrag(MouseEventArgs e)
        {
            MapEventHandler handler = MapDrag;
            if (handler != null)
            {
                HexCoordinate hexMapCoordinate = PositionManager.ScreenToHex(e.X, e.Y).Plus(TopLeftCoordinate);
                MapEventArgs args = new MapEventArgs(e.X, e.Y, e.Button, e.Clicks, hexMapCoordinate);
                handler(this, args);
            }
        }

        private void HandleMapClicked(object sender, EventArgs e)
        {

        }
    }
    public class MapEventArgs : EventArgs
    {
        public long X { get; private set; }
        public long Y { get; private set; }
        public MouseButtons Button { get; private set; }
        public int Clicks { get; private set; }
        public HexCoordinate HexWorldCoordinate { get; private set; }
        public HexCoordinate HexScreenCoordinate { get; private set; }
        public Direction PartOfHexClicked => PositionManager.PartOfHexClicked((int) X, (int) Y);

        public MapEventArgs(long mouseX, long mouseY, MouseButtons mouseButton, int clicks, HexCoordinate hexWorldCoordinate)
        {
            X = mouseX;
            Y = mouseY;
            Button = mouseButton;
            Clicks = clicks;
            HexWorldCoordinate = hexWorldCoordinate;
            HexScreenCoordinate = PositionManager.ScreenToHex(X, Y);
        }
    }

    public delegate void MapEventHandler(object sender, MapEventArgs e);
}
