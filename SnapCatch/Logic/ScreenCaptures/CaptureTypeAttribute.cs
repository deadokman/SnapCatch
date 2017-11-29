using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapCatch.Logic.ScreenCaptures
{
    public class CaptureTypeAttribute :Attribute
    {
        public CaptureTypeAttribute(ActionTypes actionType)
        {
            ActionType = actionType;
        }

        public ActionTypes ActionType { get; private set; }
    }
}
