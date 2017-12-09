using SnapCatch.Resources;

namespace SnapCatch.Logic.Tools.ToolItems
{
    [SnapCatchTool(2)]
    public class LayerMoverTool : ToolBase
    {
        public LayerMoverTool(ViewportManager viewportManager, LayersManager layersManager)
            :base(ResourceConstants.PointerLayerMoverResource, ResourceConstants.PointerLayerMoverToolTip, ResourceConstants.PointerToolsGroup, layersManager, viewportManager)
        {
        }
    }
}
