using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Append.AntDesign.Core
{
    public static class Extensions
    {
        public static string AddStyle(this string value, string style)
        {
            if (string.IsNullOrEmpty(value))
                return style;

            return $"{value};{style}";
        }
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
