using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class SiderBreakpoint : SmartEnum<SiderBreakpoint>
    {
        public static readonly SiderBreakpoint Xs = new SiderBreakpoint(nameof(Xs).ToLower(), 1, 480);
        public static readonly SiderBreakpoint Sm = new SiderBreakpoint(nameof(Sm).ToLower(), 2, 576);
        public static readonly SiderBreakpoint Md = new SiderBreakpoint(nameof(Md).ToLower(), 3, 768);
        public static readonly SiderBreakpoint Lg = new SiderBreakpoint(nameof(Lg).ToLower(), 4, 992);
        public static readonly SiderBreakpoint Xl = new SiderBreakpoint(nameof(Xl).ToLower(), 5, 1200);
        public static readonly SiderBreakpoint Xxl = new SiderBreakpoint(nameof(Xxl).ToLower(), 6,1600);

        public int Width { get; private set; }
        private SiderBreakpoint(string name, int value, int width) : base(name, value)
        {
            Width = width;
        }
    }
}
