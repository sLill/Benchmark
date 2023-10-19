using Benchmark.Database;
using Benchmark.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks
{
    public class SingleSaveChangesEntityBase
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
        public void Yes_EntityBase_SaveChanges()
        {
            for (int i = 0; i < 10000; i++)
            {
                BenchmarkRecord record = new BenchmarkRecord()
                {
                    CreatedOnUtc = DateTime.UtcNow,
                    ModifiedOnUtc = DateTime.UtcNow
                };

                _dbContext.BenchmarkRecords.Add(record);
                _dbContext.SaveChanges();
            }
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _dbContext.Dispose();
        }
    }
}
