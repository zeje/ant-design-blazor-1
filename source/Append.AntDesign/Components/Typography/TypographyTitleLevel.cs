using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class TypographyTitleLevel : SmartEnum<AlertType>
    {
        public static readonly TypographyTitleLevel H1 = new TypographyTitleLevel(nameof(H1).ToLower(), 1);
        public static readonly TypographyTitleLevel H2 = new TypographyTitleLevel(nameof(H2).ToLower(), 2);
        public static readonly TypographyTitleLevel H3 = new TypographyTitleLevel(nameof(H3).ToLower(), 3);
        public static readonly TypographyTitleLevel H4 = new TypographyTitleLevel(nameof(H4).ToLower(), 4);

        private TypographyTitleLevel(string name, int value) : base(name, value)
        {
        }
    }
}
