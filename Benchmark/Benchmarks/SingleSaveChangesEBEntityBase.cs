using Benchmark.Database;
using Benchmark.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks
{
    public class SingleSaveChangesEBEntityBase
    {
        private BenchmarkDbContext _dbContext;

        [GlobalSetup]
        public void Setup()
        {
            _dbContext = new BenchmarkDbContext();
        }

        [Benchmark]
        [IterationCount(1)]
        [InvocationCount(1)]
        public void Yes_EntityBase_SaveChangesEntityBaseFields()
        {
            for (int i = 0; i < 10000; i++)
            {
                _dbContext.BenchmarkRecords.Add(new BenchmarkRecord());
                _dbContext.SaveChangesEntityBase();
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _dbContext.Dispose();
        }
    }
}
