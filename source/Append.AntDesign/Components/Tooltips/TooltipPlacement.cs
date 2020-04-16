using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public class TooltipPlacement : SmartEnum<TooltipPlacement>
    {
        public string PopperName { get; private set; }
        public static TooltipPlacement Top = new TooltipPlacement(nameof(Top).ToLower(), nameof(Top).ToLower(), 1);
        public static TooltipPlacement Left = new TooltipPlacement(nameof(Left).ToLower(), nameof(Left).ToLower(), 2);
        public static TooltipPlacement Right = new TooltipPlacement(nameof(Right).ToLower(), nameof(Right).ToLower(), 3);
        public static TooltipPlacement Bottom = new TooltipPlacement(nameof(Bottom).ToLower(), nameof(Bottom).ToLower(), 4);
        public static TooltipPlacement TopLeft = new TooltipPlacement("topLeft", "top-start", 5);
        public static TooltipPlacement TopRight = new TooltipPlacement("topRight", "top-end", 6);
        public static TooltipPlacement BottomLeft = new TooltipPlacement("bottomLeft", "bottom-start", 7);
        public static TooltipPlacement BottomRight = new TooltipPlacement("bottomRight", "bottom-end", 8);
        public static TooltipPlacement LeftTop = new TooltipPlacement("leftTop", "left-start", 9);
        public static TooltipPlacement LeftBottom = new TooltipPlacement("leftBottom", "left-end", 10);
        public static TooltipPlacement RightTop = new TooltipPlacement("rightTop", "right-start", 11);
        public static TooltipPlacement RightBottom = new TooltipPlacement("rightBottom", "right-end", 12);

        private TooltipPlacement(string name, string popperName, int value) : base(name, value)
        {
            PopperName = popperName;
        }
    }
}
