using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Append.AntDesign.Components
{
    public partial class Timeline
    {
        private string classes =>
            "ant-timeline"
             .AddCssClass(Class);

        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public TimelineMode Mode { get; set; }
        [Parameter] public bool Reverse { get; set; }
        [Parameter] public RenderFragment PendingDot { get; set; }
        [Parameter] public bool Pending { get; set; }

        private ICollection<TimelineItem> items = new List<TimelineItem>();

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public void Subscribe(TimelineItem item)
        {
            items.Add(item);
            StateHasChanged();
        }

        public void Unsubscribe(TimelineItem item)
        {
            items.Remove(item);
            StateHasChanged();
        }

    }
}
