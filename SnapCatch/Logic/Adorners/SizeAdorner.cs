using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace SnapCatch.Logic.Adorners
{
    public class SizeAdorner : Adorner
    {
        private SizeChrome _chrome;
        private VisualCollection _visuals;
        private ContentControl _designerItem;

        protected override int VisualChildrenCount
        {
            get
            {
                return this._visuals.Count;
            }
        }

        public SizeAdorner(ContentControl designerItem)
            : base(designerItem)
        {
            SnapsToDevicePixels = true;
            _designerItem = designerItem;
            _chrome = new SizeChrome();
            _chrome.DataContext = designerItem;
            _visuals = new VisualCollection(this);
            _visuals.Add(this._chrome);
        }

        protected override Visual GetVisualChild(int index)
        {
            return _visuals[index];
        }

        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            _chrome.Arrange(new Rect(new Point(0.0, 0.0), arrangeBounds));
            return arrangeBounds;
        }
    }
}
