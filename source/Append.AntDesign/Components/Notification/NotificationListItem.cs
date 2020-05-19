
namespace Append.AntDesign.Components
{
    internal class NotificationListItem
    {
        internal NotificationConfigOptions Options { get; set; }
        internal Notification Notification { get; set; }

        internal NotificationListItem(NotificationConfigOptions options) => Options = options;
    }
}