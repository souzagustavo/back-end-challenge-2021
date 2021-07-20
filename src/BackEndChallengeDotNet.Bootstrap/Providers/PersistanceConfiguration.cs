using BackEndChallengeDotNet.Domain.Interfaces;
using BackEndChallengeDotNet.Persistance;
using BackEndChallengeDotNet.Persistance.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndChallengeDotNet.Bootstrap.Providers
{
    public static class PersistanceConfiguration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddMongoDB(configuration);

            return services;
        }
    }
}
