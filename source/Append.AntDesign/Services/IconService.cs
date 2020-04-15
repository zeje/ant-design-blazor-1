using Append.AntDesign.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Append.AntDesign.Services
{
    public class IconService : IIconService
    {
        private readonly HttpClient Client;
        private static readonly ConcurrentDictionary<IconType, XDocument> SvgCache = new ConcurrentDictionary<IconType, XDocument>();

        public IconService(HttpClient client, NavigationManager navigationManeger)
        {
            client.BaseAddress = new Uri(navigationManeger.BaseUri);
            Client = client;
        }

        public async Task<XDocument> GetVectorGraphicTemplateAsync(IconType iconType)
        {
            if (SvgCache.TryGetValue(iconType, out var xdoc))
                return xdoc;

            xdoc = await ReadVectorGraphicFile(iconType);
            SvgCache.TryAdd(iconType, xdoc);
            return xdoc;
        }

        private async Task<XDocument> ReadVectorGraphicFile(IconType iconType)
        {
            try
            {
                var svgString = await Client.GetStringAsync($"_content/Append.AntDesign/icons/{iconType.Theme}/{iconType.NormalisedIconFileName}.svg");
                return XDocument.Parse(svgString);
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException($"Icon file '{iconType.Theme}/{iconType.NormalisedIconFileName}.svg' was not found.", ex);
            }
        }
    }
}
