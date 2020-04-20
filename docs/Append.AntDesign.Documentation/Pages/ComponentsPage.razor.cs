using Append.AntDesign.Documentation.Infrastructure;
using Append.AntDesign.Documentation.Shared;
using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
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
        private ComponentDocument document = new ComponentDocument();
        private readonly List<Example> examples = new List<Example>();

        protected override async Task OnParametersSetAsync()
        {
            base.OnInitialized();
            document = await DocumentationService.GetComponentDocumentation(ComponentName);
            examples.Clear();
            await foreach (var example in document.Examples)
            {
                examples.Add(example);
                StateHasChanged();
            }
        }

        private RenderFragment BuildExample(Example example) => builder =>
        {
            builder.OpenComponent(0, example.SampleComponent);
            builder.SetKey(example);
            builder.CloseComponent();
        };
    }
}
