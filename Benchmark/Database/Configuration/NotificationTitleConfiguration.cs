using Benchmark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benchmark.Database.Configuration
{
    public class NotificationTitleConfiguration : IEntityTypeConfiguration<NotificationTitle>
    {
        public void Configure(EntityTypeBuilder<NotificationTitle> modelBuilder)
        {
            modelBuilder.HasKey(nt => nt.NotificationTitleId);

            modelBuilder.HasOne(nt => nt.Notification)
                .WithMany(n => n.NotificationTitles)
                .HasForeignKey(nt => nt.NotificationId);

            modelBuilder.Property(nt => nt.Text)
                .HasColumnType("NVARCHAR(MAX)");

            modelBuilder.Property(nt => nt.Locale)
                .HasColumnType("NVARCHAR(32)");
        }
    }
}
