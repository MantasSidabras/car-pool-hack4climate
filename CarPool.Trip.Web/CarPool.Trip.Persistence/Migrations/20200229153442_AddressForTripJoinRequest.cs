using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPool.Trip.Persistence.Migrations
{
    public partial class AddressForTripJoinRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TripJoinRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TripJoinRequests");
        }
    }
}
