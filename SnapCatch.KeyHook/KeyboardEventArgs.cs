using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnapCatch.KeyHook
{
    public enum EState
    {
        Down = 0,
        Up = 1
    }

    public enum EKeyType
    {
        Common = 0,
        System = 1
    }

    public class KeyboardEventArgs : EventArgs
    {
        public EState State { get; private set; }

        public EKeyType Type { get; private set; }

        public Keys Key { get; private set; }

        public bool Handled { get; set; }

        public KeyboardEventArgs(EState state, EKeyType type, Keys keys)
        {
            State = state;
            Type = type;
            Key = keys;
        }
    }
}
