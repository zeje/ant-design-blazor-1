using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class Column
    {
        private static readonly string prefix = "ant-col";

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClassWhen($"{prefix}-{Span}", Span != null)
                .AddClassWhen($"{prefix}-offset-{Offset}", Offset != null)
                .AddClassWhen($"{prefix}-push-{Push}", Push != null)
                .AddClassWhen($"{prefix}-pull-{Pull}", Pull != null)
                .AddClassWhen($"{prefix}-order-{Order}", Order != null)
                .AddClassWhen($"{Xs?.ToClasses(BreakpointType.Xs, prefix)}", Xs != null)
                .AddClassWhen($"{Sm?.ToClasses(BreakpointType.Sm, prefix)}", Sm != null)
                .AddClassWhen($"{Md?.ToClasses(BreakpointType.Md, prefix)}", Md != null)
                .AddClassWhen($"{Lg?.ToClasses(BreakpointType.Lg, prefix)}", Lg != null)
                .AddClassWhen($"{Xl?.ToClasses(BreakpointType.Xl, prefix)}", Xl != null)
                .AddClassWhen($"{Xxl?.ToClasses(BreakpointType.Xxl, prefix)}", Xxl != null);

        [Parameter] public int? Offset { get; set; }
        [Parameter] public int? Order { get; set; }
        [Parameter] public int? Pull { get; set; }
        [Parameter] public int? Push { get; set; }
        [Parameter] public int? Span { get; set; }
        [Parameter] public ResponsiveOptions Xs { get; set; }
        [Parameter] public ResponsiveOptions Sm { get; set; }
        [Parameter] public ResponsiveOptions Md { get; set; }
        [Parameter] public ResponsiveOptions Lg { get; set; }
        [Parameter] public ResponsiveOptions Xl { get; set; }
        [Parameter] public ResponsiveOptions Xxl { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
