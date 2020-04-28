using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class MenuItemGroup
    {
        private static readonly string prefix = "ant-menu-item-group";
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix);

        [Parameter] public RenderFragment Title { get; set; }
        [Parameter] public RenderFragment Children { get; set; }
    }
}
