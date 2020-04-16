using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            .AddClassWhen("ant-tooltip-hidden", !DefaultVisible)
            .AddCssClass(Class);

        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Title { get; set; }
        [Parameter] public bool DefaultVisible { get; set; }
        [Parameter] public TooltipPlacement Placement { get; set; } = TooltipPlacement.Top;
        [Parameter] public int ShowDelay { get; set; } = 100;
        [Parameter] public int HideDelay { get; set; } = 100;
        [Parameter] public IEnumerable<TooltipTrigger> Triggers { get; set; }
        [Parameter] public EventCallback<bool> OnVisibilityChanged { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Triggers == null)
                Triggers = TooltipTrigger.DefaultTriggers;
            CheckContradictingTriggers();
        }

        private void CheckContradictingTriggers()
        {
            if (Triggers.Contains(TooltipTrigger.Click) && Triggers.Contains(TooltipTrigger.Focus))
                throw new ArgumentException($"The tooltip has contradicting triggers, you cannot use the {nameof(TooltipTrigger.Focus)} and {nameof(TooltipTrigger.Click)} at the same time, choose one.");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("antdesign.tooltip",
                                                  tooltipElementReference
                                                , childElementReference
                                                , Placement.PopperName
                                                , ShowDelay
                                                , HideDelay
                                                , Triggers.Select(x => x.Name));
            }
        }
    }
}
