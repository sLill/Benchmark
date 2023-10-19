using Benchmark.Extensions;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Benchmark
{
    internal class Program
    {
        private const string _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=BenchmarkRecords;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(builder =>
            {
                builder.Sources.Clear();

                builder.AddEFConfiguration(options =>
                {
                    options.UseSqlServer(_connectionString);
                });
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Executor>();
            });
    }
}