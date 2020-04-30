using Ardalis.SmartEnum;

namespace Append.AntDesign.Core
{
    public sealed class Size : SmartEnum<Size>
    {
        public static readonly Size Default = new Size("default", 1);
        public static readonly Size Small = new Size("sm",2);
        public static readonly Size Middle = new Size("md",3);
        public static readonly Size Large = new Size("lg",4);

        private Size(string name, int value) : base(name, value)
        {
        }
    }
}
