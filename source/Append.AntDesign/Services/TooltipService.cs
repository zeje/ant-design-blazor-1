using Append.AntDesign.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Append.AntDesign.Services
{
    public class TooltipService
    {
        public List<Tooltip> Tooltips { get; set; } = new List<Tooltip>();
        public event Action OnTooltipSubscribed;
        public event Action OnTooltipUnsubscribed;
        public event Action OnTooltipChanged;
        private readonly IJSRuntime jsRuntime;

        public TooltipService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task Subscribe(Tooltip tooltip)
        {
            Tooltips.Add(tooltip);
            OnTooltipSubscribed?.Invoke();
            if (tooltip.IsVisible)
            {
                await Task.Delay(tooltip.ShowDelay);
                await CreatePopper(tooltip);
            }
        }
        public async Task Unsubscribe(Tooltip tooltip)
        {
            Tooltips.Remove(tooltip);
            OnTooltipUnsubscribed?.Invoke();
            await DestroyPopper(tooltip);
        }

        public async Task NotifyChange(Tooltip tooltip)
        {
            OnTooltipChanged.Invoke();
            await PositionTooltip(tooltip);
        }

        public async Task PositionTooltip(Tooltip tooltip)
        {
            if (tooltip.IsVisible)
            {
                await Task.Delay(tooltip.ShowDelay);
                await CreatePopper(tooltip);
            }
            else
            {
                await Task.Delay(tooltip.HideDelay);
                await DestroyPopper(tooltip);
            }
        }
        private ValueTask CreatePopper(Tooltip tooltip)
        {
            return jsRuntime.InvokeVoidAsync("antdesign.tooltip.create", tooltip.TooltipElementReference, tooltip.ChildElementReference, tooltip.Placement.PopperName, tooltip.Key);
        }
        private ValueTask DestroyPopper(Tooltip tooltip)
        {
            return jsRuntime.InvokeVoidAsync("antdesign.tooltip.destroy", tooltip.Key);
        }
    }
}
