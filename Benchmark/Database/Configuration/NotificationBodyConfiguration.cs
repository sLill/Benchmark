using Benchmark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benchmark.Database.Configuration
{
    public class NotificationBodyConfiguration : IEntityTypeConfiguration<NotificationBody>
    {
        public void Configure(EntityTypeBuilder<NotificationBody> modelBuilder)
        {
            modelBuilder.HasKey(nb => nb.NotificationBodyId);

            modelBuilder.HasOne(nb => nb.Notification)
                .WithMany(n => n.NotificationBodies)
                .HasForeignKey(nb => nb.NotificationId);

            modelBuilder.Property(nb => nb.Text)
                .HasColumnType("NVARCHAR(MAX)");

            modelBuilder.Property(nb => nb.Color)
                .HasColumnType("NVARCHAR(64)");

            modelBuilder.Property(nb => nb.Locale)
                .HasColumnType("NVARCHAR(32)");
        }
    }
}
