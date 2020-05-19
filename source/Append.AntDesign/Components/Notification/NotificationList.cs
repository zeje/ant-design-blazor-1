using System;
using System.Collections.Generic;
using System.Linq;

namespace Append.AntDesign.Components
{
    internal class NotificationList
    {
        internal List<NotificationListItem> notificationList { get; private set; } = new List<NotificationListItem>();

        internal NotificationListItem Get(Guid guid) => notificationList.FirstOrDefault(g => g.Options.Guid.Equals(guid));
        internal NotificationListItem Get(string key) => notificationList.FirstOrDefault(g => g.Options.Key == key && !string.IsNullOrEmpty(g.Options.Key)) ?? throw new ArgumentException($"There is no notification with Key: \"{key}\" present.");
        internal List<NotificationListItem> GetNotificationsByPlacementType(NotificationPlacement notificationPlacement) => notificationList.Where(g => g.Options.Placement == notificationPlacement).ToList();

        internal void Add(NotificationListItem notificationListItem)
        {
            var notificationFound = notificationList.FirstOrDefault(g => g.Options.Key == notificationListItem.Options.Key && !string.IsNullOrEmpty(g.Options.Key));
            if (notificationFound == null)
                notificationList.Add(notificationListItem);
            else
                notificationFound.Options = notificationListItem.Options.WithGuid(notificationFound.Options.Guid);
        }
        internal void Update(Notification notification) => notificationList.FirstOrDefault(g => g.Options.Guid.Equals(notification.Options.Guid)).Notification = notification;
        internal void Remove(Notification notification) => notificationList.Remove(notificationList.FirstOrDefault(g => g.Notification.Equals(notification)));

        internal double GetOptionsTopDistance(NotificationGlobalConfigOptions notificationGlobalConfigOptions)
        {
            var notificationListItemFound = notificationList.FirstOrDefault(g => g.Options.Placement == NotificationPlacement.TopLeft || g.Options.Placement == NotificationPlacement.TopRight);
            if (notificationListItemFound != null)
                return notificationListItemFound.Options.Top.Value;
            return notificationGlobalConfigOptions.Top;
        }

        internal double GetOptionsBottomDistance(NotificationGlobalConfigOptions notificationGlobalConfigOptions)
        {
            var notificationListItemFound = notificationList.FirstOrDefault(g => g.Options.Placement == NotificationPlacement.BottomLeft || g.Options.Placement == NotificationPlacement.BottomRight);
            if (notificationListItemFound != null)
                return notificationListItemFound.Options.Bottom.Value;
            return notificationGlobalConfigOptions.Bottom;
        }
    }
}