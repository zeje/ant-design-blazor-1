using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class TimelinePosition : SmartEnum<TimelinePosition>
    {
        public static TimelinePosition Left = new TimelinePosition(nameof(Left).ToLower(), 1);
        public static TimelinePosition Right = new TimelinePosition(nameof(Right).ToLower(), 2);
        private TimelinePosition(string name, int value) : base(name, value)
        {
        }
    }
}