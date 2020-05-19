using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Append.AntDesign.Components
{
    public partial class Steps
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string ClassName { get; set; }
        [Parameter] public int Current { get; set; }
        [Parameter] public StepsDirection Direction { get; set; } = StepsDirection.Horizontal;
        [Parameter] public StepsDirection LabelPlacement { get; set; } = StepsDirection.Horizontal;
        [Parameter] public StepsSize Size { get; set; } = StepsSize.Default;
        [Parameter] public int Initial { get; set; } = 0;
        [Parameter] public StepsStatus Status { get; set; } = StepsStatus.Process;
        [Parameter] public StepsType Type { get; set; } = StepsType.Default;
        [Parameter] public Action<int> OnChange { get; set; }
        private bool _showProgressDot;
        private RenderFragment _progressDot;
        internal List<Step> _children = new List<Step>();
        [Parameter]
        public RenderFragment ProgressDot
        {
            get => _progressDot;
            set
            {
                _progressDot = value;
                _showProgressDot = value != null;
                AdjustChildrenSteps();
            }
        }
        [Parameter]
        public bool ShowProgressDot
        {
            get => _showProgressDot;
            set => _showProgressDot = value;
        }
        private static readonly string prefix = "ant-steps";
        private ClassBuilder classes => ClassBuilder.Create(prefix)
            .AddClass(ClassName)
            .AddClass($"{prefix}-{Direction}")
            .AddClassWhen($"{prefix}-label-horizontal", Direction == StepsDirection.Horizontal)
            .AddClassWhen($"{prefix}-label-vertical", Direction == StepsDirection.Horizontal && (_showProgressDot || LabelPlacement == StepsDirection.Vertical))
            .AddClassWhen($"{prefix}-dot", _showProgressDot)
            .AddClassWhen($"{prefix}-small", () => Size == StepsSize.Small)
            .AddClassWhen($"{prefix}-navigation", () => Type == StepsType.Navigation);

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            AdjustChildrenSteps();
        }
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            await Task.Run(() =>
            {
                AdjustChildrenSteps();
            });
        }

        internal void AdjustChildrenSteps()
        {
            for (int i = 0; i < _children.Count; i++)
            {
                _children[i].GroupStatus = Status;
                _children[i].ShowProcessDot = this._showProgressDot;
                if (this.ProgressDot !=null )
                {
                    _children[i].ProgressDot = this.ProgressDot;
                }
                _children[i].Clickable = OnChange != null;
                _children[i].Direction = this.Direction;
                _children[i].Index = i + this.Initial;
                _children[i].GroupCurrentIndex = this.Current;
                _children[i].Last = _children.Count == i + 1;
            }
        }

        internal void onStepClick(int index)
        {
            if(OnChange != null && Current != index)
            {
                Current = index;
                AdjustChildrenSteps();
            }
        }
    }
}