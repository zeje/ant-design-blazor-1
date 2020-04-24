using Append.AntDesign.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Append.AntDesign.Services
{
    public class WindowService : IWindowService
    {
        private readonly IJSRuntime jsRuntime;

        public WindowService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public ValueTask<WindowDimension> GetDimensions()
        {
            return jsRuntime.InvokeAsync<WindowDimension>("antdesign.window.getDimensions");
        }

        public ValueTask RegisterOnWindowResizeHandler(AntComponent component)
        {
            var objRef = DotNetObjectReference.Create(component);
            return jsRuntime.InvokeVoidAsync("antdesign.window.registerOnResizeHandler", objRef);
        }

    }

    public class WindowDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
