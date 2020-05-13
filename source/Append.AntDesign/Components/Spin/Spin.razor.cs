using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System.Drawing;

namespace Append.AntDesign.Components
{
    public partial class Spin
    {
        private static readonly string prefix = "ant-spin";

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClassWhen($"{prefix}-spinning", Spinning)
                .AddClassWhen($"{prefix}-{Size}",Size != Core.Size.Default)
                .AddClassWhen($"{prefix}-show-text", !string.IsNullOrWhiteSpace(Label));

        //[Parameter] public RenderFragment Indicator { get; set; }
        [Parameter] public bool Spinning { get; set; } = true;
        [Parameter] public Core.Size Size { get; set; } = Core.Size.Default;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Label { get; set; }

        private RenderFragment BuildDot => builder =>
        {
            builder.OpenElement(1, "span");
            builder.AddAttribute(2, "class", "ant-spin-dot ant-spin-dot-spin");
            builder.AddContent(3, BuildDotItem);
            builder.AddContent(4, BuildDotItem);
            builder.AddContent(5, BuildDotItem);
            builder.AddContent(6, BuildDotItem);
            builder.CloseElement();
        };

        private RenderFragment BuildDotItem => builder =>
        {
            builder.OpenElement(1, "i");
            builder.AddAttribute(2, "class", "ant-spin-dot-item");
            builder.CloseElement();
        };

        private RenderFragment BuildLabel => builder =>
        {
            if (string.IsNullOrWhiteSpace(Label))
                return;

            builder.OpenElement(1, "div");
            builder.AddAttribute(2, "class", "ant-spin-text");
            builder.AddContent(3, Label);
            builder.CloseElement();
        };
    }
}
