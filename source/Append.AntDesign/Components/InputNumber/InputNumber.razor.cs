using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Append.AntDesign.Components
{
    public partial class InputNumber
    {
        private string _format;
        private static readonly string prefix = "ant-input-number";

        [Parameter] public string DecimalSeparator { get; set; } = ".";
        [Parameter] public double DefaultValue { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public Func<double, string> Formatter { get; set; }
        [Parameter] public double Max { get; set; } = double.PositiveInfinity;
        [Parameter] public double Min { get; set; } = double.NegativeInfinity;
        [Parameter] public Func<string, double> Parser { get; set; }
        [Parameter] public InputSize Size { get; set; } = InputSize.Middle;
        private double _step = 1;
        private string _currentSeperator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        private string _invariantSeperator = CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator;
        protected string StepString = "1";
        [Parameter]
        public double Step
        {
            get
            {
                return _step;
            }
            set
            {
                StepString = value.ToString().Replace(_currentSeperator, _invariantSeperator);
                _step = value;
                if (string.IsNullOrEmpty(_format))
                {
                    _format = string.Join(_invariantSeperator, StepString.Split(_invariantSeperator).Select(n => new string('0', n.Length)));
                }
            }
        }
        public double _value;
        [Parameter]
        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                DisplayString = DisplayValue();
            }
        }

        private ClassBuilder classes => ClassBuilder.Create(prefix)
                .AddClassWhen($"{prefix}-disabled", Disabled)
                .AddClassWhen($"{prefix}-lg", Size == InputSize.Large)
                .AddClassWhen($"{prefix}-sm", Size == InputSize.Small);

        private ClassBuilder inputClasses => ClassBuilder.Create(Class)
                .AddClass($"{prefix}-input");

        protected string inputHandlerPrefix = $"{prefix}-handler";

        private ClassBuilder iconClassesUp => ClassBuilder.Create(Class)
                .AddClass(inputHandlerPrefix)
                .AddClass($"{inputHandlerPrefix}-up")
                .AddClassWhen($"{inputHandlerPrefix}-up-disabled", Value >= Max)
                .AddClassWhen($"{inputHandlerPrefix}-up-disabled", Disabled);

        private ClassBuilder iconClassesDown => ClassBuilder.Create(Class)
                .AddClass(inputHandlerPrefix)
                .AddClass($"{inputHandlerPrefix}-down")
                .AddClassWhen($"{inputHandlerPrefix}-down-disabled", Value <= Min)
                .AddClassWhen($"{inputHandlerPrefix}-down-disabled", Disabled);


        protected override void OnInitialized()
        {
            base.OnInitialized();

            Value = DefaultValue;
            DisplayString = DefaultValue.ToString(_format, CultureInfo.InvariantCulture);

        }
        private void HandleKeyDown(KeyboardEventArgs args)
        {
            if (args.Key == "ArrowDown")
            {
                Decrease();
            }
            else if (args.Key == "ArrowUp")
            {
                Increase();
            }
        }
        private void Decrease()
        {
            OnInput(new ChangeEventArgs() { Value = Value - Step });
        }
        private void Increase()
        {
            OnInput(new ChangeEventArgs() { Value = Value + Step });
        }

        private void OnInput(ChangeEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(args.Value.ToString()))
            {
                Value = 0;
                return;
            }

            var regex = new Regex($"[0-9]|[{DecimalSeparator}]|[-]");

            if (!regex.Match(args.Value.ToString().Substring(args.Value.ToString().Length - 1)).Success)
            {
                return;
            }
            double num;
            if (Parser != null)
            {
                num = Parser(args.Value.ToString());
            }
            else
            {
                _ = double.TryParse(args.Value.ToString(), out num);
            }

            if (num >= Min && num <= Max)
            {
                Value = num;
            }
            else if (num < Min)
            {
                Value = Min;
            }
            else if (num > Max)
            {
                Value = Max;
            }
        }
        private string _displayString;

        public string DisplayString
        {
            get 
            {
                if (Formatter != null)
                {
                    return DisplayValue();
                }
                return DisplayValue().Replace(_invariantSeperator, DecimalSeparator); 
            }
            set
            {
                _displayString = DisplayValue();
            }
        }

        private string DisplayValue()
        {
            if (Formatter != null)
            {
                return Formatter(Value);
            }

            return Value.ToString(_format, CultureInfo.InvariantCulture);
        }
    }
}
