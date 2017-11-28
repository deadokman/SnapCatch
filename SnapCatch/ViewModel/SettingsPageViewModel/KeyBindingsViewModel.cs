using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GalaSoft.MvvmLight;
using SnapCatch.KeyHook;
using SnapCatch.Logic;

namespace SnapCatch.ViewModel.SettingsPageViewModel
{
    public class KeyBindingsViewModel : ViewModelBase
    {
        /// <summary>
        /// Выделен контрол скриннинга прямоугольной области
        /// </summary>
        private bool _isSquareAreaFocused;

        /// <summary>
        /// Выделен контрол сриннинга активного экрана
        /// </summary>
        private bool _isScreenAreaFocused;

        /// <summary>
        /// Дескриптор обработчика для квадратной области выделения
        /// </summary>
        private int _squareAreaFocusedHandle;

        /// <summary>
        /// Дескриптор обработчика для активного экрана
        /// </summary>
        private int _screenAreaFocusedHandle;

        public KeyBindingsViewModel()
        {
            _pressedKeys = new HashSet<Keys>();

            KeyBindsContainer container;
            if (KeyBindsHolder.TryGetBindingInfo(ActionTypes.SquareAreaScreenKey, out container))
            {
                _squareAreaText = container.KeybindsStr;
            }

            if (KeyBindsHolder.TryGetBindingInfo(ActionTypes.ActiveScreenScreenKey, out container))
            {
                _activeScreenText = container.KeybindsStr;
            }
        }

        private HashSet<Keys> _pressedKeys;
        private string _squareAreaText;
        private string _activeScreenText;


        private void HandleKeyboardEvent(KeyboardEventArgs e)
        {
            if (e.State == EState.Down)
            {
                _pressedKeys.Add(e.Key);
            }

            if (e.Type == EKeyType.Common && e.State == EState.Up && _pressedKeys.Any())
            {
                var kt = typeof(Keys);
                var sb = new StringBuilder();
                var fmtStr = "{0} +";
                var last = _pressedKeys.Last();
                foreach (var pressedKey in _pressedKeys)
                {
                    if (pressedKey == last)
                    {
                        fmtStr = "{0}";
                    }

                    var name = Enum.GetName(kt, pressedKey);
                    sb.Append(String.Format(fmtStr, name));
                }

                if (_isSquareAreaFocused)
                {
                    SquareAreaText = sb.ToString();
                }

                if (_isScreenAreaFocused)
                {
                    ActiveScreenText = sb.ToString();
                }

                _pressedKeys.Clear();
            }

            if (e.State == EState.Up)
            {
                _pressedKeys.Remove(e.Key);
            }

            e.Handled = true;
        }

        public string SquareAreaText
        {
            get { return _squareAreaText; }
            set
            {
                _squareAreaText = value;
                RaisePropertyChanged(() => SquareAreaText);
            }
        }

        public string ActiveScreenText
        {
            get { return _activeScreenText; }
            set
            {
                _activeScreenText = value;
                RaisePropertyChanged(() => ActiveScreenText);
            }
        }

        /// <summary>
        /// Контролл снимка прямоугольной области получил фокус
        /// </summary>
        public bool IsSquareAreaFocused
        {
            get { return _isSquareAreaFocused; }
            set
            {
                if (value)
                {
                    _squareAreaFocusedHandle = KeyboardMonitor.SubscribeExclusiveHandler(HandleKeyboardEvent);
                }
                else
                {
                    KeyboardMonitor.UnsubscribeExclusiveHandler(_squareAreaFocusedHandle);
                }

                _isSquareAreaFocused = value;
            }
        }

        /// <summary>
        /// Контролл снимка экрана получил фокус
        /// </summary>
        public bool IsScreenAreaFocused
        {
            get { return _isScreenAreaFocused; }
            set
            {
                if (value)
                {
                    _screenAreaFocusedHandle = KeyboardMonitor.SubscribeExclusiveHandler(HandleKeyboardEvent);
                }
                else
                {
                    KeyboardMonitor.UnsubscribeExclusiveHandler(_screenAreaFocusedHandle);
                }

                _isScreenAreaFocused = value;
            }
        }
    }
}
