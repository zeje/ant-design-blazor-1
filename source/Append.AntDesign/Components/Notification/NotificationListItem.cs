using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Append.AntDesign.Components
{
    internal class NotificationListItem
    {
        public Guid Guid { get; set; }
        public NotificationConfigOptions Options { get; set; }
        public NotificationType NotificationType { get; set; }

        internal NotificationListItem(Guid guid, NotificationConfigOptions options, NotificationType notificationType)
        {
            Guid = guid;
            Options = options;
            NotificationType = notificationType;
        }
    }
}
