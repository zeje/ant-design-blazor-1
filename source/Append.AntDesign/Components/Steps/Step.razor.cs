using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class Step
    {
        [Parameter] public string Description { get; set; } = string.Empty;
        [Parameter] public IconType Icon { get; set; }
        [Parameter] public StepStatus Status { get; set; } = StepStatus.Wait;
        [Parameter] public string Title { get; set; } = string.Empty;
        [Parameter] public string Subtitle { get; set; } = string.Empty;
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        string prefix = "ant-steps-item";

        private ClassBuilder classes => ClassBuilder.Create(prefix)
               .AddClass($"{prefix}-{Status}")
               .AddClassWhen($"{prefix}-disabled", Disabled)
               .AddClassWhen($"{prefix}-custom", Icon != null);

    }
}
