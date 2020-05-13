using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;

namespace Append.AntDesign.Components
{
    public partial class Radio
    {
        private string baseClass => isRadioButton ? "ant-radio-button" : "ant-radio";
        private bool radioGroupNameDefined => RadioGroup != null && !string.IsNullOrEmpty(RadioGroup.Name);

        private ClassBuilder wrapperClasses => ClassBuilder.Create(Class)
         .AddClass($"{baseClass}-wrapper")
         .AddClassWhen($"{baseClass}-wrapper-checked", _checkedState && RadioGroup != null)
         .AddClassWhen($"{baseClass}-wrapper-disabled", Disabled);

        private ClassBuilder classes => ClassBuilder.Create()
           .AddClass(baseClass)
           .AddClassWhen($"{baseClass}-checked", _checkedState)
           .AddClassWhen($"{baseClass}-disabled", Disabled);

        private void OnRadioClicked()
        {
            if (Disabled)
                return;
            _checkedState = true;
            if (RadioGroup != null)
                RadioGroup.OnRadioChanged(Value);
        }

        protected bool isRadioButton = false;

        private bool _checkedState;

        //[Parameter] public bool AutoFocus { get; set; } // not implemented yet
        [Parameter] public bool? Checked { get; set; }
        [Parameter] public bool DefaultChecked { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [CascadingParameter] public RadioGroup RadioGroup { get; set; }

        protected override void OnInitialized() => _checkedState = Checked ?? DefaultChecked;
        protected override void OnParametersSet()
        {
            if (RadioGroup != null)
            {
                _checkedState = RadioGroup._currentValue == Value;
                Disabled = Disabled ? Disabled : RadioGroup.Disabled;
            }
        }
    }
}