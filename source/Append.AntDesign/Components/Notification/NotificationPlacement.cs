using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class NotificationPlacement : SmartEnum<NotificationPlacement>
    {
        public static readonly NotificationPlacement TopLeft = new NotificationPlacement(nameof(TopLeft).ToLower(), 0);
        public static readonly NotificationPlacement TopRight = new NotificationPlacement(nameof(TopRight).ToLower(), 1);
        public static readonly NotificationPlacement BottomLeft = new NotificationPlacement(nameof(BottomLeft).ToLower(), 2);
        public static readonly NotificationPlacement BottomRight = new NotificationPlacement(nameof(BottomRight).ToLower(), 3);


        private NotificationPlacement(string name, int value) : base(name, value)
        {
        }
    }
}
