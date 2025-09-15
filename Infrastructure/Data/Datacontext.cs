using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    // DbSets för alla entities
    public DbSet<Event> Events { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Event configuration
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Location).IsRequired().HasMaxLength(200);

            // Foreign key relationships
            entity
                .HasOne(e => e.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        // Category configuration
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Description).HasMaxLength(500);
            entity.Property(c => c.Color).HasMaxLength(50);
            entity.Property(c => c.Icon).HasMaxLength(100);
        });

        // Seed data
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        // Använd statiska datum istället för DateTime.UtcNow
        var baseDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        var eventDate = new DateTime(2025, 1, 15, 0, 0, 0, DateTimeKind.Utc);

        // Seed Categories
        modelBuilder
            .Entity<Category>()
            .HasData(
                new Category
                {
                    Id = 1,
                    Name = "Yoga",
                    Description = "Mindful movement and stretching",
                    Color = "#8B5CF6",
                    Icon = "fa-leaf",
                    CreatedAt = baseDate,
                    IsActive = true,
                    SortOrder = 1,
                },
                new Category
                {
                    Id = 2,
                    Name = "CrossFit",
                    Description = "High-intensity functional fitness",
                    Color = "#EF4444",
                    Icon = "fa-dumbbell",
                    CreatedAt = baseDate,
                    IsActive = true,
                    SortOrder = 2,
                },
                new Category
                {
                    Id = 3,
                    Name = "Spinning",
                    Description = "Indoor cycling workout",
                    Color = "#10B981",
                    Icon = "fa-bicycle",
                    CreatedAt = baseDate,
                    IsActive = true,
                    SortOrder = 3,
                },
                new Category
                {
                    Id = 4,
                    Name = "Pilates",
                    Description = "Core strength and flexibility",
                    Color = "#F59E0B",
                    Icon = "fa-circle",
                    CreatedAt = baseDate,
                    IsActive = true,
                    SortOrder = 4,
                }
            );

        // Seed Events
        modelBuilder
            .Entity<Event>()
            .HasData(
                new Event
                {
                    Id = 1,
                    Title = "Morning Yoga Flow",
                    Description = "Start your day with energizing yoga poses and mindful breathing",
                    StartTime = eventDate.AddHours(7),
                    EndTime = eventDate.AddHours(8),
                    Location = "Studio A",
                    MaxParticipants = 20,
                    AvailableSpots = 20,
                    CategoryId = 1,
                    CreatedAt = baseDate,
                    IsActive = true,
                },
                new Event
                {
                    Id = 2,
                    Title = "CrossFit WOD",
                    Description =
                        "High-intensity workout of the day - build strength and endurance",
                    StartTime = eventDate.AddHours(18),
                    EndTime = eventDate.AddHours(19),
                    Location = "Main Gym",
                    MaxParticipants = 15,
                    AvailableSpots = 15,
                    CategoryId = 2,
                    CreatedAt = baseDate,
                    IsActive = true,
                },
                new Event
                {
                    Id = 3,
                    Title = "Spin Class",
                    Description = "45 minutes of intense cycling with motivating music",
                    StartTime = eventDate.AddHours(19),
                    EndTime = eventDate.AddHours(19).AddMinutes(45),
                    Location = "Spin Room",
                    MaxParticipants = 25,
                    AvailableSpots = 25,
                    CategoryId = 3,
                    CreatedAt = baseDate,
                    IsActive = true,
                },
                new Event
                {
                    Id = 4,
                    Title = "Evening Pilates",
                    Description =
                        "Gentle pilates session focusing on core strength and flexibility",
                    StartTime = eventDate.AddDays(1).AddHours(17),
                    EndTime = eventDate.AddDays(1).AddHours(18),
                    Location = "Studio B",
                    MaxParticipants = 18,
                    AvailableSpots = 18,
                    CategoryId = 4,
                    CreatedAt = baseDate,
                    IsActive = true,
                }
            );
    }
}
