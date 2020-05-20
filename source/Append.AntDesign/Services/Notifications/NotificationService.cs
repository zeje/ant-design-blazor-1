using Append.AntDesign.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Append.AntDesign.Services.Notifications
{
    public class NotificationService
    {
        internal NotificationList Notifications { get; set; } = new NotificationList();
        internal event Action OnNotificationContainerCallChanges;
        internal NotificationGlobalConfigOptions GlobalConfigOptions { get; set; }

        private Func<NotificationConfigOptions, NotificationConfigOptions> useDefinedGlobalOptions => options => options.GetConfigWithGlobalConfigValues(GlobalConfigOptions);
        private Func<string, string, NotificationConfigOptions> buildOptionsWithMessageAndDescription => (message, description) => NotificationConfigOptions.Builder().SetMessage(message).SetDescription(description).Build();

        internal async Task Subscribe(Notification notification)
        {
            Notifications.Update(notification);
            await notification.ShowNotificationAnimation();
            bool notificationHasDuration = notification.Options.Duration != 0;
            if (notificationHasDuration)
                await Task.Delay(notification.Options.GetDurationInMilliseconds() - 500);
            if (!notification.HasClosed && notificationHasDuration)
                Unsubscribe(notification);
        }

        internal void NotifyChange()
        {
            OnNotificationContainerCallChanges.Invoke();
        }

        internal async Task Unsubscribe(Notification notification)
        {
            await notification.HideNotificationAnimation();
            notification.Options.OnClose?.Invoke();
            Notifications.Remove(notification);
            OnNotificationContainerCallChanges?.Invoke();
        }

        private void Open(NotificationConfigOptions options, NotificationType notificationType)
        {
            options.Type = notificationType;
            Notifications.Add(new NotificationListItem(options));
            OnNotificationContainerCallChanges?.Invoke();
        }

        public void Open(NotificationConfigOptions options) => Open(useDefinedGlobalOptions(options), NotificationType.None);
        public void Open(string message, string description) => Open(useDefinedGlobalOptions(buildOptionsWithMessageAndDescription(message, description)), NotificationType.None);

        public void Info(NotificationConfigOptions options) => Open(useDefinedGlobalOptions(options), NotificationType.Info);
        public void Info(string message, string description) => Open(useDefinedGlobalOptions(buildOptionsWithMessageAndDescription(message, description)), NotificationType.Info);

        public void Success(NotificationConfigOptions options) => Open(useDefinedGlobalOptions(options), NotificationType.Success);
        public void Success(string message, string description) => Open(useDefinedGlobalOptions(buildOptionsWithMessageAndDescription(message, description)), NotificationType.Success);

        public void Error(NotificationConfigOptions options) => Open(useDefinedGlobalOptions(options), NotificationType.Error);
        public void Error(string message, string description) => Open(useDefinedGlobalOptions(buildOptionsWithMessageAndDescription(message, description)), NotificationType.Error);

        public void Warning(NotificationConfigOptions options) => Open(useDefinedGlobalOptions(options), NotificationType.Warning);
        public void Warning(string message, string description) => Open(useDefinedGlobalOptions(buildOptionsWithMessageAndDescription(message, description)), NotificationType.Warning);

        public void Warn(NotificationConfigOptions options) => Warn(options);
        public void Warn(string message, string description) => Warning(message, description);

        public void Close(string key) => Unsubscribe(Notifications.Get(key).Notification);
        public void Destroy() => Notifications.notificationList.ForEach(g => Unsubscribe(g.Notification));
    }
}