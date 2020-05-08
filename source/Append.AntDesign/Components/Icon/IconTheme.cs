using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public class IconTheme : SmartEnum<IconTheme>
    {
        public static IconTheme Outlined = new IconTheme(nameof(Outlined).ToLower(), 1);
        public static IconTheme Filled = new IconTheme(nameof(Filled).ToLower(), 2);
        public static IconTheme TwoTone = new IconTheme(nameof(TwoTone).ToLower(), 3);
        public static IconTheme Internal = new IconTheme(nameof(Internal).ToLower(), 4);

        private IconTheme(string name, int value) : base(name, value)
        {
        }
    }
}
