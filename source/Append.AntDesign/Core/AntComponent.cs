using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public abstract class AntComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
        [Parameter] public string Class { get; set; }
        public string Styles => Attributes.GetStyles();
        //public string Classes => Attributes.getcl();
    }
}
