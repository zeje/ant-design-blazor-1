using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Append.AntDesign.Components
{
    public abstract class AntComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
        protected string Style => Attributes.GetStyle();
        protected string Class => Attributes.GetClass();

    }
}
