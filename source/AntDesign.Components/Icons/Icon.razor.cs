using Microsoft.AspNetCore.Components;
using System;
using System.Xml.Linq;

namespace Append.AntDesign.Components
{
    public partial class Icon
    {
        [Parameter] public string Width { get; set; } = "1em";
        [Parameter] public string Height { get; set; } = "1em";
        [Parameter] public string Fill { get; set; } = "currentColor";
        [Parameter] public bool Spin { get; set; }
        [Parameter] public int Rotate { get; set; }
        [Parameter] public IconType Type { get; set; }
        [Parameter] public IconTheme Theme { get; set; }

        private MarkupString svg;
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Type == null)
                throw new ArgumentException($"Parameter {nameof(Type)} was not provided, you should provide which icon you'd like to see.");

            var xdoc = ReadSvgFile();
            AddSvgStyles(xdoc);
            svg = (MarkupString)xdoc.ToString();
        }
        private XDocument ReadSvgFile()
        {
            var baseUrl = NavigationManager.BaseUri;
            return XDocument.Load($"{baseUrl}_content/Append.AntDesign.Components/icons/{NormalizedTheme()}/{Type}.svg");
        }
        private IconTheme NormalizedTheme()
        {
            if (Theme != null)
                return Theme;
            var themeType = Type.GetType().FullName.Split('+')[1];
            return IconTheme.FromName(themeType.ToLower());
        }
        private void AddSvgStyles(XDocument xdoc)
        {
            xdoc.Root.SetAttributeValue("focusable", false);
            xdoc.Root.SetAttributeValue("width", Width);
            xdoc.Root.SetAttributeValue("height", Height);
            xdoc.Root.SetAttributeValue("fill", Fill);
            xdoc.Root.SetAttributeValue("aria-hidden", true);
            xdoc.Root.SetAttributeValue("viewBox", "64 64 896 896");
            if (Spin)
                xdoc.Root.SetAttributeValue("class", "anticon-spin");

            if (Rotate != 0)
                xdoc.Root.SetAttributeValue("style", $"transform: rotate({Rotate}deg);");
        }
    }
}
