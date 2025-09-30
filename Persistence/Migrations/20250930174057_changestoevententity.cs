using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changestoevententity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationRoom",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Events",
                newName: "TrainerId");

            migrationBuilder.AddColumn<string>(
                name: "LocationId",
                table: "Events",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "Events",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "LocationRoom",
                table: "Events",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
