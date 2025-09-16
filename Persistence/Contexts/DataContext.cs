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

        // Seed mock data
        SeedMockData(modelBuilder);
    }

    private void SeedMockData(ModelBuilder modelBuilder)
    {
        var events = new List<EventEntity>
        {
            new EventEntity
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Title = "Morning Yoga",
                Description =
                    "Start your day with a relaxing yoga session. Perfect for all skill levels.",
                StartTime = DateTime.Today.AddDays(1).AddHours(7),
                EndTime = DateTime.Today.AddDays(1).AddHours(8),
                Location = "Core Gym Haninge",
                LocationRoom = "Studio A",
            },
            new EventEntity
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Title = "HIIT Training",
                Description =
                    "High-intensity interval training to boost your metabolism and strength.",
                StartTime = DateTime.Today.AddDays(1).AddHours(18),
                EndTime = DateTime.Today.AddDays(1).AddHours(19),
                Location = "Core Gym Haninge",
                LocationRoom = "Main Floor",
            },
            new EventEntity
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Title = "Spin Class",
                Description =
                    "Energetic cycling workout with motivating music and expert instruction.",
                StartTime = DateTime.Today.AddDays(2).AddHours(9),
                EndTime = DateTime.Today.AddDays(2).AddHours(10),
                Location = "Core Gym Haninge",
                LocationRoom = "Spin Studio",
            },
            new EventEntity
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Title = "Strength Training",
                Description =
                    "Build muscle and improve your overall strength with guided weight training.",
                StartTime = DateTime.Today.AddDays(2).AddHours(17),
                EndTime = DateTime.Today.AddDays(2).AddHours(18).AddMinutes(30),
                Location = "Core Gym Haninge",
                LocationRoom = "Weight Room",
            },
            new EventEntity
            {
                Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
                Title = "Pilates",
                Description =
                    "Improve flexibility, balance, and core strength with this low-impact workout.",
                StartTime = DateTime.Today.AddDays(3).AddHours(10),
                EndTime = DateTime.Today.AddDays(3).AddHours(11),
                Location = "Core Gym Haninge",
                LocationRoom = "Studio B",
            },
            new EventEntity
            {
                Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
                Title = "CrossFit WOD",
                Description =
                    "Workout of the Day featuring functional movements at high intensity.",
                StartTime = DateTime.Today.AddDays(3).AddHours(19),
                EndTime = DateTime.Today.AddDays(3).AddHours(20),
                Location = "Core Gym Haninge",
                LocationRoom = "CrossFit Box",
            },
            new EventEntity
            {
                Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
                Title = "Aqua Fitness",
                Description =
                    "Low-impact water-based exercise that's easy on joints but tough on calories.",
                StartTime = DateTime.Today.AddDays(4).AddHours(11),
                EndTime = DateTime.Today.AddDays(4).AddHours(12),
                Location = "Core Gym Haninge",
                LocationRoom = "Pool Area",
            },
            new EventEntity
            {
                Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
                Title = "Zumba Dance",
                Description =
                    "Fun and energetic dance fitness class with Latin and international music.",
                StartTime = DateTime.Today.AddDays(5).AddHours(18).AddMinutes(30),
                EndTime = DateTime.Today.AddDays(5).AddHours(19).AddMinutes(30),
                Location = "Core Gym Haninge",
                LocationRoom = "Dance Studio",
            },
            new EventEntity
            {
                Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
                Title = "Personal Training Session",
                Description = "One-on-one training session customized to your fitness goals.",
                StartTime = DateTime.Today.AddDays(6).AddHours(14),
                EndTime = DateTime.Today.AddDays(6).AddHours(15),
                Location = "Core Gym Haninge",
                LocationRoom = "PT Room 1",
            },
            new EventEntity
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Title = "Meditation & Mindfulness",
                Description =
                    "Relax and center yourself with guided meditation and breathing exercises.",
                StartTime = DateTime.Today.AddDays(7).AddHours(8),
                EndTime = DateTime.Today.AddDays(7).AddHours(9),
                Location = "Core Gym Haninge",
                LocationRoom = "Quiet Room",
            },
        };

        modelBuilder.Entity<EventEntity>().HasData(events);
    }
}
