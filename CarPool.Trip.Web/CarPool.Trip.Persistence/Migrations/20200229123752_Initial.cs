using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarPool.Trip.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Carplate = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventTrips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<int>(nullable: false),
                    DriverId = table.Column<int>(nullable: false),
                    TripStartTime = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTrips_Participants_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTrips_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripJoinRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PassengerId = table.Column<int>(nullable: false),
                    EventTripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripJoinRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripJoinRequests_EventTrips_EventTripId",
                        column: x => x.EventTripId,
                        principalTable: "EventTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TripJoinRequests_Participants_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventTrips_DriverId",
                table: "EventTrips",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTrips_EventId",
                table: "EventTrips",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TripJoinRequests_EventTripId",
                table: "TripJoinRequests",
                column: "EventTripId");

            migrationBuilder.CreateIndex(
                name: "IX_TripJoinRequests_PassengerId",
                table: "TripJoinRequests",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripJoinRequests");

            migrationBuilder.DropTable(
                name: "EventTrips");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
