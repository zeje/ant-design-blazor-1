using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Layout
    {
        private const string prefix = "ant-layout";
        private string classes =>
            prefix
            .AddClassWhen($"{prefix}-has-sider", hasSider)
            .AddCssClass(Class);

        [Parameter] public RenderFragment ChildContent { get; set; }
        private bool hasSider;
        
        internal void Subscribe(Sider sider)
        {
            hasSider = true;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
    }
}

