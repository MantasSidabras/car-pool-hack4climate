using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPool.Trip.Persistence.Migrations
{
    public partial class ParticipantUniquePhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Participants_PhoneNumber",
                table: "Participants",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Participants_PhoneNumber",
                table: "Participants");
        }
    }
}
