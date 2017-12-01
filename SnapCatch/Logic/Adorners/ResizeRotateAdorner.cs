using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SnapCatch.Logic.Adorners
{
    public class ResizeRotateAdorner : Adorner
    {
        private VisualCollection _visuals;
        private ResizeRotateChrome _chrome;

        protected override int VisualChildrenCount
        {
            get
            {
                return this._visuals.Count;
            }
        }

        public ResizeRotateAdorner(ContentControl designerItem)
            : base(designerItem)
        {
            SnapsToDevicePixels = true;
            this._chrome = new ResizeRotateChrome();
            this._chrome.DataContext = designerItem;
            this._visuals = new VisualCollection(this);
            this._visuals.Add(this._chrome);
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            this._chrome.Arrange(new Rect(arrangeBounds));
            return arrangeBounds;
        }

        protected override Visual GetVisualChild(int index)
        {
            return this._visuals[index];
        }
    }
}
