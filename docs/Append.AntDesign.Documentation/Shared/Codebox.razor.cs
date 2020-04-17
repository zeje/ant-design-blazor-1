using Append.AntDesign.Documentation.Infrastructure;
using Append.AntDesign.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Append.AntDesign.Documentation.Shared
{
    public partial class Codebox
    {
        [CascadingParameter] public Example Example { get; set; }
        [Parameter] public RenderFragment Demo { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment Description { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }
        private bool isExpanded;

        private void ToggleExpand()
        {
            isExpanded = !isExpanded;
        }

    }
}
