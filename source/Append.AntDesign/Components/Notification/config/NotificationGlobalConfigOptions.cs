using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public class NotificationGlobalConfigOptions
    {
        public double Bottom { get; set; } = 24;
        public RenderFragment CloseIcon { get; set; }
        public double Duration { get; set; } = 4.5;
        public NotificationPlacement Placement { get; set; } = NotificationPlacement.TopRight;
        public double Top { get; set; } = 24;

        private NotificationGlobalConfigOptions() { }
        private NotificationGlobalConfigOptions(double bottom, RenderFragment closeIcon, double duration, NotificationPlacement placement, double top)
        {
            Bottom = bottom;
            CloseIcon = closeIcon;
            Duration = duration;
            Placement = placement;
            Top = top;
        }

        public static NotificationGlobalConfigOptionsBuilder Builder() => new NotificationGlobalConfigOptionsBuilder();

        public class NotificationGlobalConfigOptionsBuilder
        {
            private double _bottom = 24;
            private RenderFragment _closeIcon;
            private double _duration = 4.5;
            private NotificationPlacement _placement = NotificationPlacement.TopRight;
            private double _top = 24;

            public NotificationGlobalConfigOptionsBuilder SetBottom(double bottom)
            {
                _bottom = bottom;
                return this;
            }
            public NotificationGlobalConfigOptionsBuilder SetCloseIcon(RenderFragment closeIcon)
            {
                _closeIcon = closeIcon;
                return this;
            }
            public NotificationGlobalConfigOptionsBuilder SetDuration(double duration)
            {
                _duration = duration;
                return this;
            }
            public NotificationGlobalConfigOptionsBuilder SetPlacement(NotificationPlacement placement)
            {
                _placement = placement;
                return this;
            }
            public NotificationGlobalConfigOptionsBuilder SetTop(double top)
            {
                _top = top;
                return this;
            }
            public NotificationGlobalConfigOptions Build() => new NotificationGlobalConfigOptions(_bottom, _closeIcon, _duration, _placement, _top);
        }
    }
}
