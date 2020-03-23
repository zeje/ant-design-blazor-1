using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Documentation.Shared
{
    public partial class Codebox
    {
        [Parameter] public RenderFragment Demo { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public string Description { get; set; }
    }
}
