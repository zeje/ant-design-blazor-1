using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Append.AntDesign.Core
{
    internal static class Extensions
    {
        internal static string GetStyle(this Dictionary<string, object> attributes)
        {
            var styles = attributes.GetValueOrDefault("style");

            if (styles is null)
                return null;

            return styles.ToString();
        }

        internal static string GetClass(this Dictionary<string, object> attributes)
        {
            var classes = attributes.GetValueOrDefault("class");

            if (classes is null)
                return null;

            return classes.ToString();
        }
        internal static ValueTask<Dimension> GetDimension (this ElementReference element, IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeAsync<Dimension>("antdesign.element.getDimension",element);
        }
        internal static ValueTask Focus(this ElementReference element, IJSRuntime jsRuntime)
        {
            return jsRuntime.InvokeVoidAsync("antdesign.element.focus", element);
        }
    }
}
