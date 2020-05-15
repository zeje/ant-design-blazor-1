using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class Notification
    {
        private static readonly string baseClass = "ant-notification";

        private ClassBuilder classes => ClassBuilder.Create(Class);

        private StyleBuilder styles => StyleBuilder.Create();

        [CascadingParameter] private NotificationContainer notificationContainer { get; set; }
        [Parameter] public NotificationConfigOptions Options { get; set; }
        [Parameter] public NotificationType NotificationType { get; set; } = NotificationType.None;

        protected override void OnInitialized()
        {
            //notificationContainer.AddNotificationObjectToNotifications(this);
            Debug.WriteLine("hi");
        }

        internal void CloseNotification()
        {

        }

    }
}
