using Append.AntDesign.Documentation.Shared;
using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Append.AntDesign.Documentation.Pages
{
    public partial class DocumentationPage
    {
        private string EditLink => $"https://github.com/Append-IT/ant-design-blazor/edit/master/docs/Append.AntDesign.Documentation/Docs/{docNameOrDefault}.md";
        [Parameter] public string DocumentName { get; set; }
        private readonly Document doc = new Document();
        private string docNameOrDefault;

        public async Task LoadMarkdownDocumentation()
        {
            docNameOrDefault = DocumentName ?? "introduce";
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"Append.AntDesign.Documentation.Docs.{docNameOrDefault}.md";
            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);
            reader.ReadLine();
            string result = await reader.ReadToEndAsync();
            var indexOfMetadataEnd = result.IndexOf("-->");

            var metadataString = result.Substring(0, indexOfMetadataEnd);
            var contentString = result.Substring(indexOfMetadataEnd+3);

            doc.Info =  ParseMetadata(metadataString);
            doc.Content = (MarkupString)Markdown.ToHtml(contentString, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
        }

        private Document.Metadata ParseMetadata(string metadata)
        {
             return JsonSerializer.Deserialize<Document.Metadata>(metadata);
        }

        protected override async Task OnParametersSetAsync()
        {
            base.OnInitialized();
            await LoadMarkdownDocumentation();
        }
    }
}
