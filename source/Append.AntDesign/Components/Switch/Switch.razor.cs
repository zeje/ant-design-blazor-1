using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Append.AntDesign.Components
{
    public partial class Switch
    {
        private readonly static string prefix = "ant-switch";

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClassWhen($"{prefix}-small", Size == SwitchSize.Small)
                .AddClassWhen($"{prefix}-loading", _loading)
                .AddClassWhen($"{prefix}-checked", _checked)
                .AddClassWhen($"{prefix}-disabled", Disabled);

        private string childText => _checked ? CheckedChildText : UnCheckedChildText;
        private IconType childIconType => _checked ? CheckedChildIconType : UnCheckedChildIconType;

        private void OnChanged(ChangeEventArgs e)
        {
            CheckedChanged.InvokeAsync(_checked);
        }

        private void OnClicked(MouseEventArgs e)
        {
            InverseCheckedField();
            OnClick.InvokeAsync(_checked);
        }

        private void InverseCheckedField()
        {
            _checked = Checked ?? !_checked;
        }

        private void CheckContradictingParameters()
        {
            if (!string.IsNullOrEmpty(UnCheckedChildText) && UnCheckedChildIconType != null)
                throw new ArgumentException($"A {nameof(Switch)} can only define {nameof(UnCheckedChildText)} or {nameof(UnCheckedChildIconType)}, choose one.");

            if (!string.IsNullOrEmpty(CheckedChildText) && CheckedChildIconType != null)
                throw new ArgumentException($"A {nameof(Switch)} can only define {nameof(CheckedChildText)} or {nameof(CheckedChildIconType)}, choose one.");
        }

        private bool _checked;
        private bool _loading;

        [Parameter]
        public bool Loading
        {
            get { return _loading; }
            set
            {
                _loading = value;
                Disabled = value;
            }
        }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public bool? Checked { get; set; }
        [Parameter] public bool DefaultChecked { get; set; }
        [Parameter] public SwitchSize Size { get; set; } = SwitchSize.Default;
        [Parameter] public string CheckedChildText { get; set; }
        [Parameter] public IconType CheckedChildIconType { get; set; }
        [Parameter] public string UnCheckedChildText { get; set; }
        [Parameter] public IconType UnCheckedChildIconType { get; set; }
        [Parameter] public EventCallback<bool> OnClick { get; set; }
        [Parameter] public EventCallback<bool> CheckedChanged { get; set; }

        //[Parameter] public bool Onblur { get; set; }
        //[Parameter] public bool OnFocus { get; set; }

        protected override void OnInitialized()
        {
            CheckContradictingParameters();
            _checked = Checked ?? DefaultChecked;
        }
    }

}