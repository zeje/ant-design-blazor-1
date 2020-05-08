using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class InputType : SmartEnum<InputType>
    {
        public static readonly InputType Text = new InputType(nameof(Text).ToLower(), 1);
        public static readonly InputType TextArea = new InputType(nameof(TextArea).ToLower(), 2);
        public static readonly InputType Search = new InputType(nameof(Search).ToLower(), 3);
        public static readonly InputType Password = new InputType(nameof(Password).ToLower(), 4);

        private InputType(string name, int value) : base(name, value)
        {
        }
    }
}
