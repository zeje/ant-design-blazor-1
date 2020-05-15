using Append.AntDesign.Services.Notifications;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Append.AntDesign.Components
{
    public partial class NotificationContainer
    {
        [Inject] private NotificationService notificationService { get; set; }

        private Dictionary<string, Guid> notificationKeys { get; set; } = new Dictionary<string, Guid>();
        private NotificationList notifications { get; set; } = new NotificationList();


        protected override void OnInitialized()
        {
            notificationService.NotificationContainer = this;

        }

        internal void OpenNotification(NotificationConfigOptions options, NotificationType notificationType)
        {
            Guid notificationGuid = Guid.NewGuid();
            RenderFragment notificationRenderFragment = builder =>
            {
                builder.OpenComponent<Notification>(0);
                builder.AddAttribute(1, "Options", options);
                builder.AddAttribute(2, "NotificationType", notificationType);
                builder.AddComponentReferenceCapture(3, (__value) =>
                {
                    notifications.Update(notificationGuid, (Notification)__value);
                });
                builder.CloseComponent();
            };

            if (!string.IsNullOrEmpty(options.Key))
                notificationKeys.Add(options.Key, notificationGuid);
            notifications.Add(new NotificationListItem(notificationGuid, null, notificationRenderFragment));

            StateHasChanged();
        }
        private void AddComponentToLists(Notification notification)
        {
            Debug.WriteLine("hi");

        }



        internal void CloseNotification(string key)
        {
            try
            {
                // notificationKeys.TryGetValue(key, out Notification value);
                // GetNotificationByReference(value).Item3.CloseNotification();
            }
            catch { throw new ArgumentException("This key does not exist"); }

        }

    }
}