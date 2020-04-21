using Append.AntDesign.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Append.AntDesign.Services
{
    public interface IIconService
    {
        Task<XDocument> GetVectorGraphicTemplateAsync(IconType iconType);
        Task PreloadIconsAsync(IEnumerable<IconType> iconsToPreload);
        Task PreloadIconsAsync();
    }
}
