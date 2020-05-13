using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Append.AntDesign.Components
{
    public partial class RadioGroup
    {

        protected readonly static string baseClass = "ant-radio";

        private ClassBuilder classes => ClassBuilder.Create(Class)
          .AddClass($"{baseClass}-group")
          .AddClassWhen($"{baseClass}-group-large", Size == RadioButtonSize.Large)
          .AddClassWhen($"{baseClass}-group-small", Size == RadioButtonSize.Small)
          .AddClassWhen($"{baseClass}-group-outline", ButtonStyle == RadioButtonStyle.Outline)
          .AddClassWhen($"{baseClass}-group-solid", ButtonStyle == RadioButtonStyle.Solid);

        internal string _currentValue;

        [Parameter] public string Name { get; set; }
        [Parameter] public RadioButtonSize Size { get; set; } = RadioButtonSize.Middle;
        [Parameter] public RadioButtonStyle ButtonStyle { get; set; } = RadioButtonStyle.Outline;

        [Parameter] public string DefaultValue { get; set; }
        [Parameter] public string Value { get; set; }
        [Parameter] public bool Disabled { get; set; } //List<ValueTuple<string, string, bool>>

        [Parameter] public List<RadioGroupOption> Options { get; set; } = new List<RadioGroupOption>();

        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public EventCallback<string> OnChange { get; set; }

        protected override void OnInitialized() => _currentValue = Value ?? DefaultValue;

        internal void OnRadioChanged(string value)
        {
            _currentValue = value;
            OnChange.InvokeAsync(value);
            StateHasChanged();
        }

        private RenderFragment BuildRadio(RadioGroupOption option)
        {
            RenderFragment radio = builder =>
            {
                builder.OpenComponent<Radio>(0);
                builder.AddAttribute(1, "Value", option.Value ?? option.Label);
                builder.AddAttribute(2, "Disabled", option.Disabled);
                builder.AddAttribute(3, "ChildContent", (RenderFragment)((builder2) =>
                {
                    builder2.AddContent(4, option.Label);
                }));
                builder.CloseComponent();
            };
            return radio;
        }
    }
}
