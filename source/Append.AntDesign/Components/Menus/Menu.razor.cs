using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Append.AntDesign.Components
{
    public partial class Menu
    {
        private const string menuPrefix = "ant-menu";
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private string classes =>
            menuPrefix
            .AddCssClass($"{menuPrefix}-{Theme}")
            .AddCssClass($"{menuPrefix}-{Mode}")
            .AddClassWhen($"{menuPrefix}-inline-collapsed",Collapsed)
            .AddClassWhen($"{menuPrefix}-unselectable",!Selectable)
            .AddCssClass(Class);

        [Parameter] public MenuTheme Theme { get; set; } = MenuTheme.Light;
        [Parameter] public MenuMode Mode { get; set; } = MenuMode.Inline;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<SubMenu> OnSubmenuClicked { get; set; }
        [Parameter] public EventCallback<MenuItem> OnMenuItemClicked { get; set; }
        [Parameter] public IEnumerable<string> DefaultOpenSubMenus { get; set; } = new List<string>();
        [Parameter] public IEnumerable<string> DefaultSelectedItems { get; set; } = new List<string>();
        [Parameter] public bool Accordion { get; set; }
        [Parameter] public bool Selectable { get; set; } = true;
        [Parameter] public bool Collapsed { get; set; }
        private MenuMode initialMode;

        public List<SubMenu> Submenus { get; set; } = new List<SubMenu>();
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

        public void SelectItem(MenuItem item)
        {
            foreach (var menuitem in MenuItems.Where(x => x != item))
            {
                menuitem.Deselect();
            }

            if (item.IsSelected)
            {
                item.Deselect();
            }
            else
            {
                item.Select();
            }

            if(OnMenuItemClicked.HasDelegate)
                OnMenuItemClicked.InvokeAsync(item);

            StateHasChanged();
        }

        public void SelectSubmenu(SubMenu menu)
        {
            if (Accordion)
            {
                foreach (var item in Submenus.Where(x => x != menu && x != menu.Parent))
                {
                    item.Close();
                }
            }

            if (menu.IsOpen)
            {
                menu.Close();
            }
            else
            {
                menu.Open();
            }

            if (OnSubmenuClicked.HasDelegate)
                OnSubmenuClicked.InvokeAsync(menu);

            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Mode != MenuMode.Inline && Collapsed)
                throw new ArgumentException($"{nameof(Menu)} in the {Mode} mode cannot be {nameof(Collapsed)}");
            initialMode = Mode;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (Collapsed)
            {
                Mode = MenuMode.Vertical;
                foreach (var item in Submenus)
                {
                    item.Close();
                }
            }
            else
            {
                Mode = initialMode;
            }
        }
    }
}
