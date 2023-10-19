using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Benchmark.Database
{
    public class EFConfigurationProvider : ConfigurationProvider
    {
        private readonly Action<DbContextOptionsBuilder> _optionsAction;

        public EFConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            _optionsAction = optionsAction;
        }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<BenchmarkDbContext>();

            _optionsAction(builder);

            using (var dbContext = new BenchmarkDbContext(builder.Options))
            {
                dbContext.Database.EnsureDeleted();

                dbContext.Database.Migrate();
            }
        }
    }
}
