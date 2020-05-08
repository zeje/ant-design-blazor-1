using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Paragraph : TypographyBase
    {
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClassWhen($"{prefix}-{Type}", Type != TypographyType.Default)
                .AddClassWhen($"{prefix}-disabled", Disabled);

        [Parameter] public bool Strong { get; set; } = false;

        public override RenderFragment BuildTypographyComponent()
        {
            RenderFragment Typography;
            Typography = b =>
            {
                b.OpenElement(0, "div");
                b.AddAttribute(1, "class", classes);
                if (Mark) b.OpenElement(2, "mark");
                if (Delete) b.OpenElement(3, "del");
                if (Underline) b.OpenElement(4, "u");
                if (Code) b.OpenElement(5, "code");
                if (Strong) b.OpenElement(6, "strong");
                b.AddContent(7, ChildContent);
                b.AddContent(8, BuildCopyContent());
                if (Strong) b.CloseElement();
                if (Code) b.CloseElement();
                if (Underline) b.CloseElement();
                if (Delete) b.CloseElement();
                if (Mark) b.CloseElement();
                b.CloseElement();
            };
            return Typography;
        }
    }
}