using Microsoft.AspNetCore.Components;
using System;

namespace Append.AntDesign.Components
{
    public class NotificationConfigOptions
    {
        public double? Bottom { get; set; }
        public RenderFragment Description { get; set; }
        public double? Duration { get; set; }
        public RenderFragment Icon { get; set; }
        public RenderFragment CloseIcon { get; set; }
        public string Key { get; set; }
        public RenderFragment Message { get; set; }
        public NotificationPlacement Placement { get; set; }
        public double? Top { get; set; }
        public string Style { get; set; }
        public string ClassName { get; set; }
        public RenderFragment CloseButton { get; set; }

        public Action OnClose { get; set; }
        public Action OnClick { get; set; }

        internal NotificationType Type { get; set; } = NotificationType.None;
        internal Guid Guid { get; set; } = Guid.NewGuid();

        internal int GetDurationInMilliseconds() => Convert.ToInt32(Duration * 1000);

        private NotificationConfigOptions() { }

        private NotificationConfigOptions(double? bottom, RenderFragment description, double? duration, RenderFragment icon, RenderFragment closeIcon, string key, RenderFragment message,
            NotificationPlacement placement, double? top, Action onClose, Action onClick, string style, string className, RenderFragment closeButton)
        {
            Bottom = bottom;
            Description = description;
            Duration = duration;
            Icon = icon;
            CloseIcon = closeIcon;
            Key = key;
            Message = message;
            Placement = placement;
            Top = top;
            OnClose = onClose;
            OnClick = onClick;
            Style = style;
            ClassName = className;
            CloseButton = closeButton;
        }

        internal NotificationConfigOptions WithGuid(Guid guid)
        {
            Guid = guid;
            return this;
        }

        internal NotificationConfigOptions GetConfigWithGlobalConfigValues(NotificationGlobalConfigOptions notificationGlobalConfig)
        {
            Bottom ??= notificationGlobalConfig.Bottom;
            CloseIcon ??= notificationGlobalConfig.CloseIcon;
            Duration ??= notificationGlobalConfig.Duration;
            Placement ??= notificationGlobalConfig.Placement;
            Top ??= notificationGlobalConfig.Top;
            return this;
        }

        public static NotificationConfigOptionsBuilder Builder() => new NotificationConfigOptionsBuilder();

        public class NotificationConfigOptionsBuilder
        {
            private double? _bottom;
            private RenderFragment _description;
            private double? _duration;
            private RenderFragment _icon;
            private RenderFragment _closeIcon;
            private string _key;
            private RenderFragment _message;
            private NotificationPlacement _placement;
            private double? _top;
            private string _style;
            private string _className;
            private RenderFragment _closeButton;

            private Action _onClose;
            private Action _onClick;

            public NotificationConfigOptionsBuilder SetBottom(double bottom)
            {
                _bottom = bottom;
                return this;
            }

            public NotificationConfigOptionsBuilder SetDescription(string description)
            {
                RenderFragment renderFragment = builder => builder.AddContent(0, description);
                _description = renderFragment;
                return this;
            }
            public NotificationConfigOptionsBuilder SetDescription(RenderFragment description)
            {
                _description = description;
                return this;
            }

            public NotificationConfigOptionsBuilder SetDuration(double duration)
            {
                if (duration < 0.5 && duration != 0)
                    throw new ArgumentOutOfRangeException("Duration must be >= 0.5 seconds");
                _duration = duration;
                return this;
            }
            public NotificationConfigOptionsBuilder SetIcon(RenderFragment icon)
            {
                _icon = icon;
                return this;
            }
            public NotificationConfigOptionsBuilder SetCloseIcon(RenderFragment closeIcon)
            {
                _closeIcon = closeIcon;
                return this;
            }
            public NotificationConfigOptionsBuilder SetKey(string key)
            {
                _key = key;
                return this;
            }

            public NotificationConfigOptionsBuilder SetMessage(string message)
            {
                RenderFragment renderFragment = builder => builder.AddContent(0, message);
                _message = renderFragment;
                return this;
            }
            public NotificationConfigOptionsBuilder SetMessage(RenderFragment message)
            {
                _message = message;
                return this;
            }

            public NotificationConfigOptionsBuilder SetPlacement(NotificationPlacement placement)
            {
                _placement = placement;
                return this;
            }
            public NotificationConfigOptionsBuilder SetTop(double top)
            {
                _top = top;
                return this;
            }
            public NotificationConfigOptionsBuilder SetStyle(string style)
            {
                _style = style;
                return this;
            }
            public NotificationConfigOptionsBuilder SetClassName(string className)
            {
                _className = className;
                return this;
            }
            public NotificationConfigOptionsBuilder SetCloseButton(RenderFragment closeButton)
            {
                _closeButton = closeButton;
                return this;
            }

            public NotificationConfigOptionsBuilder SetOnClose(Action onClose)
            {
                _onClose = onClose;
                return this;
            }
            public NotificationConfigOptionsBuilder SetOnClick(Action onClick)
            {
                _onClick = onClick;
                return this;
            }
            public NotificationConfigOptions Build() => new NotificationConfigOptions(_bottom, _description, _duration, _icon, _closeIcon, _key, _message, _placement, _top, _onClose, _onClick, _style, _className, _closeButton);
        }
    }
}