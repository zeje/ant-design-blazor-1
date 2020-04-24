using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Append.AntDesign.Core
{
    public static class StringExtensions
    {
        public static string AddClassWhen(this string value, string cssClass, bool isValid)
        {
            if (isValid)
                return $"{value} {cssClass}";

            return value;
        }
        public static string AddCssClass(this string value, string cssClass)
        {
            return $"{value} {cssClass}";
        }
        public static string AddStyle(this string value, string style)
        {
            if(string.IsNullOrEmpty(value))
                return $"{style}";
            return $"{value};{style}";
        }
        internal static string GetStyles(this Dictionary<string,object> attributes)
        {
            var styles = attributes.GetValueOrDefault("style");
            if (styles is null)
                return string.Empty;
            return styles.ToString();
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
