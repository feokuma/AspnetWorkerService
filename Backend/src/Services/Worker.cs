using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace AspnetWorkerService.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly IPublicClientApplication _publicClientApplication;

        public Worker(ILogger<Worker> logger,
            IConfiguration configuration,
            IPublicClientApplication publicClientApplication)
        {
            _logger = logger;
            _configuration = configuration;
            _publicClientApplication = publicClientApplication;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            var scopes = _configuration.GetValue<string[]>("MicrosoftGraph:Scopes");
            await Task.Delay(1000, cancellationToken);
            //_publicClientApplication.AcquireTokenInteractive();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}