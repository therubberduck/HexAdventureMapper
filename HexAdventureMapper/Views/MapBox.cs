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
    public partial class MapBox : PictureBox
    {
        public event MapEventHandler MapClick;
        public event MapEventHandler MapDrag;

        public HexCoordinate TopLeftCoordinate { get; }

        public Rectangle MapArea
        {
            get
            {
                HexCoordinate mapSizeInHexes = PositionManager.ScreenToHex(Size.Width + 1, Size.Height + 1);
                return new Rectangle((int) TopLeftCoordinate.X - 1, (int)TopLeftCoordinate.Y - 1, (int) mapSizeInHexes.X, (int) mapSizeInHexes.Y);
            }
        }

        public MapBox()
        {
            InitializeComponent();
            TopLeftCoordinate = new HexCoordinate(0, 0);
            MouseClick += HandleMapClicked;
            MouseMove += HandleMapDragging;
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
    }
    public class MapEventArgs : EventArgs
    {
        public long X { get; private set; }
        public long Y { get; private set; }
        public MouseButtons Button { get; private set; }
        public int Clicks { get; private set; }
        public HexCoordinate HexMapCoordinate { get; private set; }
        public HexCoordinate HexScreenCoordinate { get; private set; }

        public MapEventArgs(long mouseX, long mouseY, MouseButtons mouseButton, int clicks, HexCoordinate hexMapCoordinate)
        {
            X = mouseX;
            Y = mouseY;
            Button = mouseButton;
            Clicks = clicks;
            HexMapCoordinate = hexMapCoordinate;
            HexScreenCoordinate = PositionManager.ScreenToHex(X, Y);
        }
    }

    public delegate void MapEventHandler(object sender, MapEventArgs e);
}
