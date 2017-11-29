using System.Windows;
using System.Windows.Media;
using SnapCatch.Graphics.ScreenCaptureAssistance;
using SnapCatch.Processing;

namespace SnapCatch.Logic.ScreenCaptures
{
    [CaptureTypeAttribute(ActionTypes.SquareAreaScreenKey)]
    public class SquareAreaScreeenCapturer : IScreenCapturer
    {
        TopDrawWindow[] _tdWindows;

        public void InvokeCaptureScreen()
        {
            var screens = ScreenRepository.GetScreens();
            _tdWindows = new TopDrawWindow[screens.Length];
            for (var i = 0; i < screens.Length; i++)
            {
                var sc = screens[i];
                var tmWindow = new TopDrawWindow(sc);
                tmWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                tmWindow.Left = sc.ScreenItem.Bounds.Left;
                tmWindow.Top = sc.ScreenItem.Bounds.Top;
                tmWindow.Width = sc.ScreenItem.Bounds.Width;
                tmWindow.Height = sc.ScreenItem.Bounds.Height;
                tmWindow.ResizeMode = ResizeMode.NoResize;
#if !DEBUG
                tmWindow.Topmost = true;
#endif
                tmWindow.WindowStyle = WindowStyle.None;
                //var hwnd = new WindowInteropHelper(tmWindow).Handle;
                //SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
                _tdWindows[i] = tmWindow;
                tmWindow.Show();
                tmWindow.ScreenAreaCaptured += TmWindowOnScreenAreaCaptured;
            }
        }

        private void TmWindowOnScreenAreaCaptured(ImageSource screenSnapshot)
        {
            foreach (var topDrawWindow in _tdWindows)
            {
                topDrawWindow.Close();
            }


        }
    }
}
