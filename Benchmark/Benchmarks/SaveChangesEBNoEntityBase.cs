using Benchmark.Database;
using Benchmark.Models;
using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks
{
    public class SaveChangesEBNoEntityBase
    {
        private BenchmarkDbContext _dbContext;

        [GlobalSetup]
        public void Setup()
        {
            _dbContext = new BenchmarkDbContext();
        }

        [Benchmark]
        public void No_EntityBase_SaveChangesEntityBaseFields()
        {
            for (int i = 0; i < 10000; i++)
                _dbContext.BenchmarkRecordNoBases.Add(new BenchmarkRecordNoBase());

            _dbContext.SaveChangesEntityBase();
        }

        [GlobalCleanup]
        public void Cleanup()
        {
            _dbContext.Dispose();
        }
    }
}
