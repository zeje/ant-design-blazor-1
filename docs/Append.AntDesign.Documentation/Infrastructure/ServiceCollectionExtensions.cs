using Append.AntDesign.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Append.AntDesign.Documentation.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAntDesignDocumentation(this IServiceCollection services)
        {
            services.AddHttpClient<GitHubService>();
            return services;
        }
    }
}
