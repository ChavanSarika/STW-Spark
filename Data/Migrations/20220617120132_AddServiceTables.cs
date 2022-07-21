using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace  STW_Spark.Data.Migrations
{
    public partial class AddServiceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "serviceHeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Miles = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_serviceHeader_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "serviceShopingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceShopingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_serviceShopingCart_car_CarId",
                        column: x => x.CarId,
                        principalTable: "car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_serviceShopingCart_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "serviceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceheaderId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    ServicePrice = table.Column<double>(type: "float", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_serviceDetails_serviceHeader_ServiceheaderId",
                        column: x => x.ServiceheaderId,
                        principalTable: "serviceHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_serviceDetails_ServiceType_ServiceheaderId",
                        column: x => x.ServiceheaderId,
                        principalTable: "ServiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_serviceDetails_ServiceheaderId",
                table: "serviceDetails",
                column: "ServiceheaderId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceHeader_CarId",
                table: "serviceHeader",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceShopingCart_CarId",
                table: "serviceShopingCart",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_serviceShopingCart_ServiceTypeId",
                table: "serviceShopingCart",
                column: "ServiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "serviceDetails");

            migrationBuilder.DropTable(
                name: "serviceShopingCart");

            migrationBuilder.DropTable(
                name: "serviceHeader");
        }
    }
}
