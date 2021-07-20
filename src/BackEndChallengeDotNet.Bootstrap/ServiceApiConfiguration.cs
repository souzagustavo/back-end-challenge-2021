using BackEndChallengeDotNet.Application;
using BackEndChallengeDotNet.Bootstrap.Providers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndChallengeDotNet.Bootstrap
{
    public static class ServiceApiConfiguration
    {
        public static IServiceCollection ConfigureApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureMediatrServices();
            services.ConfigurePersistenceServices(configuration);
            services.ConfigureMvcServices();
            services.AddRandomUserApiClient(configuration);
            services.AddRandomUserService();

            return services;
        }
    }
}
