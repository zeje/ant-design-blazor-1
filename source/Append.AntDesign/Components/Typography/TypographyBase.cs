using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Append.AntDesign.Services;
using System.Threading.Tasks;
using System;

namespace Append.AntDesign.Components
{
    public abstract class TypographyBase : AntComponent
    {
        [Parameter] public bool Code { get; set; } = false;
        [Parameter] public bool Copyable { get; set; } = false;
        [Parameter] public string TextToCopy { get; set; } = null;
        [Parameter] public bool Delete { get; set; } = false;
        [Parameter] public bool Disabled { get; set; } = false;
        //[Parameter] public bool Editable { get; set; } = false;
        //[Parameter] public bool Ellipsis { get; set; } = false;
        [Parameter] public bool Mark { get; set; } = false;
        [Parameter] public bool Underline { get; set; } = false;
        [Parameter] public TypographyType Type { get; set; } = TypographyType.Default;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Inject] public IClipboardService Clipboard { get; set; }
        public abstract RenderFragment BuildTypographyComponent();

        protected static readonly string prefix = "ant-typography";
        protected string copyTooltipText = "Copy";
        protected bool isCopied = false;
        private ClassBuilder copyClasses => ClassBuilder.Create(Class)
                .AddClass($"{prefix}-copy");

        private StyleBuilder copyIconStyle => StyleBuilder.Create(Style)
                .AddStyle("border: 0px")
                .AddStyle("background: transparent")
                .AddStyle("padding: 0px")
                .AddStyle("line-height: inherit")
                .AddStyle("display: inline-block");

        protected async Task CopyText()
        {
            if (!Copyable)
                return;

            if (isCopied)
                return;

            if (string.IsNullOrEmpty(TextToCopy))
                throw new ArgumentException($"{nameof(TextToCopy)} has to be provided before copying.");

            await Clipboard.Copy(TextToCopy);
            copyTooltipText = "Copied!";
            isCopied = true;
            StateHasChanged();
            await Task.Delay(5000);
            ResetTooltip();
        }
        protected void ResetTooltip()
        {
            copyTooltipText = "Copy";
            isCopied = false;
        }
        protected RenderFragment BuildCopyContent()
        {
            if (!Copyable)
                return null;

            RenderFragment content = b =>
            {
                b.OpenComponent<Tooltip>(1);
                b.AddAttribute(2, "Title", copyTooltipText.AsRenderFragment());
                b.AddAttribute(3, "ChildContent", BuildCopyIcon());
                b.CloseComponent();
            };
            return content;
        }

        protected RenderFragment BuildCopyIcon()
        {
            RenderFragment icon = b =>
            {
                b.OpenElement(1, "div");
                b.AddAttribute(2, "role", "button");
                b.AddAttribute(3, "class", copyClasses);
                b.AddAttribute(4, "style", copyIconStyle);
                b.AddAttribute(5, "onclick", EventCallback.Factory.Create<Task>(this, CopyText));
                b.OpenComponent<Icon>(1);
                if (!isCopied)
                {
                    b.AddAttribute(6, "Type", IconType.Outlined.Copy);
                    b.AddAttribute(7, "Fill", "currentColor");
                }
                else
                {
                    b.AddAttribute(6, "Type", IconType.Outlined.Check);
                    b.AddAttribute(7, "Fill", "green");
                }
                b.CloseComponent();
                b.CloseElement();
            };
            return icon;
        }
    }
}
