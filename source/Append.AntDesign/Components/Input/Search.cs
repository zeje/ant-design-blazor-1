using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class Search : Input
    {

        protected override void OnInitialized()
        {
            Value = DefaultValue;
            Type = InputType.Search;

            if (EnterButton == null)
                SuffixIcon = SearchButtonIconTypeComputed;

            BuildRenderTree(new RenderTreeBuilder());
        }
    }
}
