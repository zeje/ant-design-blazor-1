using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Append.AntDesign.Documentation.Pages
{
    public partial class ComponentsPage
    {
        private string EditLink => $"https://github.com/Append-IT/ant-design-blazor/edit/master/docs/Append.AntDesign.Documentation/Components/{ComponentName}/Index.md";
        [Parameter] public string ComponentName { get; set; }
        public Type[] Examples { get; set; }
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
        public MarkupString LoadMarkdownApiDocumentation()
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

        protected override void OnParametersSet()
        {
            base.OnInitialized();
            GetAllExamples();
        }

        private void GetAllExamples()
        {
            var namespaceOfTheExamples = $"Append.AntDesign.Documentation.Components.{ComponentName}.Demo";

            Examples = GetTypesInNamespace(Assembly.GetExecutingAssembly(), namespaceOfTheExamples);
        }

        private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)
                        && t.BaseType == typeof(ComponentBase))
                      .ToArray();
        }
        private RenderFragment BuildExample(Type example) => builder =>
        {
            builder.OpenComponent(0, example);
            builder.CloseComponent();
        };
    }
}
