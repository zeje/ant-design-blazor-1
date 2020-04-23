using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Header
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
