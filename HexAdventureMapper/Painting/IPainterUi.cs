using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HexAdventureMapper.Painting
{
    public interface IPainterUi
    {
        MainWindow.DrawingTools GetDrawingTool();

        int GetTerrainId();
        int GetVegetationId();
        int GetIconId();
        int GetPlayerIconId();
        int GetRiverId();
        int GetRoadId();
    }
}
