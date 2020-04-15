using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class ButtonType : SmartEnum<ButtonType>
    {
        public static readonly ButtonType Default = new ButtonType(nameof(Default).ToLower(), 1);
        public static readonly ButtonType Primary = new ButtonType(nameof(Primary).ToLower(), 2);
        public static readonly ButtonType Dashed = new ButtonType(nameof(Dashed).ToLower(), 3);
        public static readonly ButtonType Link = new ButtonType(nameof(Link).ToLower(), 4);

        private ButtonType(string name, int value) : base(name, value)
        {
        }
    }
}
