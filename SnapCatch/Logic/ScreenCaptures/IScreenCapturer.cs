using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SnapCatch.Logic.ScreenCaptures
{
    public interface IScreenCapturer
    {
        void InvokeCaptureScreen();

        event ScreenCaptured CaptureScreen;
    }
}
