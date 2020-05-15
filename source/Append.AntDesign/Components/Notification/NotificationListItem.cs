using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    internal class NotificationListItem
    {
        public Guid Guid { get; set; }
        public Notification Notification { get; set; }
        public RenderFragment RenderFragment { get; set; }

        public NotificationListItem(Guid guid, Notification notification, RenderFragment renderFragment)
        {
            Guid = guid;
            Notification = notification;
            RenderFragment = renderFragment;
        }
    }
}
