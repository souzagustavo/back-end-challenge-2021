using BackEndChallengeDotNet.Application.ApiClients;
using BackEndChallengeDotNet.Application.Facades;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using System;

namespace BackEndChallengeDotNet.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddRandomUserApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetValue<string>("RandomUser:Uri");

            var refitSettings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(
                        new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                            ContractResolver = new CamelCasePropertyNamesContractResolver()
                        })
            };
            services.AddRefitClient<IRandomUserClient>(refitSettings)
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(url));

            return services;
        }

        public static IServiceCollection AddRandomUserService(this IServiceCollection services)
        {
            services.AddScoped<IRandomUserService, RandomUserService>();
            return services;
        }
    }
}
