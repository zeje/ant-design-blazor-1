using Append.AntDesign.Documentation.Infrastructure;
using Append.AntDesign.Documentation.Shared;
using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Append.AntDesign.Documentation.Pages
{

    public partial class ComponentsPage
    {
        [Inject] public DocumentationService DocumentationService { get; set; }
        [Parameter] public string ComponentName { get; set; }
        private string EditLink => DocumentationService.DetermineComponentEditLink(ComponentName);
        private ComponentDocument document;

        protected override async Task OnParametersSetAsync()
        {
            base.OnInitialized();
            document = await DocumentationService.GetComponentDocumentation(ComponentName);
        }

        private RenderFragment BuildExample(Example example) => builder =>
        {
            builder.OpenComponent(0, example.SampleComponent);
            builder.CloseComponent();
        };
    }
}
