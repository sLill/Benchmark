using Benchmark.Database;
using Benchmark.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks
{
    public class SaveChangesEBEntityBase
    {
        private BenchmarkDbContext _dbContext;

        [GlobalSetup]
        public void Setup()
        {
            _dbContext = new BenchmarkDbContext();
        }

        [Benchmark]
        public void Yes_EntityBase_SaveChangesEntityBaseFields()
        {
            for (int i = 0; i < 10000; i++)
                _dbContext.BenchmarkRecords.Add(new BenchmarkRecord());

            _dbContext.SaveChangesEntityBase();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _dbContext.Dispose();
        }
    }
}
