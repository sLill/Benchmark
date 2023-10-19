using Benchmark.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benchmark.Database.Configuration
{
    public class NotificationResponseConfiguration : IEntityTypeConfiguration<NotificationResponse>
    {
        public void Configure(EntityTypeBuilder<NotificationResponse> modelBuilder)
        {
            modelBuilder.HasKey(nr => nr.NotificationResponseId);

            modelBuilder.HasOne(nr => nr.Notification)
                .WithMany(n => n.NotificationResponses)
                .HasForeignKey(nr => nr.NotificationId);

            modelBuilder.Property(nr => nr.Text)
                .HasColumnType("NVARCHAR(MAX)");

            modelBuilder.Property(nr => nr.Value)
                .HasColumnType("NVARCHAR(MAX)");

            modelBuilder.Property(nr => nr.Color)
                .HasColumnType("NVARCHAR(64)");

            modelBuilder.Property(nr => nr.Locale)
                .HasColumnType("NVARCHAR(32)");
        }
    }
}
