using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class change_models_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_CarDayInfos_CarDayInfoId",
                table: "Car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.RenameTable(
                name: "Car",
                newName: "car");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CarDayInfos",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "CarDayInfos",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarDayInfos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Parking",
                table: "car",
                newName: "parking");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "car",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "car",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "WasScreen",
                table: "car",
                newName: "was_screen");

            migrationBuilder.RenameColumn(
                name: "Was24kmET",
                table: "car",
                newName: "was24km_et");

            migrationBuilder.RenameColumn(
                name: "IsWorked",
                table: "car",
                newName: "is_worked");

            migrationBuilder.RenameColumn(
                name: "FuelEnd",
                table: "car",
                newName: "fuel_end");

            migrationBuilder.RenameColumn(
                name: "FuelBegin",
                table: "car",
                newName: "fuel_begin");

            migrationBuilder.RenameColumn(
                name: "AddInformation",
                table: "car",
                newName: "add_information");

            migrationBuilder.RenameIndex(
                name: "IX_Car_CarDayInfoId",
                table: "car",
                newName: "IX_car_CarDayInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_car",
                table: "car",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_CarDayInfos_CarDayInfoId",
                table: "car",
                column: "CarDayInfoId",
                principalTable: "CarDayInfos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_CarDayInfos_CarDayInfoId",
                table: "car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_car",
                table: "car");

            migrationBuilder.RenameTable(
                name: "car",
                newName: "Car");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "CarDayInfos",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "CarDayInfos",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CarDayInfos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "parking",
                table: "Car",
                newName: "Parking");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Car",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Car",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "was_screen",
                table: "Car",
                newName: "WasScreen");

            migrationBuilder.RenameColumn(
                name: "was24km_et",
                table: "Car",
                newName: "Was24kmET");

            migrationBuilder.RenameColumn(
                name: "is_worked",
                table: "Car",
                newName: "IsWorked");

            migrationBuilder.RenameColumn(
                name: "fuel_end",
                table: "Car",
                newName: "FuelEnd");

            migrationBuilder.RenameColumn(
                name: "fuel_begin",
                table: "Car",
                newName: "FuelBegin");

            migrationBuilder.RenameColumn(
                name: "add_information",
                table: "Car",
                newName: "AddInformation");

            migrationBuilder.RenameIndex(
                name: "IX_car_CarDayInfoId",
                table: "Car",
                newName: "IX_Car_CarDayInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_CarDayInfos_CarDayInfoId",
                table: "Car",
                column: "CarDayInfoId",
                principalTable: "CarDayInfos",
                principalColumn: "Id");
        }
    }
}
