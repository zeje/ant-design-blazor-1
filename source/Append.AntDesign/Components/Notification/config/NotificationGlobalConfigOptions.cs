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

        public NotificationGlobalConfigOptions() { }
    }
}
