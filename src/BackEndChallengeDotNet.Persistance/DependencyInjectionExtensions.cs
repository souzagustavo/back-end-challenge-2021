using BackEndChallengeDotNet.Persistance.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;

namespace BackEndChallengeDotNet.Persistance
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            var cs = configuration.GetConnectionString("MongoDB");
            MongoDbContext mongoConnection = new(new MongoUrl(cs));

            services.AddSingleton(mongoConnection);
            services.AddHealthChecks()
                    .AddMongoDb(cs, name: "mongo-db", failureStatus: HealthStatus.Unhealthy);

            return services;
        }
    }
}
