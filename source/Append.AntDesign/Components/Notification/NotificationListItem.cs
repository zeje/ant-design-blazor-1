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
        public NotificationConfigOptions Options { get; set; }
        public bool Inactive { get; set; }

        internal NotificationListItem(Guid guid, Notification notification, RenderFragment renderFragment, NotificationConfigOptions options)
        {
            Guid = guid;
            Notification = notification;
            RenderFragment = renderFragment;
            Options = options;
        }

        internal NotificationListItem(Guid guid, RenderFragment renderFragment, NotificationConfigOptions options)
        {
            Guid = guid;
            RenderFragment = renderFragment;
            Options = options;
        }
    }
}
