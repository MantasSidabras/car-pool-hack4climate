using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPool.Trip.Persistence.Migrations
{
    public partial class EventAdditionalStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUri",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LogoUri",
                table: "Events");
        }
    }
}
