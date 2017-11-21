using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using SnapCatch.Processing;

namespace SnapCatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var settingsWindow = new SettingsWindow();
            settingsWindow.Show();
            //            var screens = ScreenRepository.GetScreens();
            //            _tdWindows = new TopDrawWindow[screens.Length];
            //            for (var i = 0; i < screens.Length; i++)
            //            {
            //                var sc = screens[i];
            //                var tmWindow = new TopDrawWindow(sc);
            //                tmWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            //                tmWindow.Left = sc.ScreenItem.Bounds.Left;
            //                tmWindow.Top = sc.ScreenItem.Bounds.Top;
            //                tmWindow.Width = sc.ScreenItem.Bounds.Width;
            //                tmWindow.Height = sc.ScreenItem.Bounds.Height;
            //                tmWindow.ResizeMode = ResizeMode.NoResize;
            //#if !DEBUG
            //                tmWindow.Topmost = true;
            //#endif
            //                tmWindow.WindowStyle = WindowStyle.None;
            //                //var hwnd = new WindowInteropHelper(tmWindow).Handle;
            //                //SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
            //                _tdWindows[i] = tmWindow;
            //                tmWindow.Show();
            //                tmWindow.ScreenAreaCaptured += TmWindowOnScreenAreaCaptured;
        }
    }

    //private void TmWindowOnScreenAreaCaptured(ImageSource screenSnapshot)
    //{
    //    foreach (var topDrawWindow in _tdWindows)
    //    {
    //        topDrawWindow.Close();
    //    }

    //    var screenEditWindow = new ScreenEditorWindow();
    //    screenEditWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
    //    screenEditWindow.Show();
    //}
}

