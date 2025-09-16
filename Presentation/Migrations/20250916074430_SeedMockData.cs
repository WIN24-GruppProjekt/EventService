using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Presentation.Migrations
{
    /// <inheritdoc />
    public partial class SeedMockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EndTime", "Location", "LocationRoom", "StartTime", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Start your day with a relaxing yoga session. Perfect for all skill levels.", new DateTime(2025, 9, 17, 8, 0, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "Studio A", new DateTime(2025, 9, 17, 7, 0, 0, 0, DateTimeKind.Local), "Morning Yoga" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "High-intensity interval training to boost your metabolism and strength.", new DateTime(2025, 9, 17, 19, 0, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "Main Floor", new DateTime(2025, 9, 17, 18, 0, 0, 0, DateTimeKind.Local), "HIIT Training" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Energetic cycling workout with motivating music and expert instruction.", new DateTime(2025, 9, 18, 10, 0, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "Spin Studio", new DateTime(2025, 9, 18, 9, 0, 0, 0, DateTimeKind.Local), "Spin Class" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Build muscle and improve your overall strength with guided weight training.", new DateTime(2025, 9, 18, 18, 30, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "Weight Room", new DateTime(2025, 9, 18, 17, 0, 0, 0, DateTimeKind.Local), "Strength Training" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Improve flexibility, balance, and core strength with this low-impact workout.", new DateTime(2025, 9, 19, 11, 0, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "Studio B", new DateTime(2025, 9, 19, 10, 0, 0, 0, DateTimeKind.Local), "Pilates" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Workout of the Day featuring functional movements at high intensity.", new DateTime(2025, 9, 19, 20, 0, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "CrossFit Box", new DateTime(2025, 9, 19, 19, 0, 0, 0, DateTimeKind.Local), "CrossFit WOD" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Low-impact water-based exercise that's easy on joints but tough on calories.", new DateTime(2025, 9, 20, 12, 0, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "Pool Area", new DateTime(2025, 9, 20, 11, 0, 0, 0, DateTimeKind.Local), "Aqua Fitness" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Fun and energetic dance fitness class with Latin and international music.", new DateTime(2025, 9, 21, 19, 30, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "Dance Studio", new DateTime(2025, 9, 21, 18, 30, 0, 0, DateTimeKind.Local), "Zumba Dance" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "One-on-one training session customized to your fitness goals.", new DateTime(2025, 9, 22, 15, 0, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "PT Room 1", new DateTime(2025, 9, 22, 14, 0, 0, 0, DateTimeKind.Local), "Personal Training Session" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Relax and center yourself with guided meditation and breathing exercises.", new DateTime(2025, 9, 23, 9, 0, 0, 0, DateTimeKind.Local), "Core Gym Haninge", "Quiet Room", new DateTime(2025, 9, 23, 8, 0, 0, 0, DateTimeKind.Local), "Meditation & Mindfulness" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));
        }
    }
}
