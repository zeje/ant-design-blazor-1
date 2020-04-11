using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Append.AntDesign.Core;

namespace Append.AntDesign.Components
{
    public partial class Button
    {
        private string classes => "ant-btn"
            .AddClassWhen($"ant-btn-{Type}", Type != ButtonType.Default)
            .AddClassWhen($"ant-btn-{Size}", Size != ButtonSize.Default)
            .AddClassWhen($"ant-btn-loading", Loading);
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public ButtonType Type { get; set; } = ButtonType.Default;
        [Parameter] public ButtonSize Size { get; set; } = ButtonSize.Default;
        [Parameter] public bool Loading { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }


    }
}
