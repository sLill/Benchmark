using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;

namespace Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
            var summary = BenchmarkRunner.Run<DbContextBenchmark>();

            Console.ReadKey();
        }
    }
}