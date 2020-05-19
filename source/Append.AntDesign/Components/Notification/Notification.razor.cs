using Append.AntDesign.Core;
using Append.AntDesign.Services.Notifications;
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
            .AddClassWhen("ant-notification-notice-with-icon", Options.Type != NotificationType.None || Options.Icon != null);

        private string combinedClassBuilders => classes + " " + dynamicClasses;

        internal bool HasClosed { get; set; }

        [Inject] private NotificationService notificationService { get; set; }
        [Parameter] public NotificationConfigOptions Options { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            notificationService.Subscribe(this);
        }

        internal async Task ShowNotificationAnimation()
        {
            dynamicClasses = $"{baseClass}-fade-enter {baseClass}-fade-enter-active";
            //notificationService.NotifyChange();
            await Task.Delay(500);
            dynamicClasses = "";
            //notificationService.NotifyChange();
        }

        internal async Task HideNotificationAnimation()
        {
            HasClosed = true;
            dynamicClasses = $"{baseClass}-fade-leave {baseClass}-fade-leave-active";
            notificationService.NotifyChange();
            await Task.Delay(500);
        }

        private (IconType iconType, string cssClass) GetIconTypeWithExtraCssClasses()
        {
            if (Options.Type == NotificationType.Info)
            {
                return (IconType.Outlined.Exclamation_Circle, "ant-notification-notice-icon ant-notification-notice-icon-info");
            }
            else if (Options.Type == NotificationType.Warn || Options.Type == NotificationType.Warning)
            {
                return (IconType.Outlined.Exclamation_Circle, "ant-notification-notice-icon ant-notification-notice-icon-warning");
            }
            else if (Options.Type == NotificationType.Error)
            {
                return (IconType.Outlined.Close_Circle, "ant-notification-notice-icon ant-notification-notice-icon-error");
            }
            else if (Options.Type == NotificationType.Success)
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
