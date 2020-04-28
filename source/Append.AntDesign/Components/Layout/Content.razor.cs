using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Content
    {
        private static readonly string prefix = "ant-layout-content";
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix);

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
