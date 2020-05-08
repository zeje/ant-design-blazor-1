using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class Password : Input
    {
        protected override void OnInitialized()
        {
            Value = DefaultValue;
            Type = InputType.Password;

            BuildRenderTree(new RenderTreeBuilder());
        }
    }
}
