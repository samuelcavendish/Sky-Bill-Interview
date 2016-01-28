using Microsoft.Extensions.DependencyInjection;
using Sky.Services.BillManagers;
using Sky.Services.LogManagers;
using Sky.Services.RestApiClientFactories;

namespace Sky.Services
{
    public static class DependencyInjectionExtension
    {
        public static void AddSkyServices(this IServiceCollection services)
        {
            services.AddSingleton<IRestApiClientFactory, RestApiClientFactory>();
            services.AddSingleton<IBillManager, BillManager>();
            services.AddSingleton<ILogManager, LogManager>();
        }
    }
}
