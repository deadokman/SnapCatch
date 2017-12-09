using SnapCatch.Resources;

namespace SnapCatch.Logic.Tools.ToolItems
{
    [SnapCatchTool(1)]
    public class MoverTool : ToolBase
    {
        public MoverTool(ViewportManager viewportManager, LayersManager layersManager) 
            :base(ResourceConstants.PointerMoverResource, ResourceConstants.PointerMoverToolTip, ResourceConstants.PointerToolsGroup, layersManager, viewportManager)
        {

        }
    }
}
