using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Concurrent;
using System.Xml.Linq;

namespace Append.AntDesign.Components
{
    public partial class Icon
    {
        [Parameter] public string Width { get; set; } = "1em";
        [Parameter] public string Height { get; set; } = "1em";
        [Parameter] public string Fill { get; set; } = "currentColor";
        [Parameter] public string PrimaryColor { get; set; }
        [Parameter] public string SecondaryColor { get; set; }
        [Parameter] public bool Spin { get; set; }
        [Parameter] public int Rotate { get; set; }
        [Parameter] public IconType Type { get; set; }
        [Parameter] public IconTheme Theme { get; set; }

        private MarkupString svg;
        [Inject] private NavigationManager NavigationManager { get; set; }
        private static readonly ConcurrentDictionary<IconType, XDocument> SvgCache = new ConcurrentDictionary<IconType, XDocument>();


        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Type == null)
                throw new ArgumentException($"Parameter {nameof(Type)} was not provided, you should provide which icon you'd like to see.");
            DetermineTheme();

            var xdoc = LoadSvg();
            XDocument currentIcon = new XDocument(xdoc);
            AddSvgStyles(currentIcon);
            SetTwoToneColors(currentIcon);
            svg = (MarkupString)currentIcon.ToString();
        }

        private XDocument LoadSvg()
        {
            XDocument xdoc = null;
            if (SvgCache.TryGetValue(Type, out xdoc))
                return xdoc;

            xdoc = ReadSvgFile();
            SvgCache.TryAdd(Type, xdoc);
            return xdoc;
        }


        private XDocument ReadSvgFile()
        {
            var baseUrl = NavigationManager.BaseUri;
            return XDocument.Load($"{baseUrl}_content/Append.AntDesign.Components/icons/{Theme}/{NormalizedFilename()}.svg");
        }
        private void DetermineTheme()
        {
            if (Theme != null)
                return;
            var themeType = Type.GetType().FullName.Split('+')[1];
            Theme = IconTheme.FromName(themeType.ToLower());
        }
        private string NormalizedFilename()
        {
            return Type.Name.Replace('_', '-');
        }
        private void AddSvgStyles(XDocument xdoc)
        {
            xdoc.Root.SetAttributeValue("focusable", false);
            xdoc.Root.SetAttributeValue("width", Width);
            xdoc.Root.SetAttributeValue("height", Height);
            xdoc.Root.SetAttributeValue("fill", Fill);
            xdoc.Root.SetAttributeValue("aria-hidden", true);
            if(Type == IconType.Outlined.Loading)
            {
                xdoc.Root.SetAttributeValue("viewBox", "0 0 1024 1024");
            }
            else
            {
                xdoc.Root.SetAttributeValue("viewBox", "64 64 896 896");
            }
            xdoc.Root.SetAttributeValue("class", Class);
            if (Spin || Type == IconType.Outlined.Loading)
                xdoc.Root.SetAttributeValue("class", "anticon-spin");

            if (Rotate != 0)
                xdoc.Root.SetAttributeValue("style", $"transform: rotate({Rotate}deg);");
        }
        private void SetTwoToneColors(XDocument xdoc)
        {
            if (Theme != IconTheme.TwoTone)
                return;

            var primaryColor = string.IsNullOrWhiteSpace(PrimaryColor) ? IconType.TwoTone.DefaultPrimaryColor : PrimaryColor;
            var secondaryColor = string.IsNullOrWhiteSpace(SecondaryColor) ? IconType.TwoTone.DefaultSecondaryColor : SecondaryColor;

            foreach (XElement element in xdoc.Root.Elements())
            {
                var color = element.Attribute("fill");
                if (color is null || color?.Value == "#333")
                {
                    element.SetAttributeValue("fill", primaryColor);
                }
                else
                {
                    if (color.Value == "#E6E6E6" || color.Value == "#D9D9D9" || color.Value == "#D8D8D8")
                    {
                        element.SetAttributeValue("fill", secondaryColor);
                    }
                }
            }
        }
    }
}
