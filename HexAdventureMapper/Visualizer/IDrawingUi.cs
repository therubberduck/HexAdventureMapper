using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexAdventureMapper.DataObjects;
using HexAdventureMapper.Views;

namespace HexAdventureMapper.Visualizer
{
    public interface IDrawingUi
    {
        MapBox GetMapBox();
        HexCoordinate GetSelectedCoordinate();

        int GetGmIconAlpha();
        int GetPlayerIconAlpha();
        int GetFogOfWarIconAlpha();
        int GetOverlayGridAlpha();
    }
}
