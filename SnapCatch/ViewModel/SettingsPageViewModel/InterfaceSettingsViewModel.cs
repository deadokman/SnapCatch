using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using MahApps.Metro;
using SnapCatch.Properties;

namespace SnapCatch.ViewModel.SettingsPageViewModel
{
    public class InterfaceSettingsViewModel : ViewModelBase
    {
        private AppThemeMenuData _selectedAppTheme;
        private AccentColorMenuData _selectedAccent
            ;

        private CultureInfo _selectedLang;
        private string _langName;

        /// <summary>
        /// Avalilable accent colors
        /// Цвета акцента
        /// </summary>
        public List<AccentColorMenuData> AccentColors { get; set; }

        /// <summary>
        /// Avalilable base application themes
        /// Основные темы
        /// </summary>
        public List<AppThemeMenuData> AppThemes { get; set; }

        /// <summary>
        /// Languages
        /// </summary>
        public List<CultureInfo> AvailableLanguages { get { return App.Languages; } }

        public InterfaceSettingsViewModel()
        {
            AccentColors = ThemeManager.Accents
                .Select(a => new AccentColorMenuData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as SolidColorBrush })
                .ToList();
            AppThemes = ThemeManager.AppThemes
                .Select(a => new AppThemeMenuData() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as SolidColorBrush, ColorBrush = a.Resources["WhiteColorBrush"] as SolidColorBrush })
                .ToList();
            LoadDefaults();
        }

        /// <summary>
        /// Select base application theme
        /// Выбраная базовая тема
        /// </summary>
        public AppThemeMenuData SelectedAppTheme
        {
            get { return _selectedAppTheme; }
            set
            {
                _selectedAppTheme = value;
                RaisePropertyChanged(() => SelectedAppTheme);
                value.Apply();
            }
        }

        /// <summary>
        /// Selected accent
        /// Выбраная тема акциента
        /// </summary>
        public AccentColorMenuData SelectedAccent
        {
            get { return _selectedAccent; }
            set
            {
                _selectedAccent = value;
                RaisePropertyChanged(() => SelectedAccent);
                value.Apply();
            }
        }

        /// <summary>
        /// Selected lang
        /// </summary>
        public CultureInfo SelectedLang
        {
            get { return _selectedLang; }
            set
            {
                _selectedLang = value;
                RaisePropertyChanged(() => SelectedLang);
            }
        }

        private void LoadDefaults()
        {
            if (!this.IsInDesignMode)
            {
                SelectedAppTheme = AppThemes.FirstOrDefault(at => at.Name == App.SelectedAppTheme.Name);
                SelectedAccent = AccentColors.FirstOrDefault(ac => ac.Name == App.SelectedAccent.Name);
                SelectedLang = App.Language;
                App.LanguageChanged += AppOnLanguageChanged;
            }
        }

        public string LangName
        {
            get { return _langName; }
            set
            {
                _langName = value;
                RaisePropertyChanged(() => LangName);
            }
        }

        private void AppOnLanguageChanged(object sender, EventArgs e)
        {
            LangName = (string)Application.Current.Resources["gs_general"];
        }
    }
}
