using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieBooking.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBookingSeatDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Shows_ShowId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSeats_Bookings_BookingId",
                table: "BookingSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Screens_ScreenId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Screens_ScreenId",
                table: "Shows");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Shows_ShowId",
                table: "Bookings",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSeats_Bookings_BookingId",
                table: "BookingSeats",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Screens_ScreenId",
                table: "Seats",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Screens_ScreenId",
                table: "Shows",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Shows_ShowId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingSeats_Bookings_BookingId",
                table: "BookingSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Screens_ScreenId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Screens_ScreenId",
                table: "Shows");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Shows_ShowId",
                table: "Bookings",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingSeats_Bookings_BookingId",
                table: "BookingSeats",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Screens_ScreenId",
                table: "Seats",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Screens_ScreenId",
                table: "Shows",
                column: "ScreenId",
                principalTable: "Screens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
