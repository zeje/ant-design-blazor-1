using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Footer
    {
        private static readonly string prefix = "ant-layout-footer";
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix);

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
