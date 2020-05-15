using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Append.AntDesign.Components
{
    public class NotificationConfigOptions
    {
        public double? Bottom { get; set; }// = 24;
        public RenderFragment Btn { get; set; }
        public string ClassName { get; set; }
        public RenderFragment Description { get; set; }
        public double? Duration { get; set; }// = 4.5;
        public RenderFragment Icon { get; set; }
        public RenderFragment CloseIcon { get; set; }
        public string Key { get; set; }
        public RenderFragment Message { get; set; }
        public string Placement { get; set; }// = "topRight";
        public string Style { get; set; }
        public double? Top { get; set; }// = 24;

        public EventCallback OnClose { get; set; }
        public EventCallback OnClick { get; set; }

        internal NotificationConfigOptions() { }

        internal NotificationConfigOptions GetConfigWithGlobalConfigValues(NotificationGlobalConfigOptions notificationGlobalConfig)
        {
            Bottom ??= notificationGlobalConfig.Bottom;
            CloseIcon ??= notificationGlobalConfig.CloseIcon;
            Duration ??= notificationGlobalConfig.Duration;
            Placement ??= notificationGlobalConfig.Placement;
            Top ??= notificationGlobalConfig.Top;
            return this;
        }

    }
}