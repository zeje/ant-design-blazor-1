using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class InputSize : SmartEnum<InputSize>
    {
        public static readonly InputSize Large = new InputSize(nameof(Large).ToLower(), 1);
        public static readonly InputSize Middle = new InputSize(nameof(Middle).ToLower(), 2);
        public static readonly InputSize Small = new InputSize(nameof(Small).ToLower(), 3);

        private InputSize(string name, int value) : base(name, value)
        {
        }
    }
}
