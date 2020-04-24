using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Layout
    {
        private static readonly string prefix = "ant-layout";
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClassWhen($"{prefix}-has-sider", hasSider);

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

