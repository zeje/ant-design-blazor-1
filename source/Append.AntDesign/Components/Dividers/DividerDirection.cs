using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public class DividerDirection : SmartEnum<DividerDirection>
    {
        public static DividerDirection Horizontal = new DividerDirection(nameof(Horizontal).ToLower(), 1);
        public static DividerDirection Vertical = new DividerDirection(nameof(Vertical).ToLower(), 2);
        private DividerDirection(string name, int value) : base(name, value)
        {
        }
    }
}
