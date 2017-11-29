using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SnapCatch.Logic.ScreenCaptures;

namespace SnapCatch.Logic
{
    public class ScreenCaptureInvocator
    {
        private Dictionary<ActionTypes, IScreenCapturer> _screenCapturers;

        public ScreenCaptureInvocator()
        {
            KeyBindsEmitter.BindedKeyPress += KeyBindsEmitterOnBindedKeyPress;
            //Load screen capturer from reflection
            Initialize();

        }

        private void Initialize()
        {
            var attr = typeof(CaptureTypeAttribute);
            var itype = typeof(IScreenCapturer);
            _screenCapturers = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttributes(attr, false).Any() && t.GetConstructor(Type.EmptyTypes) != null && t.GetInterface(itype.Name) != null)
                .Select(t => new { attr = (CaptureTypeAttribute)t.GetCustomAttribute(attr) , instance = (IScreenCapturer)Activator.CreateInstance(t) }).ToDictionary(i => i.attr.ActionType, i => i.instance);
        }

        private void KeyBindsEmitterOnBindedKeyPress(ActionTypes type)
        {
            IScreenCapturer capturer;
            if (_screenCapturers.TryGetValue(type, out capturer))
            {
                capturer.InvokeCaptureScreen();
            }
        }
    }
}
