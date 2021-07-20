using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using MediatR;
using System.Diagnostics.CodeAnalysis;

namespace BackEndChallengeDotNet.Bootstrap.Providers
{
    [ExcludeFromCodeCoverage]
    public static class MediatorConfiguration
    {
        private const string APPLICATION_NAMESPACE = "BackEndChallengeDotNet.Application";
        public static IServiceCollection ConfigureMediatrServices(this IServiceCollection services)
        {
            var types = Assembly
                .Load(APPLICATION_NAMESPACE)
                .GetTypes()
                .Where(a => a.IsClass && a.Namespace != null && a.Name.EndsWith("Handler"))
                .ToArray();

            services.AddMediatR(types);

            return services;
        }
    }
}
