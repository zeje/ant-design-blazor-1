using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class Justification : SmartEnum<Justification>
    {
        public static readonly Justification Start = new Justification(nameof(Start).ToLower(), 1);
        public static readonly Justification Center = new Justification(nameof(Center).ToLower(), 2);
        public static readonly Justification End = new Justification(nameof(End).ToLower(), 3);
        public static readonly Justification Space_Between = new Justification("space-between", 4);
        public static readonly Justification Space_Around = new Justification("space-around", 5);

        private Justification(string name, int value) : base(name, value)
        {
        }
    }
}
