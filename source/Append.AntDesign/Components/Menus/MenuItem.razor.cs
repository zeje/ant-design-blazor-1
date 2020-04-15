using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class MenuItem
    {
        private const string menuItemPrefix = "ant-menu-item";
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private string classes =>
            menuItemPrefix
            .AddClassWhen($"{menuItemPrefix}-selected", IsSelected)
            .AddClassWhen($"{menuItemPrefix}-disabled", Disabled)
            .AddCssClass(Class);

        [CascadingParameter] public Menu RootMenu { get; set; }
        [CascadingParameter] public SubMenu ParentMenu { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Key { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClicked { get; set; }

        public bool IsSelected { get; private set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (string.IsNullOrWhiteSpace(Key))
                throw new ArgumentException($"Parameter {nameof(Key)} is required for a {nameof(MenuItem)}");

            RootMenu.MenuItems.Add(this);

            if (RootMenu.DefaultSelectedItems.Contains(Key))
                Select();
        }

        public async Task HandleOnClick(MouseEventArgs args)
        {
            if (!RootMenu.Selectable)
                return;

            RootMenu.SelectItem(this);

            if (OnClicked.HasDelegate)
                await OnClicked.InvokeAsync(args);

            if (ParentMenu == null)
                return;

            if (RootMenu.Mode != MenuMode.Inline)
            {
                await ParentMenu?.Collapse();
            }
        }
        public void Select()
        {
            IsSelected = true;
        }
        public void Deselect()
        {
            IsSelected = false;
        }
    }
}
