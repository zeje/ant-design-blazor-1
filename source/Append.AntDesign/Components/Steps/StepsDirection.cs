using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class StepsDirection : SmartEnum<StepsDirection>
    {
        public static readonly StepsDirection Horizontal = new StepsDirection(nameof(Horizontal).ToLower(), 1);
        public static readonly StepsDirection Vertical = new StepsDirection(nameof(Vertical).ToLower(), 2);

        private StepsDirection(string name, int value) : base(name, value)
        {
        }
    }
}
