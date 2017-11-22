using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using MahApps.Metro;
using SnapCatch.Properties;

namespace SnapCatch.ViewModel.SettingsPageViewModel
{
    public class AccentColorMenuData
    {
        public string Name { get; set; }
        public SolidColorBrush BorderColorBrush { get; set; }
        public SolidColorBrush ColorBrush { get; set; }

        /// <summary>
        /// Apply this theme to application
        /// </summary>
        public void Apply()
        {
            this.DoChangeTheme(this);
        }

        protected virtual void DoChangeTheme(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
            Settings.Default.AccentTheme = this.Name;
            Settings.Default.Save();
        }
    }
}
