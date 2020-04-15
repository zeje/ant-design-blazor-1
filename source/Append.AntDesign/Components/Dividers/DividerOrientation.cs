using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public class DividerOrientation : SmartEnum<DividerOrientation>
    {
        public static DividerOrientation Left = new DividerOrientation(nameof(Left).ToLower(), 1);
        public static DividerOrientation Center = new DividerOrientation(nameof(Center).ToLower(), 2);
        public static DividerOrientation Right = new DividerOrientation(nameof(Right).ToLower(), 3);
        private DividerOrientation(string name, int value) : base(name, value)
        {
        }
    }
}
