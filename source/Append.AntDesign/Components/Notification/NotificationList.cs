using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        internal NotificationListItem Get(Guid guid) => notificationList.FirstOrDefault(g => g.Guid.Equals(guid));
        internal void Add(NotificationListItem notificationListItem) => notificationList.Add(notificationListItem);
        internal void Remove(Guid guid) => notificationList.Remove(notificationList.FirstOrDefault(g => g.Guid.Equals(guid)));

        internal List<NotificationListItem> GetNotificationsByPlacementType(NotificationPlacement notificationPlacement) => notificationList.Where(g => g.Options.Placement == notificationPlacement).ToList();

        internal void Update(Guid guid, NotificationConfigOptions options, NotificationType notificationType)
        {
            notificationList.FirstOrDefault(g => g.Guid.Equals(guid)).Options = options;
            notificationList.FirstOrDefault(g => g.Guid.Equals(guid)).NotificationType = notificationType;
        }


        internal double GetOptionsTop(NotificationGlobalConfigOptions notificationGlobalConfigOptions)
        {
            try
            {
                return notificationList.Where(g => g.Options.Placement == NotificationPlacement.TopLeft || g.Options.Placement == NotificationPlacement.TopRight).First().Options.Top.Value;
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException || ex is ArgumentNullException || ex is InvalidOperationException)
                    return notificationGlobalConfigOptions.Top;
                throw ex;
            }

        }

        internal double GetOptionsBottom(NotificationGlobalConfigOptions notificationGlobalConfigOptions)
        {
            try
            {
                return notificationList.Where(g => g.Options.Placement == NotificationPlacement.BottomLeft || g.Options.Placement == NotificationPlacement.BottomRight).First().Options.Bottom.Value;
            }
            catch (Exception ex)
            {
                if (ex is InvalidOperationException || ex is ArgumentNullException || ex is InvalidOperationException)
                    return notificationGlobalConfigOptions.Bottom;
                throw ex;
            }
        }

    }
}
