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
        [Inject] public GitHubService GitHubService { get; set; }
        private string EditLink => $"https://github.com/Append-IT/ant-design-blazor/edit/master/docs/Append.AntDesign.Documentation/Components/{ComponentName}/Demo/{Title}.razor";
        [CascadingParameter] public string ComponentName { get; set; }
        [Parameter] public RenderFragment Demo { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public RenderFragment Description { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        private string CodeSample;

        private bool isExpanded;

        private async Task ToggleExpand()
        {
            isExpanded = !isExpanded;
            if(isExpanded)
            {
                CodeSample = await GitHubService.GetSampleAsync(ComponentName, Title);
            }
            else
            {
                CodeSample = null;
            }
        }

    }
}
