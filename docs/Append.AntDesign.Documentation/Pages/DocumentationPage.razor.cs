using Append.AntDesign.Documentation.Infrastructure;
using Append.AntDesign.Documentation.Shared;
using Markdig;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using System.Threading.Tasks;

namespace Append.AntDesign.Documentation.Pages
{
    public partial class DocumentationPage : ComponentBase
    {
        [Parameter] public string DocumentName { get; set; }
        private Document doc = new Document();
        [Inject] public DocumentationService DocumentationService { get; set; }

        private async Task LoadMarkdownDocumentation()
        {
            doc = await DocumentationService.ReadDocumentationFile(DocumentName);
        }

        protected override async Task OnParametersSetAsync()
        {
            await LoadMarkdownDocumentation();
        }
        private string EditLink => DocumentationService.DetermineDocumentEditLink(DocumentName);
    }
}
