using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class MenuItem : IDisposable
    {
        private const string menuItemPrefix = "ant-menu-item";
        /// <summary>
        /// The actual css classes, combining Ant Design classes with the classes of the client.
        /// </summary>
        private string classes =>
            menuItemPrefix
            .AddClassWhen($"{menuItemPrefix}-selected",isSelected)
            .AddClassWhen($"{menuItemPrefix}-disabled",Disabled)
            + Class;

        [CascadingParameter] public Menu RootMenu { get; set; }
        [CascadingParameter] public SubMenu ParentMenu { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Key { get; set; }
        [Parameter] public bool Disabled { get; set; }
        private bool isSelected;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (string.IsNullOrWhiteSpace(Key))
                throw new ArgumentException($"Parameter {nameof(Key)} is required for a {nameof(MenuItem)}");

            RootMenu.OnItemSelected += Rerender;

            if (RootMenu.DefaultSelectedItems.Contains(Key))
                isSelected = true;
        }

        private void Rerender(string key)
        {
            if (key == Key)
                isSelected = true;
            else
                isSelected = false;
            
            StateHasChanged();
        }

        public async Task HandleOnClick()
        {
            RootMenu.SelectItem(Key);
            if (RootMenu.Mode != MenuMode.Inline)
                await ParentMenu.Collapse();

        }

        public void Dispose()
        {
            RootMenu.OnItemSelected -= Rerender;
        }
    }
}
