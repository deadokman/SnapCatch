using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using SnapCatch.Resources;

namespace SnapCatch.Logic.Tools.ToolItems
{
    [SnapCatchTool(2)]
    public class LayerMoverTool : ToolBase
    {
        public LayerMoverTool()
            :base(ResourceConstants.PointerLayerMoverResource, ResourceConstants.PointerLayerMoverToolTip, ResourceConstants.PointerToolsGroup)
        {
        }
    }
}
