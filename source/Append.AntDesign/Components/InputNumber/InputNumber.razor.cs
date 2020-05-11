using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Append.AntDesign.Components
{
    public partial class InputNumber
    {
        private string _format;
        private static readonly string prefix = "ant-input-number";

        [Parameter] public double? DefaultValue { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public Func<double, string> Formatter { get; set; }
        [Parameter] public double Max { get; set; } = double.PositiveInfinity;
        [Parameter] public double Min { get; set; } = double.NegativeInfinity;
        [Parameter] public Func<string, double> Parser { get; set; }

        [Parameter] public InputSize Size { get; set; } = InputSize.Middle;
        private double _step = 1;
        [Parameter]
        public double Step
        {
            get
            {
                return _step;
            }
            set
            {
                _step = value;
                if (string.IsNullOrEmpty(_format))
                {
                    _format = string.Join('.', _step.ToString().Split('.').Select(n => new string('0', n.Length)));
                }
            }
        }
        [Parameter] public double Value { get; set; }

        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClassWhen($"{prefix}-disabled", Disabled)
                .AddClassWhen($"{prefix}-lg", Size == InputSize.Large)
                .AddClassWhen($"{prefix}-sm", Size == InputSize.Small);

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

            if (DefaultValue.HasValue)
            {
                Value = DefaultValue.Value;
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
            } else if(num < Min)
            {
                Value = Min;
            } else if(num > Max)
            {
                Value = Max;
            }
        }

        private string DisplayValue()
        {
            if (Formatter != null)
            {
                return Formatter(Value);
            }

            return Value.ToString(_format);
        }
    }
}
