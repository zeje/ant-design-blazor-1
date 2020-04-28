using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class Row
    {
        private static readonly string prefix = "ant-row";

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClassWhen($"{prefix}-{Justify}", Justify != null)
                .AddClassWhen($"{prefix}-{Align}", Align != null);



        private StyleBuilder styles => StyleBuilder.Create(Style);

        [Parameter] public Alignment Align { get; set; }
        [Parameter] public Justification Justify { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
