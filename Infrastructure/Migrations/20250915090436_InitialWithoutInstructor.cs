using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithoutInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Color = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Icon = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    MaxParticipants = table.Column<int>(type: "INTEGER", nullable: false),
                    AvailableSpots = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "Description", "Icon", "IsActive", "Name", "SortOrder", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "#8B5CF6", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mindful movement and stretching", "fa-leaf", true, "Yoga", 1, null },
                    { 2, "#EF4444", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-intensity functional fitness", "fa-dumbbell", true, "CrossFit", 2, null },
                    { 3, "#10B981", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Indoor cycling workout", "fa-bicycle", true, "Spinning", 3, null },
                    { 4, "#F59E0B", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Core strength and flexibility", "fa-circle", true, "Pilates", 4, null }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AvailableSpots", "CategoryId", "CreatedAt", "Description", "EndTime", "IsActive", "Location", "MaxParticipants", "StartTime", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 20, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Start your day with energizing yoga poses and mindful breathing", new DateTime(2025, 1, 15, 8, 0, 0, 0, DateTimeKind.Utc), true, "Studio A", 20, new DateTime(2025, 1, 15, 7, 0, 0, 0, DateTimeKind.Utc), "Morning Yoga Flow", null },
                    { 2, 15, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-intensity workout of the day - build strength and endurance", new DateTime(2025, 1, 15, 19, 0, 0, 0, DateTimeKind.Utc), true, "Main Gym", 15, new DateTime(2025, 1, 15, 18, 0, 0, 0, DateTimeKind.Utc), "CrossFit WOD", null },
                    { 3, 25, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "45 minutes of intense cycling with motivating music", new DateTime(2025, 1, 15, 19, 45, 0, 0, DateTimeKind.Utc), true, "Spin Room", 25, new DateTime(2025, 1, 15, 19, 0, 0, 0, DateTimeKind.Utc), "Spin Class", null },
                    { 4, 18, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gentle pilates session focusing on core strength and flexibility", new DateTime(2025, 1, 16, 18, 0, 0, 0, DateTimeKind.Utc), true, "Studio B", 18, new DateTime(2025, 1, 16, 17, 0, 0, 0, DateTimeKind.Utc), "Evening Pilates", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
