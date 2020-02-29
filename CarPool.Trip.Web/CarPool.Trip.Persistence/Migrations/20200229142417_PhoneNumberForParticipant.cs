using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPool.Trip.Persistence.Migrations
{
    public partial class PhoneNumberForParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Participants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Participants");
        }
    }
}
