using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarDayInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDayInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    IsWorked = table.Column<bool>(type: "boolean", nullable: false),
                    FuelBegin = table.Column<int>(type: "integer", nullable: false),
                    FuelEnd = table.Column<int>(type: "integer", nullable: false),
                    WasScreen = table.Column<bool>(type: "boolean", nullable: false),
                    Was24kmET = table.Column<bool>(type: "boolean", nullable: false),
                    Parking = table.Column<List<int>>(type: "integer[]", nullable: false),
                    AddInformation = table.Column<List<string>>(type: "text[]", nullable: false),
                    CarDayInfoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_CarDayInfos_CarDayInfoId",
                        column: x => x.CarDayInfoId,
                        principalTable: "CarDayInfos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarDayInfoId",
                table: "Car",
                column: "CarDayInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarDayInfos");
        }
    }
}
