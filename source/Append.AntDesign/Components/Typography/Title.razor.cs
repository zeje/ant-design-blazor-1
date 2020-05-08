using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Title : TypographyBase
    {
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClassWhen($"{prefix}-{Type}", Type != TypographyType.Default)
                .AddClassWhen($"{prefix}-disabled", Disabled);

        [Parameter] public TypographyTitleLevel Level { get; set; } = TypographyTitleLevel.H1;

        public override RenderFragment BuildTypographyComponent()
        {
            RenderFragment Typography;
            Typography = b =>
            {
                b.OpenElement(0, Level.Name);
                b.AddAttribute(1, "class", classes);
                if (Mark) b.OpenElement(2, "mark");
                if (Delete) b.OpenElement(3, "del");
                if (Underline) b.OpenElement(4, "u");
                if (Code) b.OpenElement(5, "code");
                b.AddContent(6, ChildContent);
                b.AddContent(8, BuildCopyContent());
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
