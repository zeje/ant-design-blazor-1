using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Append.AntDesign.Components
{
    public partial class Alert
    {
        private const string alertPrefix = "ant-alert";
        private bool isClosing;

        private string classes =>
            alertPrefix
            .AddCssClass($"{alertPrefix}-{Type}")
            .AddClassWhen($"{alertPrefix}-no-icon", !ShowIcon)
            .AddClassWhen($"{alertPrefix}-closable", Closable)
            .AddClassWhen($"{alertPrefix}-with-description", Description != null)
            .AddClassWhen($"{alertPrefix}-banner", Banner)
            .AddClassWhen($"{alertPrefix}-closing", isClosing)
            .AddClassWhen($"{alertPrefix}-slide-up-leave", isClosing)
            .AddCssClass(Class);

        [Parameter] public AlertType Type { get; set; } = AlertType.Info;
        [Parameter] public RenderFragment Message { get; set; }
        [Parameter] public RenderFragment Description { get; set; }
        [Parameter] public IconType Icon { get; set; }
        [Parameter] public RenderFragment CloseText { get; set; }
        [Parameter] public bool ShowIcon { get; set; } = true;
        [Parameter] public bool Closable { get; set; }
        [Parameter] public bool Banner { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClose { get; set; }


        private RenderFragment BuildIcon => builder =>
        {
            if (!ShowIcon)
                return;

            IconType iconType = DetermineIconType();

            var additionalIconClasses = $"ant-alert-icon";
            builder.OpenComponent<Icon>(1);
            builder.AddAttribute(2, "Type", iconType);
            builder.AddAttribute(3, "Class", additionalIconClasses);
            builder.CloseComponent();
        };

        private IconType DetermineIconType()
        {

            if (Icon != null)
                return Icon; // Custom icon by the user

            bool withDescription = Description != null;

            if (Type == AlertType.Error && withDescription)
                return IconType.Outlined.Close_Circle;

            if (Type == AlertType.Success && withDescription)
                return IconType.Outlined.Check_Circle;

            if (Type == AlertType.Warning && withDescription)
                return IconType.Outlined.Exclamation_Circle;

            if (Type == AlertType.Info && withDescription)
                return IconType.Outlined.Info_Circle;

            // Without Description

            if (Type == AlertType.Error)
                return IconType.Filled.Close_Circle;

            if (Type == AlertType.Success)
                return IconType.Filled.Check_Circle;

            if (Type == AlertType.Warning)
                return IconType.Filled.Exclamation_Circle;

            return IconType.Filled.Info_Circle;
        }
        public void HandleClose(MouseEventArgs args)
        {
            isClosing = true;

            if (OnClose.HasDelegate)
                OnClose.InvokeAsync(args);
        }
    }
}
