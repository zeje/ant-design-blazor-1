using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class InputGroup
    {
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass("ant-input-group")
                .AddClassWhen("ant-input-group-lg", Size == InputSize.Large)
                .AddClassWhen("ant-input-group-sm", Size == InputSize.Small)
                .AddClassWhen("ant-input-group-compact", Compact);

        [Parameter] public bool Compact { get; set; }
        [Parameter] public InputSize Size { get; set; } = InputSize.Middle;
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
