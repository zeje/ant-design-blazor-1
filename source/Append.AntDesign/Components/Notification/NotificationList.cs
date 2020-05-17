using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Append.AntDesign.Components
{
    internal class NotificationList
    {
        internal List<NotificationListItem> notificationList = new List<NotificationListItem>();

        internal NotificationList()
        {
        }

        internal void Add(NotificationListItem notificationListItem) => notificationList.Add(notificationListItem);
        internal void Update(Guid guid, Notification notification) => notificationList.FirstOrDefault(g => g.Guid.Equals(guid)).Notification = notification;
        internal void Remove(Guid guid) => notificationList.FirstOrDefault(g => g.Guid.Equals(guid)).Inactive = true;

        internal List<NotificationListItem> GetTopLeftNotifications() => notificationList.Where(g => g.Options.Placement == NotificationPlacement.TopLeft).ToList();
        internal List<NotificationListItem> GetTopRightNotifications() => notificationList.Where(g => g.Options.Placement == NotificationPlacement.TopRight).ToList();
        internal List<NotificationListItem> GetBottomLeftNotifications() => notificationList.Where(g => g.Options.Placement == NotificationPlacement.BottomLeft).ToList();
        internal List<NotificationListItem> GetBottomRightNotifications() => notificationList.Where(g => g.Options.Placement == NotificationPlacement.BottomRight).ToList();
    }
}
