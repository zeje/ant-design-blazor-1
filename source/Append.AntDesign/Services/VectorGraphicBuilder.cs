using System;
using System.Xml.Linq;

namespace Append.AntDesign.Components.Services
{
    public class VectorGraphicBuilder
    {
        private readonly XDocument xdoc;
        private readonly IconType iconType;

        private VectorGraphicBuilder(XDocument xdoc, IconType iconType)
        {
            this.xdoc = xdoc ?? throw new ArgumentNullException(nameof(xdoc));
            this.iconType = iconType ?? throw new ArgumentNullException(nameof(iconType));
        }

        public static VectorGraphicBuilder Create(XDocument iconTemplate, IconType iconType)
        {
            return new VectorGraphicBuilder(iconTemplate, iconType);
        }

        public VectorGraphicBuilder SetWidth(string width)
        {
            xdoc.Root.SetAttributeValue("width", width);
            return this;
        }
        public VectorGraphicBuilder SetHeight(string height)
        {
            xdoc.Root.SetAttributeValue("height", height);
            return this;
        }
        public VectorGraphicBuilder SetFill(string fill)
        {
            xdoc.Root.SetAttributeValue("fill", fill);
            return this;
        }
        public VectorGraphicBuilder SetSpinning(bool spin)
        {
            if (spin || iconType == IconType.Outlined.Loading)
                xdoc.Root.SetAttributeValue("class", $"{GetRootClassAttributeValue()} anticon-spin");
            return this;
        }
        public VectorGraphicBuilder SetRotation(int rotation)
        {
            if (rotation != 0)
                xdoc.Root.SetAttributeValue("style", $"{GetRootStyleAttributeValue()} transform: rotate({rotation}deg);");

            return this;
        }

        public VectorGraphicBuilder SetStyle(string styles)
        {
            if (string.IsNullOrWhiteSpace(styles))
                return this;

            xdoc.Root.SetAttributeValue("style", $"{GetRootStyleAttributeValue()} {styles}");

            return this;
        }

        public VectorGraphicBuilder BuildIcon()
        {
            if (iconType == IconType.Outlined.Loading)
            {
                xdoc.Root.SetAttributeValue("viewBox", "0 0 1024 1024");
            }
            else
            {
                xdoc.Root.SetAttributeValue("viewBox", "64 64 896 896");
            }

            xdoc.Root.SetAttributeValue("focusable", false);
            xdoc.Root.SetAttributeValue("aria-hidden", true);
            return this;
        }

        private string GetRootClassAttributeValue()
        {
            return xdoc.Root.Attribute("class")?.Value;
        }
        private string GetRootStyleAttributeValue()
        {
            return xdoc.Root.Attribute("style")?.Value;
        }

        public VectorGraphicBuilder SetTwoToneColors(string color1, string color2)
        {
            if (iconType.GetType() != typeof(IconType.TwoTone))
                return this;

            var primaryColor = DeterminePrimaryColor(color1);
            var secondaryColor = DetermineSecondaryColor(color2);

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
            return this;
        }
        private string DeterminePrimaryColor(string primaryColor)
        {
            return string.IsNullOrWhiteSpace(primaryColor) ? IconType.TwoTone.DefaultPrimaryColor : primaryColor;
        }
        private string DetermineSecondaryColor(string secondaryColor)
        {
            return string.IsNullOrWhiteSpace(secondaryColor) ? IconType.TwoTone.DefaultSecondaryColor : secondaryColor;
        }
    }
}
