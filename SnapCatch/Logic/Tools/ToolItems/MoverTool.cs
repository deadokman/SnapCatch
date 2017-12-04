using System;
using System.Windows;
using System.Windows.Shapes;
using SnapCatch.Resources;

namespace SnapCatch.Logic.Tools.ToolItems
{
    [SnapCatchTool(1)]
    public class MoverTool : ToolBase
    {
        public MoverTool() 
            :base(ResourceConstants.PointerMoverResource, ResourceConstants.PointerMoverToolTip, ResourceConstants.PointerToolsGroup)
        {

        }
    }
}
