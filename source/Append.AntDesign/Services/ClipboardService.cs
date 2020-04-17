using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Append.AntDesign.Services
{
    public class ClipboardService : IClipboardService
    {
        private readonly IJSRuntime JSRuntime;
        public ClipboardService(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }
        public ValueTask Copy(string text)
        {
            return JSRuntime.InvokeVoidAsync("antdesign.tooltip", text);
        }
    }
}
