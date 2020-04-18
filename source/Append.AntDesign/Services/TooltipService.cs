using Append.AntDesign.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Append.AntDesign.Services
{
    public class TooltipService
    {
        public List<Tooltip> Tooltips { get; set; } = new List<Tooltip>();
        public event Func<Tooltip,Task> OnTooltipChanged;
        public event Func<Tooltip,Task> OnTooltipUnregistered;

        public void RegisterTooltip(Tooltip tooltip)
        {
            Tooltips.Add(tooltip);
            OnTooltipChanged?.Invoke(tooltip);
        }
        public void Unregister(Tooltip tooltip)
        {
            Tooltips.Remove(tooltip);
            OnTooltipUnregistered?.Invoke(tooltip);
        }

        public void NotifyChange(Tooltip tooltip)
        {
            OnTooltipChanged?.Invoke(tooltip);
        }
    }
}
