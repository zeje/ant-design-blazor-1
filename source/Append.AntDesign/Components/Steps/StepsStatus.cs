using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class StepsStatus : SmartEnum<StepsStatus>
    {
        public static readonly StepsStatus Wait = new StepsStatus(nameof(Wait).ToLower(), 1);
        public static readonly StepsStatus Process = new StepsStatus(nameof(Process).ToLower(), 2);
        public static readonly StepsStatus Finish = new StepsStatus(nameof(Finish).ToLower(), 3);
        public static readonly StepsStatus Error = new StepsStatus(nameof(Error).ToLower(), 4);

        private StepsStatus(string name, int value) : base(name, value)
        {
        }
    }
}
