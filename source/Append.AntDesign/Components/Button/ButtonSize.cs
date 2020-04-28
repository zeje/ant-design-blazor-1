using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class ButtonSize : SmartEnum<ButtonSize>
    {
        public static readonly ButtonSize Default = new ButtonSize("default", 1);
        public static readonly ButtonSize Small = new ButtonSize("sm",2);
        public static readonly ButtonSize Middle = new ButtonSize("md",3);
        public static readonly ButtonSize Large = new ButtonSize("lg",4);

        private ButtonSize(string name, int value) : base(name, value)
        {
        }
    }
}
