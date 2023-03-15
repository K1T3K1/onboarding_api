using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingApi.Migrations
{
    /// <inheritdoc />
    public partial class MakeNullableDriverVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Vehicles_VehicleId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Makes_MakeId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Makes",
                table: "Makes");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.RenameTable(
                name: "Makes",
                newName: "Make");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicle",
                newName: "IX_Vehicle_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Models_MakeId",
                table: "Model",
                newName: "IX_Model_MakeId");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Driver",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Make",
                table: "Make",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Vehicle_VehicleId",
                table: "Driver",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Make_MakeId",
                table: "Model",
                column: "MakeId",
                principalTable: "Make",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Model_ModelId",
                table: "Vehicle",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Vehicle_VehicleId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Model_Make_MakeId",
                table: "Model");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Model_ModelId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Make",
                table: "Make");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.RenameTable(
                name: "Make",
                newName: "Makes");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_ModelId",
                table: "Vehicles",
                newName: "IX_Vehicles_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Model_MakeId",
                table: "Models",
                newName: "IX_Models_MakeId");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Driver",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Makes",
                table: "Makes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Vehicles_VehicleId",
                table: "Driver",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Makes_MakeId",
                table: "Models",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
