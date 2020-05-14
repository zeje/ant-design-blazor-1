using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class StepsType : SmartEnum<StepsType>
    {
        public static readonly StepsType Default = new StepsType(nameof(Default).ToLower(), 1);
        public static readonly StepsType Navigation = new StepsType(nameof(Navigation).ToLower(), 2);

        private StepsType(string name, int value) : base(name, value)
        {
        }
    }
}
