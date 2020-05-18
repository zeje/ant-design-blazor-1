using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class Notification
    {
        private static readonly string baseClass = "ant-notification";

        private string dynamicClasses;
        private ClassBuilder classes => ClassBuilder.Create(Class)
            .AddClass("ant-notification-notice")
            .AddClass("ant-notification-notice-closable");

        private ClassBuilder ContentTypeClasses => ClassBuilder.Create()
            .AddClassWhen("ant-notification-notice-with-icon", Type != NotificationType.None || Options.Icon != null);

        private string combinedClassBuilders => classes + " " + dynamicClasses;

        [CascadingParameter] private NotificationContainer notificationContainer { get; set; }
        [Parameter] public Guid Guid { get; set; }
        [Parameter] public NotificationConfigOptions Options { get; set; }
        [Parameter] public NotificationType Type { get; set; } = NotificationType.None;

        private bool _hasClosed;

        protected override void OnInitialized()
        {
            notificationContainer.AddNotificationReference(this);
            AddOpenAndCloseAnimations();
        }

        private async void AddOpenAndCloseAnimations()
        {
            dynamicClasses = $"{baseClass}-fade-enter {baseClass}-fade-enter-active";
            await InvokeAsync(() =>
             {
                 InvokeAsync(StateHasChanged);

             });
            await Task.Delay(500);
            dynamicClasses = "";

            if (Options.Duration != 0)
            {
                await Task.Delay(Options.GetDurationInMilliseconds());
                if (_hasClosed)
                    return;
                if (Options.Key == null)
                    notificationContainer.CloseNotification(Guid);
                else
                    notificationContainer.CloseNotification(Options.Key);
            }
        }

        internal async void CloseNotification()
        {
            _hasClosed = true;

            dynamicClasses = $"{baseClass}-fade-leave {baseClass}-fade-leave-active";
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
            await Task.Delay(500);
            if (Options.OnClose != null)
                Options.OnClose.Invoke();
        }

        private ValueTuple<IconType, string> GetIconTypeWithExtraCssClasses()
        {
            if (Type == NotificationType.Info)
            {
                return (IconType.Outlined.Exclamation_Circle, "ant-notification-notice-icon ant-notification-notice-icon-info");
            }
            else if (Type == NotificationType.Warn || Type == NotificationType.Warning)
            {
                return (IconType.Outlined.Exclamation_Circle, "ant-notification-notice-icon ant-notification-notice-icon-warning");
            }
            else if (Type == NotificationType.Error)
            {
                return (IconType.Outlined.Close_Circle, "ant-notification-notice-icon ant-notification-notice-icon-error");
            }
            else if (Type == NotificationType.Success)
            {
                return (IconType.Outlined.Check_Circle, "ant-notification-notice-icon ant-notification-notice-icon-success");
            }
            else
            {
                return (IconType.Outlined.Exclamation_Circle, "ant-notification-notice-icon ant-notification-notice-icon-info");
            }
        }




    }
}
