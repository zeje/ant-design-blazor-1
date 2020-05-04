using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class SwitchSize : SmartEnum<IconType>
    {
        public static readonly SwitchSize Default = new SwitchSize(nameof(Default).ToLower(), 1);
        public static readonly SwitchSize Small = new SwitchSize(nameof(Small).ToLower(), 2);

        private SwitchSize(string name, int value) : base(name, value)
        {
        }
    }
}
