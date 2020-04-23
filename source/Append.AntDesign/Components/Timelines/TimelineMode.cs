using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class TimelineMode : SmartEnum<TimelineMode>
    {
        public static TimelineMode Left = new TimelineMode(nameof(Left).ToLower(), 1);
        public static TimelineMode Alternate = new TimelineMode(nameof(Alternate).ToLower(), 2);
        public static TimelineMode Right = new TimelineMode(nameof(Right).ToLower(), 3);
        private TimelineMode(string name, int value) : base(name, value)
        {
        }
    }
}