using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class TypographyType : SmartEnum<AlertType>
    {
        public static readonly TypographyType Default = new TypographyType(nameof(Default).ToLower(), 1);
        public static readonly TypographyType Secondary = new TypographyType(nameof(Secondary).ToLower(), 2);
        public static readonly TypographyType Danger = new TypographyType(nameof(Danger).ToLower(), 3);
        public static readonly TypographyType Warning = new TypographyType(nameof(Warning).ToLower(), 4);

        private TypographyType(string name, int value) : base(name, value)
        {
        }
    }
}
