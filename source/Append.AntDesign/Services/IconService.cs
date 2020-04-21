using Append.AntDesign.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Append.AntDesign.Services
{
    public class IconService : IIconService
    {
        private readonly HttpClient Client;
        private static readonly ConcurrentDictionary<IconType, XDocument> SvgCache = new ConcurrentDictionary<IconType, XDocument>();

        public IconService(HttpClient client, NavigationManager navigationManager)
        {
            client.BaseAddress = new Uri(navigationManager.BaseUri);
            Client = client;
        }

        public async Task<XDocument> GetVectorGraphicTemplateAsync(IconType iconType)
        {
            if (SvgCache.TryGetValue(iconType, out var xdoc))
                return xdoc;

            xdoc = await ReadIconTemplateFile(iconType);
            SvgCache.TryAdd(iconType, xdoc);
            return xdoc;
        }

        private async Task<XDocument> ReadIconTemplateFile(IconType iconType)
        {
            try
            {
                var svgString = await Client.GetStringAsync($"_content/Append.AntDesign/icons/{iconType.NormalisedIconFileName}.svg");
                return XDocument.Parse(svgString);
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException($"Icon file '{iconType.NormalisedIconFileName}.svg' was not found.", ex);
            }
        }

        public async Task PreloadIconsAsync(IEnumerable<IconType> iconsToPreload)
        {
            foreach (var item in iconsToPreload)
            {
                await GetVectorGraphicTemplateAsync(item);
            }
        }
        public Task PreloadIconsAsync()
        {
            return PreloadIconsAsync(IconType.List);
        }
    }
}
