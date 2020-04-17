using Append.AntDesign.Core;
using Append.AntDesign.Documentation.Infrastructure;
using Append.AntDesign.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Append.AntDesign.Documentation.Standalone
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            builder.Services.AddAntDesign();
            builder.Services.AddAntDesignDocumentation();
            builder.Services.AddHttpClient("app", c =>
            {
                c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
            });
            await builder.Build().RunAsync();
        }
    }
}
