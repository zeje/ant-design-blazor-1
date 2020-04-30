using Ardalis.SmartEnum;

namespace Append.AntDesign.Components
{
    public class AvatarShape : SmartEnum<AvatarShape>
    {
        public static AvatarShape Circle = new AvatarShape(nameof(Circle).ToLower(), 1);
        public static AvatarShape Square = new AvatarShape(nameof(Square).ToLower(), 2);

        private AvatarShape(string name, int value) : base(name, value)
        {
        }
    }
}
