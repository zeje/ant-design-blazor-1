using Microsoft.AspNetCore.Components;
using System;

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
