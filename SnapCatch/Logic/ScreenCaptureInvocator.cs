using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using GalaSoft.MvvmLight.Ioc;
using SnapCatch.Logic.ScreenCaptures;
using SnapCatch.ViewModel;

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
                .Select(t =>
                {
                    var instance = (IScreenCapturer) Activator.CreateInstance(t); 
                    instance.CaptureScreen += OnCaptureScreen;
                    return new
                    {
                        attr = (CaptureTypeAttribute) t.GetCustomAttribute(attr),
                        instance
                    };
                }).ToDictionary(i => i.attr.ActionType, i => i.instance);
        }

        private void OnCaptureScreen(ImageSource img)
        {
            //throw new NotImplementedException();
            var mainEditorVm = SimpleIoc.Default.GetInstance<MainViewModel>();
            if (mainEditorVm != null)
            {
                mainEditorVm.ScreenCaptured(img);
            }
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

    public delegate void ScreenCaptured(ImageSource img);
}
