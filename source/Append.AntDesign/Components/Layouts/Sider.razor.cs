using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Sider
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [CascadingParameter] public Layout Parent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Parent?.Subscribe(this);
        }
    }
}
