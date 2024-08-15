using LamodaB2BSDK.Core;
using LamodaB2BSDK.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LamodaB2BSDK.Extensions;

public static class HostBuilderExtensions
{
    public static IHostBuilder AddLamodaB2B(this IHostBuilder hostBuilder)
    {
        return hostBuilder.ConfigureServices((_, services) =>
        {
            services.AddSingleton<LamodaB2BApplication>();
            services.AddSingleton<LamodaB2BClient>();
        });
    }
}