using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class MenuItemGroup
    {
        private const string menuItemGroupPrefix = "ant-menu-item-group";
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private string classes =>
            menuItemGroupPrefix
            .AddCssClass(Class);

        [Parameter] public RenderFragment Title { get; set; }
        [Parameter] public RenderFragment Children { get; set; }
    }
}
