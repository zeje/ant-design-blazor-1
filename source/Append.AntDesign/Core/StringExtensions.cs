using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Append.AntDesign.Core
{
    public static class StringExtensions
    {
        public static string AddClassWhen(this string value, string cssClass, bool isValid)
        {
            if (isValid && !string.IsNullOrEmpty(value))
                return $"{value} {cssClass}";
            else if (isValid && string.IsNullOrEmpty(value))
                return cssClass;
            else
                return value;
        }
        public static string AddCssClass(this string value, string cssClass)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return $"{value} {cssClass}";
        }
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
        public static RenderFragment AsRenderFragment(this string value)
        {
            return builder =>
            {
                builder.AddContent(1, value);
            };
        }
        public static RenderFragment AsRenderFragment(this int value)
        {
            return builder =>
            {
                builder.AddContent(1, value);
            };
        }
    }
}
