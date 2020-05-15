using Append.AntDesign.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Append.AntDesign.Services.Notifications
{
    public class NotificationService : INotificationService
    {
        public NotificationGlobalConfigOptions GlobalConfigOptions { get; private set; }


        internal Dictionary<string, ElementReference> NotificationKeys { get; set; } = new Dictionary<string, ElementReference>();
        internal List<ValueTuple<ElementReference, RenderFragment, Notification>> NotificationRenderFragments { get; private set; } = new List<ValueTuple<ElementReference, RenderFragment, Notification>>();

        private Func<NotificationConfigOptions, NotificationConfigOptions> useDefinedGlobalOptions => options => options.GetConfigWithGlobalConfigValues(GlobalConfigOptions);







        /* ------------------ */

        private void Open(NotificationConfigOptions options, NotificationType notificationType)
        {
            ElementReference reference;
            Debug.WriteLine("");

        }

        public void Open(NotificationConfigOptions options)
        {
            Open(useDefinedGlobalOptions(options), NotificationType.None);
        }

        public void Info(NotificationConfigOptions options)
        {
            Open(useDefinedGlobalOptions(options), NotificationType.Info);
        }

        public void Success(NotificationConfigOptions options)
        {
            Open(useDefinedGlobalOptions(options), NotificationType.Success);
        }

        public void Error(NotificationConfigOptions options)
        {
            Open(useDefinedGlobalOptions(options), NotificationType.Error);
        }

        public void Warning(NotificationConfigOptions options)
        {
            Open(useDefinedGlobalOptions(options), NotificationType.Warning);
        }

        public void Warn(NotificationConfigOptions options)
        {
            Open(useDefinedGlobalOptions(options), NotificationType.Warn);
        }

        public void Close(string key)
        {

        }

        public void Destroy()
        {
            // removes all notifications
        }

        public void SetGlobalConfigOptions(NotificationGlobalConfigOptions globalConfigOptions)
        {
            GlobalConfigOptions = globalConfigOptions;
        }
    }
}
