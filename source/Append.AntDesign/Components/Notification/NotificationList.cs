using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Append.AntDesign.Components
{
    internal class NotificationList
    {
        public List<NotificationListItem> notificationList = new List<NotificationListItem>();

        public NotificationList()
        {
        }

        public void Add(NotificationListItem notificationListItem) => notificationList.Add(notificationListItem);
        public void Update(Guid guid, Notification notification) => notificationList.FirstOrDefault(g => g.Guid.Equals(guid)).Notification = notification;

        public List<NotificationListItem> GetTopLeftNotifications()
        {
            return notificationList.Where(g => g.Notification.Options.Placement == NotificationPlacement.TopLeft).ToList();
        }

        public List<NotificationListItem> GetTopRightNotifications()
        {
            return notificationList.Where(g => g.Notification.Options.Placement == NotificationPlacement.TopRight).ToList();
        }

        public List<NotificationListItem> GetBottomLeftNotifications()
        {
            return notificationList.Where(g => g.Notification.Options.Placement == NotificationPlacement.BottomLeft).ToList();
        }

        public List<NotificationListItem> GetBottomRightNotifications()
        {
            return notificationList.Where(g => g.Notification.Options.Placement == NotificationPlacement.BottomRight).ToList();
        }

    }
}
