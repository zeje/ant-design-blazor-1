using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class TextArea : Input
    {

        protected override void OnInitialized()
        {
            CalculateSize(null);
            Value = DefaultValue;
            Type = InputType.TextArea;

            BuildRenderTree(new RenderTreeBuilder());
        }
    }
}
