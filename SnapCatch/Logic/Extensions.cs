using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnapCatch.Logic.Tools;

namespace SnapCatch.Logic
{
    public static class Extensions
    {
        public static void InsertInOrder(this List<ToolBase> tools, ToolBase tool)
        {
            if (!tools.Any())
            {
                tools.Add(tool);
            }

            var first = 0;
            var last = tools.Count - 1;
            while (first <= last)
            {
                var mid = (first + last) / 2;
                if (tool.DefaultOrder < tools[mid].DefaultOrder)
                {
                    first = mid + 1;
                }

                if (tool.DefaultOrder > tools[mid].DefaultOrder)
                {
                    last = mid - 1;
                }

                if (tool.DefaultOrder == tools[mid].DefaultOrder)
                {
                    var newIdx = mid - 1;
                    tools.Insert(newIdx, tool);
                    break;
                }
                else
                {
                    
                }
            }

            if (last == -1)
            {
                tools.Add(tool);
            }
            else
            {
                tools.Insert(last - 1, tool);
            }
        }
    }
}
