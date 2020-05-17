using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Append.AntDesign.Components
{
    public class NotificationConfigOptions
    {
        public double? Bottom { get; set; }// = 24;
        public string ClassName { get; set; }
        public RenderFragment Description { get; set; }
        public double? Duration { get; set; }// = 4.5;
        public RenderFragment Icon { get; set; }
        public RenderFragment CloseIcon { get; set; }
        public string Key { get; set; }
        public RenderFragment Message { get; set; }
        public NotificationPlacement Placement { get; set; }// = "topRight";
        public string Style { get; set; }
        public double? Top { get; set; }// = 24;

        public EventCallback OnClose { get; set; }
        public EventCallback OnClick { get; set; }

        private NotificationConfigOptions() { }
        private NotificationConfigOptions(double? bottom, string className, RenderFragment description, double? duration, RenderFragment icon, RenderFragment closeIcon, string key, RenderFragment message, NotificationPlacement placement, string style, double? top, EventCallback onClose, EventCallback onClick)
        {
            Bottom = bottom;
            ClassName = className;
            Description = description;
            Duration = duration;
            Icon = icon;
            CloseIcon = closeIcon;
            Key = key;
            Message = message;
            Placement = placement;
            Style = style;
            Top = top;
            OnClose = onClose;
            OnClick = onClick;
        }

        internal int GetDurationInMilliseconds() => Convert.ToInt32(Duration * 1000);

        internal NotificationConfigOptions GetConfigWithGlobalConfigValues(NotificationGlobalConfigOptions notificationGlobalConfig)
        {
            Bottom ??= notificationGlobalConfig.Bottom;
            CloseIcon ??= notificationGlobalConfig.CloseIcon;
            Duration ??= notificationGlobalConfig.Duration;
            Placement ??= notificationGlobalConfig.Placement;
            Top ??= notificationGlobalConfig.Top;
            return this;
        }

        public static NotificationConfigOptionsBuilder Builder()
        {
            return new NotificationConfigOptionsBuilder();
        }

        public class NotificationConfigOptionsBuilder
        {
            private double? _bottom;// = 24;
            private string _className { get; set; }
            private RenderFragment _description { get; set; }
            private double? _duration { get; set; }// = 4.5;
            private RenderFragment _icon { get; set; }
            private RenderFragment _closeIcon { get; set; }
            private string _key;
            private RenderFragment _message { get; set; }
            private NotificationPlacement _placement { get; set; }// = "topRight";
            private string _style { get; set; }
            private double? _top { get; set; }// = 24;

            private EventCallback _onClose { get; set; }
            private EventCallback _onClick { get; set; }

            public NotificationConfigOptionsBuilder SetBottom(double bottom)
            {
                _bottom = bottom;
                return this;
            }
            public NotificationConfigOptionsBuilder SetClassName(string className)
            {
                _className = className;
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
            public NotificationConfigOptionsBuilder SetStyle(string style)
            {
                _style = style;
                return this;
            }
            public NotificationConfigOptionsBuilder SetPlacement(double top)
            {
                _top = top;
                return this;
            }
            public NotificationConfigOptionsBuilder SetOnClose(EventCallback onClose)
            {
                _onClose = onClose;
                return this;
            }
            public NotificationConfigOptionsBuilder SetOnClick(EventCallback onClick)
            {
                _onClick = onClick;
                return this;
            }

            public NotificationConfigOptions Build()
            {
                return new NotificationConfigOptions(_bottom, _className, _description, _duration, _icon, _closeIcon, _key, _message, _placement, _style, _top, _onClose, _onClick);
            }
        }
    }
}