using Append.AntDesign.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Append.AntDesign.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAntDesign(this IServiceCollection services)
        {
            services.AddHttpClient<IIconService, IconService>();
            return services;
        }
    }
}
