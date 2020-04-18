using Append.AntDesign.Documentation.Pages;
using Append.AntDesign.Documentation.Shared;
using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace Append.AntDesign.Documentation.Infrastructure
{
    public class DocumentationService
    {
        private readonly HttpClient Client;

        public DocumentationService(HttpClient client, NavigationManager navigationManager)
        {
            client.BaseAddress = new Uri(navigationManager.BaseUri);
            Client = client;
        }

        public async Task<Document> ReadDocumentationFile(string documentName)
        {
            try
            {
                var normalizedDocumentName = NormalizedDocumentName(documentName);

                var fileStream = await Client.GetStreamAsync($"_content/Append.AntDesign.Documentation/docs/{normalizedDocumentName}.md");

                using StreamReader reader = new StreamReader(fileStream);
                reader.ReadLine();

                string result = await reader.ReadToEndAsync();
                var indexOfMetadataEnd = result.IndexOf("-->");

                var metadataString = result.Substring(0, indexOfMetadataEnd);
                var contentString = result.Substring(indexOfMetadataEnd + 3);
                var document = new Document();
                document.Info = ParseMetadata(metadataString);
                document.Content = (MarkupString)Markdown.ToHtml(contentString, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());

                return document;
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException($"Document file '{documentName}.md' was not found.", ex);
            }
        }
        private async Task<string> GetSampleAsync(string componentName, string demoName)
        {
            var content = await Client.GetStringAsync($"_content/Append.AntDesign.Documentation/examples/{componentName}/{demoName}.md");
            
            int indexOfDemoBegin = content.IndexOf("<Demo>") + 6;
            var sample = content.Substring(indexOfDemoBegin);

            sample = sample.Replace("</Codebox>", "");
            sample = sample.Replace("</Demo>", "");

            return sample;
        }

        public async Task<ComponentDocument> GetComponentDocumentation(string componentName)
        {
            var documentation = await Client.GetStringAsync($"_content/Append.AntDesign.Documentation/examples/{componentName}/Index.md");
            var indexOfAPI = documentation.IndexOf("# API");
            var beforeAPI = documentation.Substring(0, indexOfAPI);
            var afterApi = documentation.Substring(indexOfAPI);

            var examples = await GetAllExamplesForComponent(componentName);

            ComponentDocument doc = new ComponentDocument(beforeAPI,afterApi, examples);
            return doc;
        }

        private Document.Metadata ParseMetadata(string metadata)
        {
            return JsonSerializer.Deserialize<Document.Metadata>(metadata);
        }
        public string DetermineDocumentEditLink(string documentName)
        {
            var docName = NormalizedDocumentName(documentName);
            return $"https://github.com/Append-IT/ant-design-blazor/edit/master/docs/Append.AntDesign.Documentation/Docs/{docName}.md";
        }
        public string DetermineComponentEditLink(string componentName)
        {
            return $"https://github.com/Append-IT/ant-design-blazor/edit/master/docs/Append.AntDesign.Documentation/Components/{componentName}/Index.md";
        }

        private string NormalizedDocumentName(string originalDocumentName)
        {
            return originalDocumentName ?? "README";
        }

        private async Task<IEnumerable<Example>> GetAllExamplesForComponent(string componentName)
        {
            var namespaceOfTheExamples = $"Append.AntDesign.Documentation.Components.{componentName}";
            List<Example> examples = new List<Example>();
            foreach (var type in GetTypesInNamespace(Assembly.GetExecutingAssembly(), namespaceOfTheExamples))
            {
                var example = new Example()
                {
                    SampleComponent = type,
                    ComponentName = componentName,
                    SampleCode = await GetSampleAsync(componentName, type.Name),
                };
                examples.Add(example);
            }
            return examples;
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)
                        && t.BaseType == typeof(ComponentBase))
                      .ToArray();
        }
    }
}