using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;

namespace Append.AntDesign.Components
{
    public partial class Divider
    {
        private static string prefix = "ant-divider";
        [Parameter] public DividerDirection Direction { get; set; } = DividerDirection.Horizontal;
        [Parameter] public DividerOrientation Orientation { get; set; } = DividerOrientation.Center;
        [Parameter] public bool Dashed { get; set; }
        [Parameter] public string Label { get; set; }
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private ClassBuilder classes =>
            ClassBuilder.Create(Class)
            .AddClass(prefix)
            .AddClassWhen($"{prefix}-{Direction}", true)
            .AddClassWhen($"{prefix}-with-text-{Orientation}", !string.IsNullOrWhiteSpace(Label))
            .AddClassWhen($"{prefix}-dashed", Dashed);
    }
}
