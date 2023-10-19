using Benchmark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benchmark.Database.Configuration
{
    public class UsersToNotificationConfiguration : IEntityTypeConfiguration<UsersToNotification>
    {
        public void Configure(EntityTypeBuilder<UsersToNotification> modelBuilder)
        {
            modelBuilder.HasKey(utn => utn.UsersToNotificationId);

            modelBuilder.HasOne(utn => utn.Notification)
                .WithMany(n => n.UsersToNotification);
        }
    }
}
