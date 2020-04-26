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
                .AddClassWhen($"{prefix}-collapsed", isCollapsed)
                .AddClassWhen($"{prefix}-zero-width", CollapsedWidth == 0 && isCollapsed);

        private StyleBuilder styles => StyleBuilder.Create(Style)
                .AddStyle($"flex: 0 0 {width}px")
                .AddStyle($"max-width: {width}px")
                .AddStyle($"min-width: {width}px")
                .AddStyle($"width: {width}px")
                //.AddStyleWhen("overflow:initial", isCollapsed)
                ;
        [Inject] public IWindowService WindowService { get; set; }
        [Parameter] public bool Collapsible { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Trigger { get; set; }
        [CascadingParameter] public Layout Parent { get; set; }
        [Parameter] public BreakpointType Breakpoint { get; set; }
        [Parameter] public SiderTheme Theme { get; set; } = SiderTheme.Dark;
        [Parameter] public int Width { get; set; } = 200;
        [Parameter] public int CollapsedWidth { get; set; } = 80;

        public event Action<bool> OnCollapsed;
        private bool isCollapsed;
        [Parameter]
        public bool Collapsed
        {
            get => isCollapsed;
            set
            {
                if (isCollapsed == value)
                    return;

                isCollapsed = value;
                NotifyObservers();
               
            }
        }

        [Parameter] public EventCallback<bool> CollapsedChanged { get; set; }

        private int width => isCollapsed ? CollapsedWidth : Width;

        private IconType triggerIcon => isCollapsed ? IconType.Outlined.Right : IconType.Outlined.Left;

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
            isCollapsed = Collapsed;
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
        }

        private void ToggleCollapsed()
        {
            isCollapsed = !isCollapsed;
            NotifyObservers();
        }
        private void NotifyObservers()
        {
            OnCollapsed?.Invoke(isCollapsed);
        }

        private void OptimizeSize(int windowWidth)
        {
            if (windowWidth < Breakpoint?.Width)
                isCollapsed = true;
            else
                isCollapsed = false;

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
