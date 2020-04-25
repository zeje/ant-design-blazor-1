using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public sealed class Alignment : SmartEnum<Alignment>
    {
        public static readonly Alignment Top = new Alignment(nameof(Top).ToLower(), 1);
        public static readonly Alignment Middle = new Alignment(nameof(Middle).ToLower(), 2);
        public static readonly Alignment Bottom = new Alignment(nameof(Bottom).ToLower(), 3);

        private Alignment(string name, int value) : base(name, value)
        {
        }
    }
}
