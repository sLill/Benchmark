using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Benchmark
{
    public class BenchmarkDbContext : DbContext
    {
        public DbSet<BenchmarkRecord> BenchmarkRecords { get; set; }
        public DbSet<BenchmarkRecordNoBase> BenchmarkRecordNoBases { get; set; }

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
