﻿using Append.AntDesign.Core;
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
        private ClassBuilder classes => ClassBuilder.Create()
            .AddClass("ant-notification-notice")
            .AddClass("ant-notification-notice-closable");


        private ClassBuilder ContentTypeClasses => ClassBuilder.Create()
            .AddClassWhen("ant-notification-notice-with-icon", Type != NotificationType.None);


        private string combinedClassBuilders => classes + " " + dynamicClasses;

        private StyleBuilder styles => StyleBuilder.Create();

        // bad
        private bool _hide;

        [CascadingParameter] private NotificationContainer notificationContainer { get; set; }
        [Parameter] public NotificationConfigOptions Options { get; set; }
        [Parameter] public NotificationType Type { get; set; } = NotificationType.None;

        protected override void OnInitialized()
        {

            AddOpenAndCloseAnimations();
        }

        private async void AddOpenAndCloseAnimations()
        {
            dynamicClasses = $"{baseClass}-fade-enter {baseClass}-fade-enter-active";
            StateHasChanged();
            await Task.Delay(new TimeSpan(0, 0, 0, 0, 500));
            dynamicClasses = "";

            if (Options.Duration != 0)
            {
                await Task.Delay(new TimeSpan(0, 0, 0, 0, Options.GetDurationInMilliseconds()));
                CloseNotification();
            }
        }

        internal async void CloseNotification()
        {
            dynamicClasses = $"{baseClass}-fade-leave {baseClass}-fade-leave-active";
            StateHasChanged();
            await Task.Delay(new TimeSpan(0, 0, 0, 0, 500));
            // bad
            _hide = true;
            StateHasChanged();
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
                return (IconType.Outlined.Info_Circle, "ant-notification-notice-icon ant-notification-notice-icon-info");
            }
            else if (Type == NotificationType.Success)
            {
                return (IconType.Outlined.Info_Circle, "ant-notification-notice-icon ant-notification-notice-icon-info");
            }
            else
            {
                return (IconType.Outlined.Exclamation_Circle, "ant-notification-notice-icon ant-notification-notice-icon-info");
            }
        }
    }
}
