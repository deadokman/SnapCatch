using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SnapCatch.KeyHook;

namespace SnapCatch.Logic
{
    public static class KeyBindsEmitter
    {
        private static Dictionary<ActionTypes, KeyBindsContainer> _keyPressHolder = new Dictionary<ActionTypes, KeyBindsContainer>();

        private static HashSet<Keys>  _pressedKeys = new HashSet<Keys>();

        static KeyBindsEmitter()
        {
            var settingsType = typeof(Properties.Settings);
            foreach (var actionName in Enum.GetNames(typeof(ActionTypes)))
            {
                var property = settingsType.GetProperty(actionName, BindingFlags.Instance | BindingFlags.Public );
                if (property != null)
                {
                    var value = property.GetValue(Properties.Settings.Default) as string;
                    var keys = DeserializeKeyBindsHash(value);
                    ActionTypes atype;
                    Enum.TryParse(actionName, out atype);
                    _keyPressHolder.Add(atype, new KeyBindsContainer(keys, value, atype, property));
                }
            }
            //Добавить реакцию на нажатия кнопок
            KeyboardMonitor.SubscribeCommonHandler(KeyPressed);
        }

        public static void KeyPressed(KeyboardEventArgs e)
        {
            if (e.State == EState.Down)
            {
                _pressedKeys.Add(e.Key);
            }

            if (e.Type == EKeyType.Common && e.State == EState.Up && _pressedKeys.Any())
            {
                foreach (var keyBindsContainer in _keyPressHolder)
                {
                    if (keyBindsContainer.Value.Keys.SequenceEqual(_pressedKeys))
                    {
                        BindedKeyPress?.Invoke(keyBindsContainer.Key);
                    }
                }

                _pressedKeys.Clear();
            }

            if (e.State == EState.Up)
            {
                _pressedKeys.Remove(e.Key);
            }

            e.Handled = true;
        }

        /// <summary>
        /// Delegate for raising binded key pressing event
        /// </summary>
        /// <param name="type"></param>
        public delegate void KeyPressAction(ActionTypes type);

        /// <summary>
        /// Binded key press event
        /// </summary>
        public static event KeyPressAction BindedKeyPress;

        /// <summary>
        /// Try get bindings for action type
        /// </summary>
        /// <param name="atype"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public static bool TryGetBindingInfo(ActionTypes atype, out KeyBindsContainer container)
        {
            return _keyPressHolder.TryGetValue(atype, out container);
        }

        public static void CreateOrUpdateKeyBinding(string keys, ActionTypes type)
        {
            KeyBindsContainer container;
            if (_keyPressHolder.TryGetValue(type, out container))
            {
                container.SetNewBinding(keys);
            }
        }

        private static HashSet<Keys> DeserializeKeyBindsHash(string hashStr)
        {
            var res = new HashSet<Keys>();
            if (hashStr == null)
            {
                return res;
            }

            var keyNames = hashStr.Trim().Split('+');
            foreach (var keyName in keyNames)
            {
                Keys resKey;
                if (!Enum.TryParse(keyName, false, out resKey) || !res.Add(resKey))
                {
                    return new HashSet<Keys>();
                }
            }

            return res;
        }
    }
}
