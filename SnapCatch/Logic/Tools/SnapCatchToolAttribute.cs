using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapCatch.Logic.Tools
{
    public class SnapCatchToolAttribute : Attribute
    {
        public int OrderIndex { get; private set; }

        public SnapCatchToolAttribute(int order)
        {
            OrderIndex = order;
        }
    }
}
