using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class Step : IDisposable
    {
        [Parameter] public string Description { get; set; } = string.Empty;
        [Parameter] public IconType Icon { get; set; }
        [Parameter] public StepsStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                _isCustomStatus = true;
            }
        }
        [Parameter] public string Title { get; set; } = string.Empty;
        [Parameter] public string SubTitle { get; set; } = string.Empty;
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }
        [CascadingParameter] public Steps Parent { get; set; }
        private readonly Dictionary<string, object> _containerAttributes = new Dictionary<string, object>();
        internal bool Clickable { get; set; }
        internal bool Last { get; set; }
        internal bool ShowProcessDot { get; set; }
        internal RenderFragment ProgressDot { get; set; }
        internal StepsDirection Direction { get; set; } = StepsDirection.Horizontal;
        internal StepsStatus GroupStatus { get; set; } = null;
        private StepsStatus _status = StepsStatus.Wait;
        private bool _isCustomStatus;
        private int _groupCurrent;
        internal int Index { get; set; }
        internal int GroupCurrentIndex
        {
            get => _groupCurrent;
            set
            {
                _groupCurrent = value;
                if (!_isCustomStatus)
                {
                    this._status = value > this.Index ? StepsStatus.Finish : value == this.Index ? GroupStatus ?? null : StepsStatus.Wait;
                }
            }
        }

        private static readonly string prefix = "ant-steps-item";

        private ClassBuilder classes => ClassBuilder.Create(prefix)
            .AddClass($"{prefix}-{Status}")
            .AddClassWhen($"{prefix}-active", Parent.Current == Index)
            .AddClassWhen($"{prefix}-disabled", Disabled)
            .AddClassWhen($"{prefix}-custom", Icon != null)
            .AddClassWhen("ant-steps-next-error", GroupStatus == StepsStatus.Error && Parent.Current == Index + 1);

        internal int? GetTabIndex()
        {
            if (!Disabled && Clickable) return 0;
            else return null;
        }
        protected override void OnInitialized()
        {
            Parent._children.Add(this);
            this.Index = Parent._children.Count - 1;
            if (Clickable && !Disabled)
            {
                _containerAttributes["role"] = "button";
            }
        }

        public void Dispose()
        {
            Parent._children.Remove(this);
            Parent.AdjustChildrenSteps();
        }
    }
}
