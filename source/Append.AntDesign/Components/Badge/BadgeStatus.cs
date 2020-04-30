using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class BadgeStatus : SmartEnum<BadgeStatus>
    {
        public static readonly BadgeStatus Success = new BadgeStatus(nameof(Success).ToLower(), 1);
        public static readonly BadgeStatus Processing = new BadgeStatus(nameof(Processing).ToLower(), 2);
        public static readonly BadgeStatus Default = new BadgeStatus(nameof(Default).ToLower(), 3);
        public static readonly BadgeStatus Error = new BadgeStatus(nameof(Error).ToLower(), 4);
        public static readonly BadgeStatus Warning = new BadgeStatus(nameof(Warning).ToLower(), 5);

        private BadgeStatus(string name, int value) : base(name, value)
        {
        }
    }
}
