using Append.AntDesign.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Components
{
    public class TagBase : AntComponent
    {
        protected readonly static string baseClass = "ant-tag";

        protected ClassBuilder classesBase => ClassBuilder.Create(Class)
          .AddClass(baseClass)
          .AddClassWhen($"{baseClass}-{Color}", isColorCustom == false)
          .AddClassWhen($"{baseClass}-has-color", isColorCustom == true);

        protected StyleBuilder stylesBase => StyleBuilder.Create(Style)
            .AddStyleWhen($"background-color: {Color}", isColorCustom == true);


        private bool? isColorCustom => string.IsNullOrEmpty(Color) ? (bool?)null : (!Core.Color.TryFromName(Color, ignoreCase: true, out _) && !TagStatus.TryFromName(Color, ignoreCase: true, out _));

        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Color { get; set; }

    }
}
