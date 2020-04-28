using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class AlertType : SmartEnum<AlertType>
    {
        public static readonly AlertType Success = new AlertType(nameof(Success).ToLower(), 1);
        public static readonly AlertType Info = new AlertType(nameof(Info).ToLower(), 2);
        public static readonly AlertType Warning = new AlertType(nameof(Warning).ToLower(), 3);
        public static readonly AlertType Error = new AlertType(nameof(Error).ToLower(), 4);

        private AlertType(string name, int value) : base(name, value)
        {
        }
    }
}
