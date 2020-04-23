using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Footer
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
