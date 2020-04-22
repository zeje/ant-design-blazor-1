using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;

namespace Append.AntDesign.Components
{
    public partial class TimelineItem : IDisposable
    {
        private string classes =>
                "ant-timeline-item"
                .AddCssClass(Class);

        [Parameter] public RenderFragment Dot { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public TimelineLineItemPosition Position { get; set; }
        [Parameter] public TimeLineItemColor Color { get; set; }
        [CascadingParameter] public Timeline Parent { get; set; }

        protected override void OnInitialized()
        {
            if (Parent == null)
                throw new ArgumentException($"A {nameof(TimelineItem)} has to be contained in a ${nameof(Timeline)}.");

            Parent.Subscribe(this);
        }

        public void Dispose()
        {
            Parent.Unsubscribe(this);
        }
    }
}
