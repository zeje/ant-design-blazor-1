using Append.AntDesign.Core;
using Append.AntDesign.Services.Notifications;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Append.AntDesign.Components
{
    public partial class NotificationContainer : IDisposable
    {
        private List<(NotificationPlacement placement, string cssClass)> positionalCssClasses { get; set; } = new List<(NotificationPlacement, string)>() {
                                                                          (NotificationPlacement.TopRight, "ant-notification ant-notification-topRight"),
                                                                          (NotificationPlacement.TopLeft, "ant-notification ant-notification-topLeft"),
                                                                          (NotificationPlacement.BottomLeft, "ant-notification ant-notification-bottomLeft"),
                                                                          (NotificationPlacement.BottomRight, "ant-notification ant-notification-bottomRight") };

        private Func<NotificationPlacement, string> notificationContainerStyles => notificationPlacement => StyleBuilder.Create()
                .AddStyleWhen("right: 0px", notificationPlacement == NotificationPlacement.TopRight || notificationPlacement == NotificationPlacement.BottomRight)
                .AddStyleWhen("left: 0px", notificationPlacement == NotificationPlacement.TopLeft || notificationPlacement == NotificationPlacement.BottomLeft)
                .AddStyleWhen("bottom: auto", notificationPlacement == NotificationPlacement.TopRight || notificationPlacement == NotificationPlacement.TopLeft)
                .AddStyleWhen("top: auto", notificationPlacement == NotificationPlacement.BottomRight || notificationPlacement == NotificationPlacement.BottomLeft)
                .AddStyleWhen($"top: {notificationService.Notifications.GetOptionsTopDistance(notificationService.GlobalConfigOptions)}px", notificationPlacement == NotificationPlacement.TopRight || notificationPlacement == NotificationPlacement.TopLeft)
                .AddStyleWhen($"bottom: {notificationService.Notifications.GetOptionsBottomDistance(notificationService.GlobalConfigOptions)}px", notificationPlacement == NotificationPlacement.BottomRight || notificationPlacement == NotificationPlacement.BottomLeft)
                .ToString();

        [Inject] private NotificationService notificationService { get; set; }
        [Parameter] public NotificationGlobalConfigOptions NotificationGlobalConfigOptions { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            notificationService.GlobalConfigOptions = NotificationGlobalConfigOptions ?? NotificationGlobalConfigOptions.Builder().Build();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            notificationService.OnNotificationContainerCallChanges += StateHasChanged;
        }

        public void Dispose() => notificationService.OnNotificationContainerCallChanges -= StateHasChanged;
    }
}