using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class Breadcrumb
    {
        private static readonly string prefix = "ant-breadcrumb";

        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Separator { get; set; }

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix);

        private List<BreadcrumbItem> items = new List<BreadcrumbItem>();
        private string separator = "/";

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (Separator != null)
                separator = Separator;
        }

        public void Subscribe(BreadcrumbItem item)
        {
            items.Add(item);
        }
        public void Unsubscribe(BreadcrumbItem item)
        {
            items.Remove(item);
        }
    }
}
