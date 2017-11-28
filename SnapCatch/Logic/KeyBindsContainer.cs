using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnapCatch.Logic
{
    public class KeyBindsContainer
    {
        public HashSet<Keys> Keys { get; private set; }

        public string KeybindsStr { get; private set; }

        public ActionTypes ActionType { get; private set; }

        private PropertyInfo _propertyInfo;

        public void SetNewBinding(string str)
        {
            KeybindsStr = str;
            _propertyInfo.SetValue(Properties.Settings.Default, str);
            Properties.Settings.Default.Save();
        }

        public KeyBindsContainer(HashSet<Keys> keys, string keybindsStr, ActionTypes actionType, PropertyInfo settingInfo)
        {
            Keys = keys;
            KeybindsStr = keybindsStr;
            ActionType = actionType;
            _propertyInfo = settingInfo;
        }
    }
}
