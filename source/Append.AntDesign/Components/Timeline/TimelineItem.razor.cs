using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;

namespace Append.AntDesign.Components
{
    public partial class TimelineItem : IDisposable
    {
        public static readonly string itemPrefix = "ant-timeline-item";
        public static readonly string dotPrefix = "ant-timeline-item-head";

        [Parameter] public RenderFragment Dot { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Label { get; set; }
        [Parameter] public TimelinePosition Position { get; set; }
        [Parameter] public TimelineColor Color { get; set; } = TimelineColor.Blue;
        [CascadingParameter] public Timeline Parent { get; set; }
        public bool IsLast { get; private set; }
        private TimelinePosition position;

        public ClassBuilder itemCssClasses => ClassBuilder.Create(Class)
               .AddClass(itemPrefix)
               .AddClassWhen($"{itemPrefix}-{position}", position != null)
               .AddClassWhen($"{itemPrefix}-last", IsLast);

        public ClassBuilder dotCssClasses => ClassBuilder.Create(dotPrefix)
            .AddClass($"{dotPrefix}-{Color}")
            .AddClassWhen($"{dotPrefix}-custom", Dot != null);

        protected override void OnInitialized()
        {
            if (Parent == null)
                throw new ArgumentException($"A {nameof(TimelineItem)} has to be contained in a ${nameof(Timeline)}.");

            Parent.Subscribe(this);
            UpdatePosition();
        }

        internal void UpdatePosition()
        {
            if(Position == null)
            {
                position = Parent.DetermineItemPosition(this);
            }
            else
            {
                position = Position;
            }
        }

        internal void UpdateIsLast(bool isLast)
        {
            IsLast = isLast;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            UpdatePosition();
        }

        public void Dispose()
        {
            Parent.Unsubscribe(this);
        }
    }
}
