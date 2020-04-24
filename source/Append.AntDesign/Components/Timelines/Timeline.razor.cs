using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Append.AntDesign.Components
{
    public partial class Timeline
    {
        private static readonly string prefix = "ant-timeline";
        private ClassBuilder classes => ClassBuilder.Create(Class)
            .AddClass(prefix)
            .AddClassWhen($"{prefix}-{Mode}", Mode != null && !hasLabels)
            .AddClassWhen($"{prefix}-label", hasLabels);

        /// <summary>
        /// Is needed to make it possible to put TimelineItems in the Timeline,
        /// but actuallt the <see cref="Timeline"/> takes control of the rendering.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public TimelineMode Mode { get; set; } = TimelineMode.Left;

        private List<TimelineItem> items = new List<TimelineItem>();

        private TimelinePosition currentItemPosition;
        private TimelineItem lastItem;
        private bool hasLabels;
        private TimelineMode previousMode;
        private bool ModeChanged => Mode != previousMode;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            previousMode = Mode;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (ModeChanged)
                ResetPositions();
        }

        private void ResetPositions()
        {
            currentItemPosition = null;
            foreach (var item in items)
            {
                item.UpdatePosition();
            }
            previousMode = Mode;
        }

        internal void Subscribe(TimelineItem item)
        {
            items.Add(item);
            if (item.Label != null)
                hasLabels = true;

            UpdateLastItem(item);
            StateHasChanged();
        }

        private void UpdateLastItem(TimelineItem item)
        {

            var previousLast = lastItem;
            lastItem = item;

            previousLast?.UpdateIsLast(false);
            lastItem.UpdateIsLast(true);
        }

        internal void Unsubscribe(TimelineItem item)
        {
            items.Remove(item);
        }

        internal TimelinePosition DetermineItemPosition(TimelineItem item)
        {
            if (Mode == TimelineMode.Left)
                return TimelinePosition.Left;

            if (Mode == TimelineMode.Right)
                return TimelinePosition.Right;

            if(currentItemPosition == null)
            {
                currentItemPosition = TimelinePosition.Left;
                return TimelinePosition.Left;
            }

            if (currentItemPosition == TimelinePosition.Left)
            {
                currentItemPosition = TimelinePosition.Right;
                return TimelinePosition.Right;
            }

            if (currentItemPosition == TimelinePosition.Right)
            {
                currentItemPosition = TimelinePosition.Left;
                return TimelinePosition.Left;
            }

            return item.Position;
        }

    }
}
