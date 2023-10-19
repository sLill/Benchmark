using Benchmark.Models;
using Microsoft.EntityFrameworkCore;

namespace Benchmark
{
    public class BenchmarkDbContext : DbContext
    {
        public DbSet<BenchmarkRecord> BenchmarkRecords { get; set; }
        public DbSet<BenchmarkRecordNoBase> BenchmarkRecordNoBases { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationBody> NotificationBodies { get; set; }
        public DbSet<NotificationResponse> NotificationResponses { get; set; }
        public DbSet<NotificationTitle>  NotificationTitles { get; set; }
        public DbSet<UsersToNotification> UsersToNotifications { get; set; }
        public DbSet<UsersToNotification_Acknowledged> UsersToNotification_Acknowledgeds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=BenchmarkRecords;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {
            UpdateEntityBaseFields();
            return base.SaveChanges();
        }

        private void UpdateEntityBaseFields()
        {
            var modelEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entry in modelEntries)
            {
                ((EntityBase)entry.Entity).ModifiedOnUtc = DateTimeOffset.UtcNow;

                if (entry.State == EntityState.Added)
                    ((EntityBase)entry.Entity).CreatedOnUtc = DateTimeOffset.UtcNow;
            }
        }
    }
}
