using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_table_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_CarDayInfos_CarDayInfoId",
                table: "car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarDayInfos",
                table: "CarDayInfos");

            migrationBuilder.RenameTable(
                name: "CarDayInfos",
                newName: "car_day_info");

            migrationBuilder.AddPrimaryKey(
                name: "PK_car_day_info",
                table: "car_day_info",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_car_day_info_CarDayInfoId",
                table: "car",
                column: "CarDayInfoId",
                principalTable: "car_day_info",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_car_car_day_info_CarDayInfoId",
                table: "car");

            migrationBuilder.DropPrimaryKey(
                name: "PK_car_day_info",
                table: "car_day_info");

            migrationBuilder.RenameTable(
                name: "car_day_info",
                newName: "CarDayInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarDayInfos",
                table: "CarDayInfos",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_car_CarDayInfos_CarDayInfoId",
                table: "car",
                column: "CarDayInfoId",
                principalTable: "CarDayInfos",
                principalColumn: "id");
        }
    }
}
