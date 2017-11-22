using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SnapCatch.AdditionalPages.SettingsPages.SettingsItems
{
    public class SettingsDisplayItem
    {
        public SettingsDisplayItem(Visual visual, string name, Page page)
        {
            Visual = visual;
            Name = name;
            Page = page;
        }

        public Visual Visual { get; private set; }

        public string Name { get; private set; }

        public Page Page { get; private set; }
    }
}
