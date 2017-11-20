using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Size = System.Drawing.Size;

namespace SnapCatch.Processing
{
    public static class ScreenRepository
    {

        public static ScreenSnapshot[] GetScreens()
        {
            SetDpiAwareness();
            var screens = new ScreenSnapshot[Screen.AllScreens.Length];
            ScreenSnapshot scr;
            for (int i = 0; i < screens.Length; i++)
            {
                var screenBounds = Screen.AllScreens[i];
                using (var screenBmp = new Bitmap(screenBounds.Bounds.Width, screenBounds.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                {
                    using (var bmpGraphics = System.Drawing.Graphics.FromImage(screenBmp))
                    {
                        bmpGraphics.CopyFromScreen(screenBounds.Bounds.Left, screenBounds.Bounds.Top, 0, 0, new Size(screenBounds.Bounds.Width, screenBounds.Bounds.Height));
                        var bmp =  Imaging.CreateBitmapSourceFromHBitmap(
                            screenBmp.GetHbitmap(),
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());
                        bmp.Freeze();
                        scr = new ScreenSnapshot(screenBounds, bmp);
                    }

                }

                screens[i] = scr;
            }

            return screens;
        }

        private enum ProcessDPIAwareness
        {
            ProcessDPIUnaware = 0,
            ProcessSystemDPIAware = 1,
            ProcessPerMonitorDPIAware = 2
        }

        [DllImport("shcore.dll")]
        private static extern int SetProcessDpiAwareness(ProcessDPIAwareness value);

        private static void SetDpiAwareness()
        {
            try
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    SetProcessDpiAwareness(ProcessDPIAwareness.ProcessPerMonitorDPIAware);
                }
            }
            catch (Exception)//this exception occures if OS does not implement this API, just ignore it.
            {
            }
        }
    }
}
