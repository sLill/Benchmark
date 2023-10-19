using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    public class DbContextBenchmark
    {
        private BenchmarkDbContext _dbContext;

        [GlobalSetup]
        public void Setup()
        {
            _dbContext = new BenchmarkDbContext();

            for (int i = 0; i < 10000; i++)
                _dbContext.BenchmarkRecordNoBases.Add(new BenchmarkRecordNoBase());
        }

        [Benchmark]
        public void UpdateEntityBaseFieldsBenchmark()
        {
            _dbContext.SaveChanges();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _dbContext.Dispose();
        }
    }
}
