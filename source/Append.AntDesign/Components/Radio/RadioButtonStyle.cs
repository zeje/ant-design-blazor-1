using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public class RadioButtonStyle : SmartEnum<RadioButtonStyle>
    {
        public static readonly RadioButtonStyle Outline = new RadioButtonStyle(nameof(Outline).ToLower(), 1);
        public static readonly RadioButtonStyle Solid = new RadioButtonStyle(nameof(Solid).ToLower(), 2);

        private RadioButtonStyle(string name, int value) : base(name, value)
        {
        }
    }
}
