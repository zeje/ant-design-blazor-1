using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class NotificationType : SmartEnum<NotificationType>
    {
        public static readonly NotificationType None = new NotificationType(nameof(None).ToLower(), 0);
        public static readonly NotificationType Success = new NotificationType(nameof(Success).ToLower(), 1);
        public static readonly NotificationType Error = new NotificationType(nameof(Error).ToLower(), 2);
        public static readonly NotificationType Info = new NotificationType(nameof(Info).ToLower(), 3);
        public static readonly NotificationType Warning = new NotificationType(nameof(Warning).ToLower(), 4);
        public static readonly NotificationType Warn = new NotificationType(nameof(Warn).ToLower(), 5);
        public static readonly NotificationType Open = new NotificationType(nameof(Open).ToLower(), 6);
        public static readonly NotificationType Close = new NotificationType(nameof(Close).ToLower(), 7);
        public static readonly NotificationType Destroy = new NotificationType(nameof(Destroy).ToLower(), 8);

        private NotificationType(string name, int value) : base(name, value)
        {
        }
    }
}