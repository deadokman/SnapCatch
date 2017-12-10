using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using SnapCatch.Logic.Drawing;

namespace SnapCatch.Logic
{
    /// <summary>
    /// Manage layers, ordering and positioning
    /// </summary>
    public class LayersManager
    {
        /// <summary>
        /// Display layers collection
        /// </summary>
        public ObservableCollection<DrawingLayer> DrawingLayers { get; private set; }

        /// <summary>
        /// Reference to view port manager
        /// </summary>
        private ViewportManager _viewportManager;

        public LayersManager(ViewportManager viewPortManager)
        {
            _viewportManager = viewPortManager;
            DrawingLayers = new ObservableCollection<DrawingLayer>();
        }

        /// <summary>
        /// Current selected layer
        /// </summary>
        public DrawingLayer ActiveLayer { get; set; }

        /// <summary>
        /// Instance new layer from image source
        /// </summary>
        /// <param name="imgSource"></param>
        /// <returns></returns>
        public DrawingLayer AddNewLayer(ImageSource imgSource)
        {
            var layer = new DrawingLayer();
            if (!DrawingLayers.Any())
            {
                layer.Width = imgSource.Width;
                layer.Height = imgSource.Height;
                ActiveLayer = layer;
            }
            else
            {
                layer.Width = _viewportManager.WorkAreaWidth;
                layer.Height = _viewportManager.WorkAreaHeight;
            }

            layer.Top = 0;
            layer.Left = 0;
            //Add image as initial layer element
            var mt = new MovingImageThumb();
            mt.Source = imgSource;
            mt.Width = imgSource.Width;
            mt.Height = imgSource.Height;
            mt.Left = 0;
            mt.Top = 0;
            layer.ZIndex = DrawingLayers.Count;
            layer.AddItem(mt);
            DrawingLayers.Add(layer);
            return layer;
        }
    }
}
