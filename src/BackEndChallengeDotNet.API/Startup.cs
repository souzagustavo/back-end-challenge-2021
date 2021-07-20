using BackEndChallengeDotNet.API.UseCases.Users.V1.Delete;
using BackEndChallengeDotNet.API.UseCases.Users.V1.GetById;
using BackEndChallengeDotNet.API.UseCases.Users.V1.GetList;
using BackEndChallengeDotNet.API.UseCases.Users.V1.Put;
using BackEndChallengeDotNet.Application.HostedServices;
using BackEndChallengeDotNet.Bootstrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackEndChallengeDotNet.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.ConfigureApiServices(Configuration);
            services.AddHostedService<ImportUserCronJob>();

            services.AddTransient<DeleteUserPresenter>();
            services.AddTransient<GetByIdUserPresenter>();
            services.AddTransient<GetListUserPresenter>();
            services.AddTransient<PutUserPresenter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                    c.RoutePrefix = "docs";
                });
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
