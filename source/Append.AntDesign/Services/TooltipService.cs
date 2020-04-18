using Append.AntDesign.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Services
{
    public class TooltipService
    {
        public List<Tooltip> Tooltips { get; set; } = new List<Tooltip>();
        public event Action OnTooltipChanged;

        public void RegisterTooltip(Tooltip tooltip)
        {
            Tooltips.Add(tooltip);
        }
        public void Unregister(Tooltip tooltip)
        {
            Tooltips.Remove(tooltip);
        }

        public void NotifyChange(Tooltip tooltip)
        {
            OnTooltipChanged.Invoke();
        }
    }
}
