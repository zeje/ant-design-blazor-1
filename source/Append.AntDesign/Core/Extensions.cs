using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Core
{
    internal static class Extensions
    {
        internal static string GetStyle(this Dictionary<string, object> attributes)
        {
            var styles = attributes.GetValueOrDefault("style");

            if (styles is null)
                return string.Empty;

            return styles.ToString();
        }

        internal static string GetClass(this Dictionary<string, object> attributes)
        {
            var classes = attributes.GetValueOrDefault("class");

            if (classes is null)
                return string.Empty;

            return classes.ToString();
        }
    }
}
