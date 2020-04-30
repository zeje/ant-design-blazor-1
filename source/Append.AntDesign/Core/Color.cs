using Ardalis.SmartEnum;

namespace Append.AntDesign.Core
{
    public class Color : SmartEnum<Color>
    {
        public static readonly Color Pink = new Color(nameof(Pink).ToLower(), 1);
        public static readonly Color Magenta = new Color(nameof(Magenta).ToLower(), 2);
        public static readonly Color Red = new Color(nameof(Red).ToLower(), 3);
        public static readonly Color Volcano = new Color(nameof(Volcano).ToLower(), 4);
        public static readonly Color Orange = new Color(nameof(Orange).ToLower(), 5);
        public static readonly Color Yellow = new Color(nameof(Yellow).ToLower(), 6);
        public static readonly Color Gold = new Color(nameof(Gold).ToLower(), 7);
        public static readonly Color Cyan = new Color(nameof(Cyan).ToLower(), 8);
        public static readonly Color Lime = new Color(nameof(Lime).ToLower(), 9);
        public static readonly Color Green = new Color(nameof(Green).ToLower(), 10);
        public static readonly Color Blue = new Color(nameof(Blue).ToLower(), 11);
        public static readonly Color Geekblue = new Color(nameof(Geekblue).ToLower(), 12);
        public static readonly Color Purple = new Color(nameof(Purple).ToLower(), 13);

        private Color(string name, int value) : base(name, value)
        {
        }
    }
}
