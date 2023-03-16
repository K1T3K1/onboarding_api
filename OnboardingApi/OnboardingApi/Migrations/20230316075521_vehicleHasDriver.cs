using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingApi.Migrations
{
    /// <inheritdoc />
    public partial class vehicleHasDriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Driver_VehicleId",
                table: "Driver");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Driver_VehicleId",
                table: "Driver",
                column: "VehicleId",
                unique: true,
                filter: "[VehicleId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Driver_VehicleId",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Vehicle");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_VehicleId",
                table: "Driver",
                column: "VehicleId");
        }
    }
}
