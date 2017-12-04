using System;
using System.Net.Mime;
using System.Windows;
using System.Windows.Shapes;
using SnapCatch.Resources;

namespace SnapCatch.Logic.Tools.ToolItems
{
    [SnapCatchTool(0)]
    public class PointTool : ToolBase
    {
        public PointTool() :
            base(ResourceConstants.PointerResource, ResourceConstants.PointerLangToolTip, ResourceConstants.PointerToolsGroup)
        {
        }

    }
}
