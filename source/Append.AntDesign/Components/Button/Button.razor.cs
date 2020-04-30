using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Append.AntDesign.Components
{
    public partial class Button
    {
        private static readonly string prefix = "ant-btn";
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClassWhen($"{prefix}-{Type}", Type != ButtonType.Default)
                .AddClassWhen($"{prefix}-{Size}", Size != Size.Default)
                .AddClassWhen($"{prefix}-{Shape}", Shape != ButtonShape.Default)
                .AddClassWhen($"{prefix}-loading", Loading)
                .AddClassWhen($"{prefix}-background-ghost", Ghost)
                .AddClassWhen($"{prefix}-dangerous", Danger)
                .AddClassWhen($"{prefix}-block", Block)
                .AddClassWhen($"{prefix}-icon-only", string.IsNullOrEmpty(Label) && ChildContent != null);

        [Parameter] public string Label { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public ButtonType Type { get; set; } = ButtonType.Default;
        [Parameter] public Size Size { get; set; } = Size.Default;
        [Parameter] public ButtonShape Shape { get; set; } = ButtonShape.Default;
        [Parameter] public bool Ghost { get; set; }
        [Parameter] public bool Loading { get; set; }
        [Parameter] public bool Block { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public bool Danger { get; set; }
        [Parameter] public string Href { get; set; }
        [Parameter] public string HtmlType { get; set; } = "button";
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (!string.IsNullOrEmpty(Href) && OnClick.HasDelegate)
                throw new ArgumentException("You cannot provide a Href and OnClick Handler, please choose one.");
        }
    }
}
