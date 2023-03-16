using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingApi.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyOnDeleteSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Vehicle_VehicleId",
                table: "Driver");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Vehicle_VehicleId",
                table: "Driver",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Vehicle_VehicleId",
                table: "Driver");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Vehicle_VehicleId",
                table: "Driver",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }
    }
}
