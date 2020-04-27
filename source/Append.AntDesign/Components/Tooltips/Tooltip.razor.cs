using Append.AntDesign.Core;
using Append.AntDesign.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class Tooltip : IDisposable
    {
        public ElementReference TooltipElementReference { get; set; }
        public ElementReference ChildElementReference { get; set; }
        private static readonly string prefix = "ant-tooltip";

        public ClassBuilder Classes => ClassBuilder.Create(Class)
               .AddClass(prefix)
               //.AddClass($"{prefix}-placement-{Placement}")
               .AddClassWhen($"{prefix}-hidden", !IsVisible);

        [Inject] public TooltipService TooltipService { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Title { get; set; }
        [Parameter]
        public bool Visible
        {
            get => IsVisible;
            set
            {
                IsVisible = value;
            }
        }


        [Parameter] public EventCallback<bool> VisibleChanged { get; set; }
        [Parameter] public TooltipPlacement Placement { get; set; } = TooltipPlacement.Top;
        [Parameter] public int ShowDelay { get; set; } = 100;
        [Parameter] public int HideDelay { get; set; } = 100;
        [Parameter] public IEnumerable<TooltipTrigger> Triggers { get; set; }

        internal Guid Key { get; private set; } = Guid.NewGuid();
        internal bool IsVisible { get; private set; }
        private bool isSubscribed;

        protected override void OnInitialized()
        {
            IsVisible = Visible;
        }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (Triggers == null)
                Triggers = TooltipTrigger.DefaultTriggers;

            CheckContradictingTriggers();

            if (isSubscribed)
                await TooltipService.NotifyChange(this);

        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await TooltipService.Subscribe(this);
                isSubscribed = true;
            }
        }

        private void CheckContradictingTriggers()
        {
            if (Triggers.Contains(TooltipTrigger.Click) && Triggers.Contains(TooltipTrigger.Focus))
                throw new ArgumentException($"The tooltip has contradicting triggers, you cannot use the {nameof(TooltipTrigger.Focus)} and {nameof(TooltipTrigger.Click)} at the same time, choose one.");
        }
        private async Task Show()
        {
            IsVisible = true;
            await TooltipService.NotifyChange(this);
            if (VisibleChanged.HasDelegate)
                await VisibleChanged.InvokeAsync(IsVisible);
        }

        private async Task Hide()
        {
            IsVisible = false;
            await TooltipService.NotifyChange(this);
            await VisibleChanged.InvokeAsync(IsVisible);
        }

        public Task HandleMouseEnter()
        {
            if (!Triggers.Contains(TooltipTrigger.Hover))
                return Task.CompletedTask;

            return Show();
        }
        public Task HandleMouseLeave()
        {
            if (!Triggers.Contains(TooltipTrigger.Hover))
                return Task.CompletedTask;

            return Hide();
        }

        public Task HandleFocusIn(FocusEventArgs args)
        {
            if (!Triggers.Contains(TooltipTrigger.Focus))
                return Task.CompletedTask;

            return Show();
        }
        public Task HandleFocusOut(FocusEventArgs args)
        {
            if (Triggers.Contains(TooltipTrigger.Focus) || Triggers.Contains(TooltipTrigger.Click))
                return Hide();

            return Task.CompletedTask;
        }
        public Task HandleClick(MouseEventArgs args)
        {
            if (!Triggers.Contains(TooltipTrigger.Click))
                return Task.CompletedTask;

            if (IsVisible)
                return Hide();
            else
                return Show();
        }

        public void Dispose()
        {
            TooltipService?.Unsubscribe(this);
        }
    }
}
