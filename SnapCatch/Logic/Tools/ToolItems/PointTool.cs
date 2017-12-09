using SnapCatch.Resources;

namespace SnapCatch.Logic.Tools.ToolItems
{
    [SnapCatchTool(0)]
    public class PointTool : ToolBase
    {
        public PointTool(ViewportManager viewportManager, LayersManager layersManager) :
            base(ResourceConstants.PointerResource, ResourceConstants.PointerLangToolTip, ResourceConstants.PointerToolsGroup, layersManager, viewportManager)
        {
        }

    }
}
