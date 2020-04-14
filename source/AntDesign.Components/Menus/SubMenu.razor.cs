using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class SubMenu 
    {
        private const string submenuPrefix = "ant-menu-submenu";
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private string classes =>
            submenuPrefix
            .AddCssClass($"{submenuPrefix}-{RootMenu.Mode}")
            .AddClassWhen($"{submenuPrefix}-open", isOpen)
            + Class;


        private string subMenuClasses =>
            "ant-menu"
            .AddCssClass("ant-menu-sub")
            .AddCssClass($"ant-menu-{(RootMenu.Mode == MenuMode.Horizontal ? MenuMode.Vertical : RootMenu.Mode)}")
            .AddClassWhen($"ant-menu-submenu-popup", RootMenu.Mode != MenuMode.Inline)
            .AddClassWhen($"ant-menu-hidden", !isOpen);


        [CascadingParameter] public Menu RootMenu { get; set; }
        [CascadingParameter] public SubMenu Parent { get; set; }
        [Parameter] public RenderFragment Title { get; set; }
        [Parameter] public RenderFragment Children { get; set; }
        [Parameter] public string Key { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnTitleClick { get; set; }
        private bool isOpen;
        public bool IsOpen => isOpen;

        private async Task HandleOnTitleClick(MouseEventArgs args)
        {
            RootMenu.SelectSubmenu(this);
            if (OnTitleClick.HasDelegate)
                await OnTitleClick.InvokeAsync(args);
        }
        private async Task HandleMouseOver(MouseEventArgs args)
        {
            if (RootMenu.Mode == MenuMode.Inline)
                return;

            isOpen = true;
        }
        private async Task HandleMouseOut(MouseEventArgs args)
        {
            if (RootMenu.Mode == MenuMode.Inline)
                return;

            isOpen = false;
        }
        public async Task Collapse()
        {
            await Task.Delay(300);
            isOpen = false;
            StateHasChanged();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (string.IsNullOrWhiteSpace(Key))
                throw new ArgumentException($"Parameter {nameof(Key)} is required for a {nameof(SubMenu)}");

            RootMenu.Submenus.Add(this);
            if (RootMenu.DefaultOpenSubMenus.Contains(Key))
                isOpen = true;
        }
        public void Close()
        {
            isOpen = false;
        }
        public void Open()
        {
            isOpen = true;
            if(Parent != null)
            {
                Parent.Open();
            }
        }
    }

}
