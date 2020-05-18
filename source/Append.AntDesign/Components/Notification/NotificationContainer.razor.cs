using Append.AntDesign.Core;
using Append.AntDesign.Services.Notifications;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class NotificationContainer
    {
        [Inject] private NotificationService notificationService { get; set; }

        private Dictionary<string, Guid> notificationKeys { get; set; } = new Dictionary<string, Guid>();
        private NotificationList notifications { get; set; } = new NotificationList();
        private List<(NotificationPlacement, string)> notificationContainerClasses { get; set; } = new List<(NotificationPlacement, string)>() {
                                                                          (NotificationPlacement.TopRight, "ant-notification ant-notification-topRight"),
                                                                          (NotificationPlacement.TopLeft, "ant-notification ant-notification-topLeft"),
                                                                          (NotificationPlacement.BottomLeft, "ant-notification ant-notification-bottomLeft"),
                                                                          (NotificationPlacement.BottomRight, "ant-notification ant-notification-bottomRight") };

        protected override void OnInitialized()
        {
            notificationService.NotificationContainer = this;
        }

        internal void AddNotificationReference(Notification notification)
        {
            notifications.Get(notification.Guid).Notification = notification;
        }

        internal void OpenNotification(NotificationConfigOptions options, NotificationType notificationType)
        {
            if (options.Key == null ? false : notificationKeys.ContainsKey(options.Key))
            {
                notificationKeys.TryGetValue(options.Key, out Guid value);
                InvokeAsync(() =>
                {
                    notifications.Update(value, options, notificationType);
                    StateHasChanged();
                });
                return;
            }

            Guid notificationGuid = Guid.NewGuid();
            if (!string.IsNullOrEmpty(options.Key))
                notificationKeys.Add(options.Key, notificationGuid);
            InvokeAsync(() =>
            {
                notifications.Add(new NotificationListItem(notificationGuid, options, notificationType));
                StateHasChanged();
            });
        }

        internal void CloseNotification(string key)
        {
            try
            {
                notificationKeys.TryGetValue(key, out Guid value);
                CloseNotification(value);
                notificationKeys.Remove(key);
            }
            catch { throw new ArgumentException("This key does not exist"); }
        }

        internal void CloseNotification(Guid guid)
        {
            InvokeAsync(() =>
            {
                notifications.Get(guid).Notification.CloseNotification();
                notifications.Remove(guid);
                StateHasChanged();
            });
        }

        private string GenerateNotificationContainerStyle(NotificationPlacement notificationPlacement)
        {
            return StyleBuilder.Create()
                .AddStyleWhen("right: 0px", notificationPlacement == NotificationPlacement.TopRight || notificationPlacement == NotificationPlacement.BottomRight)
                .AddStyleWhen("left: 0px", notificationPlacement == NotificationPlacement.TopLeft || notificationPlacement == NotificationPlacement.BottomLeft)
                .AddStyleWhen("bottom: auto", notificationPlacement == NotificationPlacement.TopRight || notificationPlacement == NotificationPlacement.TopLeft)
                .AddStyleWhen("top: auto", notificationPlacement == NotificationPlacement.BottomRight || notificationPlacement == NotificationPlacement.BottomLeft)

                .AddStyleWhen($"top: {notifications.GetOptionsTop(notificationService.GlobalConfigOptions)}px", notificationPlacement == NotificationPlacement.TopRight || notificationPlacement == NotificationPlacement.TopLeft)
                .AddStyleWhen($"bottom: {notifications.GetOptionsBottom(notificationService.GlobalConfigOptions)}px", notificationPlacement == NotificationPlacement.BottomRight || notificationPlacement == NotificationPlacement.BottomLeft)
                .ToString();
        }
    }
}