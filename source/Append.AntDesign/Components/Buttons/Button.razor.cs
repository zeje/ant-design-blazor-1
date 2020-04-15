using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Append.AntDesign.Components
{
    public partial class Button
    {
        private const string buttonPrefix = "ant-btn";
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private string classes => 
            buttonPrefix
            .AddClassWhen($"{buttonPrefix}-{Type}", Type != ButtonType.Default)
            .AddClassWhen($"{buttonPrefix}-{Size}", Size != ButtonSize.Default)
            .AddClassWhen($"{buttonPrefix}-{Shape}", Shape != ButtonShape.Default)
            .AddClassWhen($"{buttonPrefix}-loading", Loading)
            .AddClassWhen($"{buttonPrefix}-background-ghost", Ghost)
            .AddClassWhen($"{buttonPrefix}-dangerous", Danger)
            .AddClassWhen($"{buttonPrefix}-block", Block)
            .AddClassWhen($"{buttonPrefix}-icon-only", string.IsNullOrEmpty(Label) && ChildContent != null)
            + Class;

        [Parameter] public string Label { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public ButtonType Type { get; set; } = ButtonType.Default;
        [Parameter] public ButtonSize Size { get; set; } = ButtonSize.Default;
        [Parameter] public ButtonShape Shape { get; set; } = ButtonShape.Default;
        [Parameter] public bool Ghost { get; set; }
        [Parameter] public bool Loading { get; set; }
        [Parameter] public bool Block { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public bool Danger { get; set; }
        [Parameter] public string Href { get; set; }
        [Parameter] public string Target { get; set; }
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
