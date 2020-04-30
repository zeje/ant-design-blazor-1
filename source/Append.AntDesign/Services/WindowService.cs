using Append.AntDesign.Components;
using Append.AntDesign.Core;
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

        public ValueTask<Dimension> GetDimensions()
        {
            return jsRuntime.InvokeAsync<Dimension>("antdesign.window.getDimensions");
        }

        public ValueTask RegisterOnWindowResizeHandler(AntComponent component)
        {
            var objRef = DotNetObjectReference.Create(component);
            return jsRuntime.InvokeVoidAsync("antdesign.window.registerOnResizeHandler", objRef);
        }

    }
}
