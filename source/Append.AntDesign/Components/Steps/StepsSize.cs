using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class StepsSize : SmartEnum<StepsSize>
    {
        public static readonly StepsSize Default = new StepsSize(nameof(Default).ToLower(), 1);
        public static readonly StepsSize Small = new StepsSize(nameof(Small).ToLower(), 2);

        private StepsSize(string name, int value) : base(name, value)
        {
        }
    }
}
