using System.Windows;
using System.Windows.Controls;
using SnapCatch.ViewModel.SettingsPageViewModel;

namespace SnapCatch.AdditionalPages.SettingsPages
{
    /// <summary>
    /// Interaction logic for KeyBindingsPage.xaml
    /// </summary>
    public partial class KeyBindingsPage : Page
    {
        public KeyBindingsPage()
        {
            InitializeComponent();
        }

        private void SquareScreenHotKey_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var dc = this.DataContext as KeyBindingsViewModel;
            if (dc != null)
            {
                dc.IsSquareAreaFocused = true;
            }
        }

        private void SquareScreenHotKey_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var dc = this.DataContext as KeyBindingsViewModel;
            if (dc != null)
            {
                dc.IsSquareAreaFocused = false;
            }
        }

        private void ActiveScreenHotKey_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var dc = this.DataContext as KeyBindingsViewModel;
            if (dc != null)
            {
                dc.IsScreenAreaFocused = true;
            }
        }

        private void ActiveScreenHotKey_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var dc = this.DataContext as KeyBindingsViewModel;
            if (dc != null)
            {
                dc.IsScreenAreaFocused = false;
            }
        }

        private void ActiveWindowHotKey_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var dc = this.DataContext as KeyBindingsViewModel;
            if (dc != null)
            {
                dc.IsActiveWindowFocused = true;
            }
        }

        private void ActiveWindowHotKey_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var dc = this.DataContext as KeyBindingsViewModel;
            if (dc != null)
            {
                dc.IsActiveWindowFocused = false;
            }
        }
    }
}
