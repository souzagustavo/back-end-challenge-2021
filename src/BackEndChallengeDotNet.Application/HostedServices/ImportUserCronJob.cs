using BackEndChallengeDotNet.Application.Facades;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackEndChallengeDotNet.Application.HostedServices
{
    public class ImportUserCronJob : CronJob
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ImportUserCronJob> _logger;

        public ImportUserCronJob(IConfiguration configuration, ILogger<ImportUserCronJob> logger, IServiceProvider serviceProvider)
            : base(configuration.GetValue<string>("CronJobSchedule"), TimeZoneInfo.Utc)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ImportUserCronJob)} starts.");
            return base.StartAsync(cancellationToken);
        }

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ImportUserCronJob)} is working.");
            using IServiceScope scope = _serviceProvider.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<IRandomUserService>();

            await service.PopulateDatabaseAsync();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(ImportUserCronJob)} stopping."); 
            return base.StopAsync(cancellationToken);
        }
    }
}
