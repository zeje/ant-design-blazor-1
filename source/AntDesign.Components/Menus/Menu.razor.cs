using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Append.AntDesign.Components
{
    public partial class Menu
    {
        public event Action<string> OnItemSelected;

        private const string menuPrefix = "ant-menu";
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private string classes =>
            menuPrefix
            .AddCssClass($"{menuPrefix}-{Theme}")
            .AddCssClass($"{menuPrefix}-{Mode}")
            .AddCssClass(Class);

        [Parameter] public MenuTheme Theme { get; set; } = MenuTheme.Light;
        [Parameter] public MenuMode Mode { get; set; } = MenuMode.Inline;
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public Action<IEnumerable<string>> OnOpenChanged { get; set; }
        [Parameter] public IEnumerable<string> DefaultOpenSubMenus { get; set; } = new List<string>();
        [Parameter] public IEnumerable<string> DefaultSelectedItems { get; set; } = new List<string>();

        public List<SubMenu> Submenus { get; set; } = new List<SubMenu>();

        [Parameter] public bool Accordion { get; set; }

        public void SelectItem(string key)
        {
            OnItemSelected?.Invoke(key);
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


            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
