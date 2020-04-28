using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public class TooltipTrigger : SmartEnum<TooltipTrigger>
    {
        public static IEnumerable<TooltipTrigger> DefaultTriggers { get; set; }

        public static TooltipTrigger Hover = new TooltipTrigger(nameof(Hover).ToLower(), 1);
        public static TooltipTrigger Focus = new TooltipTrigger(nameof(Focus).ToLower(), 2);
        public static TooltipTrigger Click = new TooltipTrigger(nameof(Click).ToLower(), 3);
        public static TooltipTrigger ContextMenu = new TooltipTrigger(nameof(ContextMenu).ToLower(), 4);

        private TooltipTrigger(string name, int value ) : base(name, value)
        {
        }
        /// <summary>
        /// Static constructor for the default values.
        /// </summary>
        static TooltipTrigger()
        {
            DefaultTriggers = new[] { Hover };
        }
    }
}
