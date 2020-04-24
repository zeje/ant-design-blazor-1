using Append.AntDesign.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Append.AntDesign.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAntDesign(this IServiceCollection services)
        {
            services.AddHttpClient<IIconService, IconService>();
            services.AddScoped<IClipboardService, ClipboardService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<IWindowService,WindowService>();
            return services;
        }
    }
}
