using Append.AntDesign.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class TooltipContainer : IDisposable
    {
        [Inject] public TooltipService TooltipService { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            TooltipService.OnTooltipChanged += UpdateTooltip;
            TooltipService.OnTooltipUnregistered += TooltipUnregistered;
        }

        public void Dispose()
        {
            TooltipService.OnTooltipChanged -= UpdateTooltip;
            TooltipService.OnTooltipUnregistered -= TooltipUnregistered;

        }

        public async Task TooltipUnregistered(Tooltip tooltip)
        {
            StateHasChanged();
            await DestroyPopper(tooltip);
        }

        public async Task UpdateTooltip(Tooltip tooltip)
        {
            if (tooltip.Visible)
            {
                await Task.Delay(tooltip.ShowDelay);
                StateHasChanged();
                await CreatePopper(tooltip);
            }
            else
            {
                await Task.Delay(tooltip.HideDelay);
                StateHasChanged();
                await DestroyPopper(tooltip);
            }
        }
        private ValueTask CreatePopper(Tooltip tooltip)
        {
            return JSRuntime.InvokeVoidAsync("antdesign.tooltip.create", tooltip.TooltipElementReference, tooltip.ChildElementReference, tooltip.Placement.PopperName, tooltip.Key);
        }
        private ValueTask DestroyPopper(Tooltip tooltip)
        {
            return JSRuntime.InvokeVoidAsync("antdesign.tooltip.destroy", tooltip.Key);
        }
    }
}
