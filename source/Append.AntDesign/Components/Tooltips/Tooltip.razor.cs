using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class Tooltip 
    {
        private ElementReference tooltipElementReference;
        private ElementReference childElementReference;
        private const string tooltipPrefix = "ant-tooltip";

        private string classes =>
            tooltipPrefix
            .AddCssClass($"{tooltipPrefix}-placement-{Placement}")
            .AddClassWhen($"{tooltipPrefix}-hidden", !Visible)
            .AddClassWhen($"{tooltipPrefix}-hidden", !isInitialized)
            .AddCssClass(Class);

        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Title { get; set; }
        [Parameter] public bool Visible { get; set; }
        [Parameter] public TooltipPlacement Placement { get; set; } = TooltipPlacement.Top;
        [Parameter] public int ShowDelay { get; set; } = 100;
        [Parameter] public int HideDelay { get; set; } = 100;
        [Parameter] public IEnumerable<TooltipTrigger> Triggers { get; set; }
        [Parameter] public EventCallback<bool> OnVisibilityChanged { get; set; }
        private readonly string key = Guid.NewGuid().ToString();
        private bool isInitialized;

        private void CheckContradictingTriggers()
        {
            if (Triggers.Contains(TooltipTrigger.Click) && Triggers.Contains(TooltipTrigger.Focus))
                throw new ArgumentException($"The tooltip has contradicting triggers, you cannot use the {nameof(TooltipTrigger.Focus)} and {nameof(TooltipTrigger.Click)} at the same time, choose one.");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                isInitialized = true;
                if (Visible)
                {
                    await Show();
                    StateHasChanged();
                }
            }
        }
        private ValueTask CreatePopper()
        {
            return JSRuntime.InvokeVoidAsync("antdesign.tooltip.create", tooltipElementReference, childElementReference, Placement.PopperName, key);
        }

        private ValueTask DestroyPopper()
        {
            return JSRuntime.InvokeVoidAsync("antdesign.tooltip.destroy", key);
        }

        private async Task Show(bool notify = true)
        {
            await Task.Delay(ShowDelay);
            await CreatePopper();
            Visible = true;

            if (notify && OnVisibilityChanged.HasDelegate)
                await OnVisibilityChanged.InvokeAsync(Visible);
        }

        private async Task Hide(bool notify = true)
        {
            await Task.Delay(HideDelay);
            await DestroyPopper();
            Visible = false;
            if (notify && OnVisibilityChanged.HasDelegate)
                await OnVisibilityChanged.InvokeAsync(Visible);
        }

        public async Task HandleMouseEnter()
        {
            if (!Triggers.Contains(TooltipTrigger.Hover))
                return;

            await Show();
        }
        public async Task HandleMouseLeave()
        {
            if (!Triggers.Contains(TooltipTrigger.Hover))
                return;

            await Hide();
        }

        public async Task HandleFocusIn(FocusEventArgs args)
        {
            if (!Triggers.Contains(TooltipTrigger.Focus))
                return;

            await Show();
        }
        public async Task HandleFocusOut(FocusEventArgs args)
        {
            if (!Triggers.Contains(TooltipTrigger.Focus))
                return;

            await Hide();
        }
        public async Task HandleClick(MouseEventArgs args)
        {
            if (!Triggers.Contains(TooltipTrigger.Click))
                return;

            if (Visible)
                await Hide();
            else
                await Show();
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (Triggers == null)
                Triggers = TooltipTrigger.DefaultTriggers;

            CheckContradictingTriggers();

            if (isInitialized)
            {
                if (Visible)
                    await Show(notify:false);
                else
                    await Hide(notify:false);
            }
        }
    }
}
