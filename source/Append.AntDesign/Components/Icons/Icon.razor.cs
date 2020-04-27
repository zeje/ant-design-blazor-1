using Append.AntDesign.Components.Services;
using Append.AntDesign.Core;
using Append.AntDesign.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Append.AntDesign.Components
{
    public partial class Icon
    {
        private static string prefix = "anticon";
        private ClassBuilder classes => ClassBuilder.Create(Class)
                .AddClass(prefix)
                .AddClass($"{prefix}-{Type.IconNameWithoutPrefix}");

        [Inject] public IIconService IconService { get; set; }
        [Parameter] public string Width { get; set; } = "1em";
        [Parameter] public string Height { get; set; } = "1em";
        [Parameter] public string Fill { get; set; } = "currentColor";
        [Parameter] public string PrimaryColor { get; set; }
        [Parameter] public string SecondaryColor { get; set; }
        [Parameter] public bool Spin { get; set; }
        [Parameter] public int Rotate { get; set; }
        [Parameter] public IconType Type { get; set; }

        private MarkupString svg;


        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Type == null)
                throw new ArgumentException($"Parameter {nameof(Type)} was not provided, you should provide which icon you'd like to see.");
        }

        protected override async Task OnParametersSetAsync()
        {
            var xdoc = await IconService.GetVectorGraphicTemplateAsync(Type);

            // Create a copy else we'll be altering the template
            XDocument newIcon = new XDocument(xdoc);
            VectorGraphicBuilder.Create(newIcon, Type)
                                .SetHeight(Height)
                                .SetWidth(Width)
                                .SetFill(Fill)
                                .SetSpinning(Spin)
                                .SetRotation(Rotate)
                                .SetTwoToneColors(PrimaryColor, SecondaryColor)
                                .SetStyle(Style)
                                .BuildIcon();

            svg = (MarkupString)newIcon.ToString();
        }
    }
}
