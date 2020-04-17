using Microsoft.AspNetCore.Components;
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
}
