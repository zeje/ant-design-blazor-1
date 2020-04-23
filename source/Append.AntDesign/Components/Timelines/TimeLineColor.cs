using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class TimelineColor : SmartEnum<TimelineColor>
    {
        public static TimelineColor Blue = new TimelineColor(nameof(Blue).ToLower(), 1);
        public static TimelineColor Red = new TimelineColor(nameof(Red).ToLower(), 2);
        public static TimelineColor Green = new TimelineColor(nameof(Green).ToLower(), 3);
        public static TimelineColor Gray = new TimelineColor(nameof(Gray).ToLower(), 4);
        private TimelineColor(string name, int value) : base(name, value)
        {
        }
    }
}