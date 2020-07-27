using System;
using System.Threading;
using System.Threading.Tasks;
using AspnetWorkerService.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AspnetWorkerService.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILoggerAdapter<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(ILoggerAdapter<Worker> logger, 
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
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