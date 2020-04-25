using Append.AntDesign.Core;
using Append.AntDesign.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Append.AntDesign.Documentation.Shared
{
    public partial class BrowserMockup
    {
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass("browser-mockup")
                .AddClassWhen($"with-url", WithUrl);

        [Parameter] public string Height { get; set; }
        [Parameter] public bool WithUrl { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
