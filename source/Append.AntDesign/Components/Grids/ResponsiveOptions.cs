using Append.AntDesign.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public class ResponsiveOptions
    {
        internal BreakpointType Breakpoint { get; set; }
        public int? Span { get; set; }
        public int? Offset { get; set; }
        public int? Pull { get; set; }
        public int? Push { get; set; }
        public int? Order { get; set; }

        public ResponsiveOptions(int? span = null, int? offset = null, int? pull = null, int? push = null, int? order = null)
        {
            Span = span;
            Offset = offset;
            Pull = pull;
            Push = push;
            Order = order;
        }
        internal ClassBuilder ToClasses(BreakpointType breakpoint, string prefix)
        {
            return ClassBuilder.Create()
            .AddClassWhen($"{prefix}-{breakpoint}-{Span}", Span != null)
            .AddClassWhen($"{prefix}-{breakpoint}-offset-{Offset}", Offset != null)
            .AddClassWhen($"{prefix}-{breakpoint}-pull-{Offset}", Pull != null)
            .AddClassWhen($"{prefix}-{breakpoint}-push-{Push}", Push != null)
            .AddClassWhen($"{prefix}-{breakpoint}-order-{Order}", Push != null);
        }
        public static implicit operator ResponsiveOptions(int val)
        {
            return new ResponsiveOptions(val);
        }
    }
}
