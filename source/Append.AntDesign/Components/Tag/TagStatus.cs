using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public sealed class TagStatus : SmartEnum<TagStatus>
    {
        public static readonly TagStatus Success = new TagStatus(nameof(Success).ToLower(), 1);
        public static readonly TagStatus Processing = new TagStatus(nameof(Processing).ToLower(), 2);
        public static readonly TagStatus Default = new TagStatus(nameof(Default).ToLower(), 3);
        public static readonly TagStatus Error = new TagStatus(nameof(Error).ToLower(), 4);
        public static readonly TagStatus Warning = new TagStatus(nameof(Warning).ToLower(), 5);

        private TagStatus(string name, int value) : base(name, value)
        {
        }
    }
}
