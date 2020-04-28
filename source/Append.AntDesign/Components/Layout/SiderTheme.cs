using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class SiderTheme : SmartEnum<SiderTheme>
    {
        public static readonly SiderTheme Light = new SiderTheme(nameof(Light).ToLower(), 1);
        public static readonly SiderTheme Dark = new SiderTheme(nameof(Dark).ToLower(), 2);

        private SiderTheme(string name, int value) : base(name, value)
        {
        }
    }
}
