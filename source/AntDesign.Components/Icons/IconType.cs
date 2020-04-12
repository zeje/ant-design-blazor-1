using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public class IconType : SmartEnum<IconType>
    {
        public IconType(string name, int value) : base(name, value)
        {
        }

        public class Filled : IconType
        {
            public Filled(string name, int value) : base(name, value)
            {
            }
        }
        public class Outlined : IconType
        {
            public static Outlined Home = new Outlined(nameof(Home).ToLower(), 1);
            public static Outlined Download = new Outlined(nameof(Download).ToLower(), 2);
            public static Outlined Poweroff = new Outlined(nameof(Poweroff).ToLower(), 3);
            public static Outlined Search = new Outlined(nameof(Search).ToLower(), 4);
            public static Outlined Plus = new Outlined(nameof(Plus).ToLower(), 5);
            public static Outlined Minus = new Outlined(nameof(Minus).ToLower(), 6);
            public static Outlined Loading = new Outlined(nameof(Loading).ToLower(), 7);
            public static Outlined Edit = new Outlined(nameof(Edit).ToLower(), 8);
            public Outlined(string name, int value) : base(name, value)
            {
            }
        }
        public class TwoTone : IconType
        {
            public TwoTone(string name, int value) : base(name, value)
            {
            }
        }
    }
}
