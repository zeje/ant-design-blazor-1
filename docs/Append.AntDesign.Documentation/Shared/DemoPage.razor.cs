using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.IO;
using System.Reflection;

namespace Append.AntDesign.Documentation.Shared
{
    public partial class DemoPage
    {
        [Parameter] public string ComponentName { get; set; }
        public MarkupString LoadMarkdownDocumentation()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"Append.AntDesign.Documentation.Components.{ComponentName}.Index.md";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            var indexOfAPI = result.IndexOf("# API");
            var beforeAPI = result.Substring(0, indexOfAPI);
            var afterApi = result.Substring(indexOfAPI);

            return (MarkupString)Markdown.ToHtml(beforeAPI, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
        }
        public MarkupString LoadMarkdownDocumentation2()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"Append.AntDesign.Documentation.Components.{ComponentName}.Index.md";

            using Stream stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);

            string result = reader.ReadToEnd();
            var indexOfAPI = result.IndexOf("# API");
            var beforeAPI = result.Substring(0, indexOfAPI);
            var afterApi = result.Substring(indexOfAPI);

            return (MarkupString)Markdown.ToHtml(afterApi, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
        }
    }
}
