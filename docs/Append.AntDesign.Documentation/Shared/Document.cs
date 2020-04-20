using Markdig;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Append.AntDesign.Documentation.Shared
{
    public class Document
    {
        public MarkupString Content { get; set; }
        public Metadata Info { get; set; } = new Metadata();

        public class Metadata
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }
            [JsonPropertyName("order")]
            public int Order { get; set; }
        }
    }
    public class ComponentDocument : Document
    {
        public ComponentDocument()
        {

        }
        public MarkupString Api { get; set; }
        public IAsyncEnumerable<Example> Examples { get; set; }
        public ComponentDocument(string content, string api, IAsyncEnumerable<Example> examples)
        {
            Content = (MarkupString)Markdown.ToHtml(content, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
            Api = (MarkupString)Markdown.ToHtml(api, new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
            Examples = examples;
        }
    }
    public class Example
    {
        public string ComponentName { get; set; }
        public Type SampleComponent { get; set; }
        public string SampleCode { get; set; }
        public string ShowLink => $"https://github.com/Append-IT/ant-design-blazor/blob/master/docs/Append.AntDesign.Documentation/Components/{ComponentName}/{SampleComponent.Name}.razor";
        public string EditLink => $"https://github.com/Append-IT/ant-design-blazor/edit/master/docs/Append.AntDesign.Documentation/Components/{ComponentName}/{SampleComponent.Name}.razor";
        public string GitHubLink => $"https://github.com/Append-IT/ant-design-blazor/blob/master/docs/Append.AntDesign.Documentation/Components/{ComponentName}/{SampleComponent.Name}.razor";
    }
}
