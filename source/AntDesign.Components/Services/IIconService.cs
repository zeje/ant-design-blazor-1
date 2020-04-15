using Append.AntDesign.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Append.AntDesign.Services
{
    public interface IIconService
    {
        Task<XDocument> GetVectorGraphicTemplateAsync(IconType iconType);
    }
}
