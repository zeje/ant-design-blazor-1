using Append.AntDesign.Services;
using Microsoft.AspNetCore.Components;
using System;

namespace Append.AntDesign.Components
{
    public partial class TooltipContainer : IDisposable
    {
        [Inject] public TooltipService TooltipService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            TooltipService.OnTooltipSubscribed += StateHasChanged;
            TooltipService.OnTooltipUnsubscribed += StateHasChanged;
            TooltipService.OnTooltipChanged += StateHasChanged;
        }

        public void Dispose()
        {
            TooltipService.OnTooltipSubscribed -= StateHasChanged;
            TooltipService.OnTooltipUnsubscribed -= StateHasChanged;
            TooltipService.OnTooltipChanged -= StateHasChanged;
        }
    }
}
