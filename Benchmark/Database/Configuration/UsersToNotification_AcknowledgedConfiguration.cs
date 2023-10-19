using Benchmark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benchmark.Database.Configuration
{
    public class UsersToNotification_AcknowledgedConfiguration : IEntityTypeConfiguration<UsersToNotification_Acknowledged>
    {
        public void Configure(EntityTypeBuilder<UsersToNotification_Acknowledged> modelBuilder)
        {
            modelBuilder.HasKey(utna => utna.UsersToNotification_AcknowledgedId);
        }
    }
}
