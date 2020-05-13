using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public class RadioButtonSize : SmartEnum<RadioButtonSize>
    {
        public static readonly RadioButtonSize Small = new RadioButtonSize(nameof(Small).ToLower(), 1);
        public static readonly RadioButtonSize Middle = new RadioButtonSize(nameof(Middle).ToLower(), 2);
        public static readonly RadioButtonSize Large = new RadioButtonSize(nameof(Large).ToLower(), 3);

        private RadioButtonSize(string name, int value) : base(name, value)
        {
        }
    }
}
