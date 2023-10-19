using Benchmark.Benchmarks;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Benchmark
{
    public class Executor : BackgroundService
    {
        private readonly ILogger<Executor> _logger;
        private readonly IHost _host;

        public Executor(ILogger<Executor> logger, IHost host) 
        {
            _logger = logger;
            _host = host;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //var summary = BenchmarkRunner.Run<SaveChangesEBEntityBase>();
            //var summary = BenchmarkRunner.Run<SaveChangesEBNoEntityBase>();
            //var summary = BenchmarkRunner.Run<SaveChangesEntityBase>();
            //var summary = BenchmarkRunner.Run<SaveChangesNoEntityBase>();
            var summary = BenchmarkRunner.Run<SingleSaveChangesEBEntityBase>();
            summary = BenchmarkRunner.Run<SingleSaveChangesEBNoEntityBase>();
            summary = BenchmarkRunner.Run<SingleSaveChangesEntityBase>();
            summary = BenchmarkRunner.Run<SingleSaveChangesNoEntityBase>();

            Console.ReadKey();

            await _host.StopAsync();
        }
    }
}
