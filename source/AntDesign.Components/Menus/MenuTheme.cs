using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class MenuTheme : SmartEnum<MenuTheme>
    {
        public static readonly MenuTheme Light = new MenuTheme(nameof(Light).ToLower(), 1);
        public static readonly MenuTheme Dark = new MenuTheme(nameof(Dark).ToLower(), 2);

        private MenuTheme(string name, int value) : base(name, value)
        {
        }
    }
}
