using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SnapCatch.Logic
{
    public static class KeyBindsHolder
    {
        private static Dictionary<ActionTypes, KeyBindsContainer> _keyPressHolder = new Dictionary<ActionTypes, KeyBindsContainer>();

        static KeyBindsHolder()
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
        }

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
