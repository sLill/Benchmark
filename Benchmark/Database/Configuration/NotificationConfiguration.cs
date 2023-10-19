using Benchmark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benchmark.Database.Configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> modelBuilder)
        {
            modelBuilder.HasKey(n => n.NotificationId);

            modelBuilder.Property(n => n.Source)
                .HasColumnType("NVARCHAR(128)")
                .IsRequired();

            modelBuilder.Property(n => n.SourceId)
                .HasColumnType("NVARCHAR(255)")
                .IsRequired();

            modelBuilder.Property(n => n.Name)
                .HasColumnType("NVARCHAR(255)");

            modelBuilder.Property(n => n.QrCode)
                .HasColumnType("NVARCHAR(MAX)");
        }
    }
}
