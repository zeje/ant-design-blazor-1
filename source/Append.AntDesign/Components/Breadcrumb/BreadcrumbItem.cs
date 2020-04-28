using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public class BreadcrumbItem : AntComponent, IDisposable
    {
        private static readonly string prefix = "ant-breadcrumb-item";
        internal ClassBuilder Classes => ClassBuilder.Create(Class)
                                         .AddClass(prefix);
            
        [CascadingParameter] public Breadcrumb Parent { get; set; }
        [Parameter] public string Href { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        protected override void OnInitialized()
        {
            if(Parent == null)
                throw new ArgumentException($"A {nameof(BreadcrumbItem)} has to be contained in a ${nameof(Breadcrumb)}.");

            base.OnInitialized();
            Parent.Subscribe(this);
        }
        public void Dispose()
        {
            Parent.Unsubscribe(this);
        }
    }
}
