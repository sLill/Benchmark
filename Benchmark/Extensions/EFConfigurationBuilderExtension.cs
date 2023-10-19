using Benchmark.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Benchmark.Extensions
{
    public static class EFConfigurationBuilderExtension
    {
        public static IConfigurationBuilder AddEFConfiguration(this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> optionsAction)
        {
            return builder.Add(new EFConfigurationSource(optionsAction));
        }
    }
}
