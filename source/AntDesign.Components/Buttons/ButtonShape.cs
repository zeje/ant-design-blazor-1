using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class ButtonShape : SmartEnum<ButtonShape>
    {
        public static readonly ButtonShape Default = new ButtonShape(nameof(Default).ToLower(), 1);
        public static readonly ButtonShape Round = new ButtonShape(nameof(Round).ToLower(), 2);
        public static readonly ButtonShape Circle = new ButtonShape(nameof(Circle).ToLower(), 3);

        private ButtonShape(string name, int value) : base(name, value)
        {
        }
    }
}
