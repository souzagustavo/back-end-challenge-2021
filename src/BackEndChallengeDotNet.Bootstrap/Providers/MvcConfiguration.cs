using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace BackEndChallengeDotNet.Bootstrap.Providers
{
    public static class MvcConfiguration
    {
        public static IServiceCollection ConfigureMvcServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Back-End Challenge - API",
                    Description = "Back-End Microservice developed in ASP.NET Core",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Gustavo Souza Silva",
                        Email = "gustavosouz.a@hotmail.com",
                        Url = new Uri("https://github.com/souzagustavo"),
                    },
                });
            });

            return services;
        }
    }
}
