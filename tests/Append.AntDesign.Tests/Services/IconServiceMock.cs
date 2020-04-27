using Append.AntDesign.Components;
using Append.AntDesign.Services;
using Bunit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Append.AntDesign.Tests.Services
{
    public class IconServiceMock : IIconService
    {
        private static string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.FullName;
        public Task<XDocument> GetVectorGraphicTemplateAsync(IconType iconType)
        {
            string iconPath = Path.Combine(solutionDirectory, @$"source/Append.AntDesign/wwwroot/icons/{iconType.NormalisedIconFileName}.svg");
            return Task.FromResult(XDocument.Load(iconPath));
        }

        public Task PreloadIconsAsync(IEnumerable<IconType> iconsToPreload)
        {
            return Task.CompletedTask;
        }

        public Task PreloadIconsAsync()
        {
            return Task.CompletedTask;
        }
    }
}
