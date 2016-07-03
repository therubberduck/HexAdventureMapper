using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;

namespace HexAdventureMapper.Visualizer
{
    public class TileCache
    {
        private readonly Dictionary<HexCoordinate, Bitmap> _connectionTiles;
        private readonly Dictionary<long, Dictionary<long, Bitmap>> _iconTiles;
        private readonly Dictionary<long, Dictionary<long, Bitmap>> _finishedTiles;

        private Bitmap _foglessMap;

        public TileCache()
        {
            _connectionTiles = new Dictionary<HexCoordinate, Bitmap>();
            _iconTiles = new Dictionary<long, Dictionary<long, Bitmap>>();
            _finishedTiles = new Dictionary<long, Dictionary<long, Bitmap>>();
        }

        public Bitmap GetConnectionTile(HexCoordinate coor)
        {
            if (_connectionTiles.ContainsKey(coor))
            {
                return _connectionTiles[coor];
            }
            return null;
        }

        public void SetConnectionTile(HexCoordinate coor, Bitmap tileMap)
        {
            _connectionTiles.Add(coor, tileMap);
        }

        public Bitmap GetIconTile(HexCoordinate coor)
        {
            if (_iconTiles.ContainsKey(coor.X) && _iconTiles[coor.X].ContainsKey(coor.Y))
            {
                return _iconTiles[coor.X][coor.Y];
            }
            return null;
        }

        public void SetIconTile(HexCoordinate coor, Bitmap tileMap)
        {
            SetTile(_iconTiles, coor, tileMap);
        }

        public void ClearIconTileCache()
        {
            _iconTiles.Clear();
            ClearFinishedTileCache();
        }

        public void ClearIconTileCacheFor(HexCoordinate coor)
        {
            RemoveTile(_iconTiles, coor);
            RemoveTile(_finishedTiles, coor);
        }

        public Bitmap GetFinishedTile(HexCoordinate coor)
        {
            if (_finishedTiles.ContainsKey(coor.X) && _finishedTiles[coor.X].ContainsKey(coor.Y))
            {
                return _finishedTiles[coor.X][coor.Y];
            }
            return null;
        }

        public void SetFinishedTile(HexCoordinate coor, Bitmap tileMap)
        {
            SetTile(_finishedTiles, coor, tileMap);
        }

        public void ClearFinishedTileCache()
        {
            _finishedTiles.Clear();
        }

        public void ClearFinishedTileCacheForAreaAround(HexCoordinate centerCoordinate)
        {
            List<HexCoordinate> coordinates = PositionManager.GetTwoStepAreaAround(centerCoordinate);
            foreach (var coor in coordinates)
            {
                RemoveTile(_finishedTiles, coor);
            }
        }

        public Bitmap GetFogLessMap()
        {
            return _foglessMap;
        }

        public void SetFogLessMap(Bitmap foglessMap)
        {
            _foglessMap = foglessMap;
        }

        private void SetTile(Dictionary<long, Dictionary<long, Bitmap>> dict, HexCoordinate coor, Bitmap tileMap)
        {
            //Get or create the dictionary containing the y-coordinates for the specified x-coordinate
            Dictionary<long, Bitmap> yDict;
            if (dict.ContainsKey(coor.X))
            {
                yDict = dict[coor.X];
            }
            else
            {
                yDict = new Dictionary<long, Bitmap>();
                dict.Add(coor.X, yDict);
            }

            //Add the bitmap to the ydict
            if (yDict.ContainsKey(coor.Y))
            {
                yDict[coor.Y] = tileMap;
            }
            else
            {
                yDict.Add(coor.Y, tileMap);
            }
        }

        private void RemoveTile(Dictionary<long, Dictionary<long, Bitmap>> dict, HexCoordinate coor)
        {
            Dictionary<long, Bitmap> yDict;
            if (dict.ContainsKey(coor.X))
            {
                yDict = dict[coor.X];
                if (yDict.ContainsKey(coor.Y))
                {
                    yDict.Remove(coor.Y);
                    if (yDict.Count == 0)
                    {
                        dict.Remove(coor.X);
                    }
                }
            }
        }
    }
}
