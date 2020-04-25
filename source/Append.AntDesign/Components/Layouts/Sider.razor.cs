using Append.AntDesign.Core;
using Append.AntDesign.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class Sider
    {
        private static readonly string prefix = "ant-layout-sider";

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClass($"{prefix}-{Theme}")
                .AddClassWhen($"{prefix}-has-trigger", Collapsible)
                .AddClassWhen($"{prefix}-collapsed", Collapsed)
                .AddClassWhen($"{prefix}-zero-width", CollapsedWidth == 0 && Collapsed);

        private StyleBuilder styles => StyleBuilder.Create(Style)
                .AddStyle($"flex: 0 0 {width}px")
                .AddStyle($"max-width: {width}px")
                .AddStyle($"min-width: {width}px")
                .AddStyle($"width: {width}px");

        [Inject] public IWindowService WindowService { get; set; }
        [Parameter] public bool Collapsible { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Trigger { get; set; }
        [CascadingParameter] public Layout Parent { get; set; }
        [Parameter] public SiderBreakpoint Breakpoint { get; set; }
        [Parameter] public SiderTheme Theme { get; set; } = SiderTheme.Dark;
        [Parameter] public bool ShowTrigger { get; set; } = true;
        [Parameter] public int Width { get; set; } = 200;
        [Parameter] public int CollapsedWidth { get; set; } = 80;

        public event Action<bool> OnCollapsed;

        [Parameter] public bool Collapsed { get; set; }

        [Parameter] public EventCallback<bool> CollapsedChanged { get; set; }

        private int width => Collapsed ? CollapsedWidth : Width;

        private IconType triggerIcon => Collapsed ? IconType.Outlined.Right : IconType.Outlined.Left;

        private RenderFragment defaultTrigger => builder =>
        {
            builder.OpenComponent<Icon>(1);
            builder.AddAttribute(2, "Type", triggerIcon);
            builder.CloseComponent();
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Parent?.Subscribe(this);
            Trigger = defaultTrigger;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                var dimensions = await WindowService.GetDimensions();
                await WindowService.RegisterOnWindowResizeHandler(this);
                OptimizeSize(dimensions.Width);
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            NotifyObservers();
        }

        private void ToggleCollapsed()
        {
            Collapsed = !Collapsed;
            NotifyObservers();
        }
        private void NotifyObservers()
        {
            OnCollapsed?.Invoke(Collapsed);
        }

        private void OptimizeSize(int windowWidth)
        {
            if (windowWidth < Breakpoint?.Width)
                Collapsed = true;
            else
                Collapsed = false;

            NotifyObservers();
            StateHasChanged();
        }

        [JSInvokable]
        public void OnWindowResize(int windowWidth)
        {
            OptimizeSize(windowWidth);
        }
    }
}
