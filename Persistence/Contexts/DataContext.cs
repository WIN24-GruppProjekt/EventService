using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<EventEntity> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure EventEntity
        modelBuilder.Entity<EventEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Location).IsRequired().HasMaxLength(200);
            entity.Property(e => e.LocationRoom).HasMaxLength(100);
            entity.Property(e => e.StartTime).IsRequired();
            entity.Property(e => e.EndTime).IsRequired();
        });
    }
}
