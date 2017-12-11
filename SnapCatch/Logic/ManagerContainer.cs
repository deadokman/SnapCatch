using SnapCatch.Logic.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SnapCatch.Logic
{
    public class ManagerContainer
    {
        public ViewportManager ViewportManager { get; private set; }

        public LayersManager LayersManager { get; private set; }

        public ToolsManager ToolsManager { get; private set; }

        public ManagerContainer(ViewportManager viewportManager, LayersManager layersManager, ToolsManager toolsManager)
        {
            ViewportManager = viewportManager;
            LayersManager = layersManager;
            ToolsManager = toolsManager;

        }

    }
}
