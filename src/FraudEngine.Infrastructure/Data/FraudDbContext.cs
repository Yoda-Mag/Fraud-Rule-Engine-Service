using Microsoft.EntityFrameworkCore;
using FraudEngine.Core.Models;

namespace FraudEngine.Infrastructure.Data
{
    public class FraudDbContext : DbContext
    {
        public FraudDbContext(DbContextOptions<FraudDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<Alert> Alerts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Transaction entity configuration
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.AccountId)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(t => t.Merchant)
                      .HasMaxLength(200);

                entity.Property(t => t.Amount)
                      .HasPrecision(18, 2);

                entity.Property(t => t.Timestamp)
                      .IsRequired();
            });

            // Alert entity configuration
            modelBuilder.Entity<Alert>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.AccountId)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(a => a.RuleName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(a => a.Score)
                      .IsRequired();

                entity.Property(a => a.Description)
                      .HasMaxLength(500);

                entity.Property(a => a.CreatedAt)
                      .IsRequired();
            });
        }
    }
}
