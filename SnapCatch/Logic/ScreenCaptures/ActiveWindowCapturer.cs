using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapCatch.Logic.ScreenCaptures
{
    [CaptureType(ActionTypes.ActiveWindowScreenKey)]
    public class ActiveWindowCapturer : IScreenCapturer
    {
        public void InvokeCaptureScreen()
        {
            throw new NotImplementedException();
        }
    }
}
