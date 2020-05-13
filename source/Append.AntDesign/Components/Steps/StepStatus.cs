using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class StepStatus : SmartEnum<TagStatus>
    {
        public static readonly StepStatus Wait = new StepStatus(nameof(Wait).ToLower(), 1);
        public static readonly StepStatus Process = new StepStatus(nameof(Process).ToLower(), 2);
        public static readonly StepStatus Finish = new StepStatus(nameof(Finish).ToLower(), 3);
        public static readonly StepStatus Error = new StepStatus(nameof(Error).ToLower(), 4);

        private StepStatus(string name, int value) : base(name, value)
        {
        }
    }
}
