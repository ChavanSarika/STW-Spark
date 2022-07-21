using Microsoft.EntityFrameworkCore.Migrations;

namespace  STW_Spark.Data.Migrations
{
    public partial class AddServiceTablesk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serviceDetails_ServiceType_ServiceheaderId",
                table: "serviceDetails");

            migrationBuilder.CreateIndex(
                name: "IX_serviceDetails_ServiceTypeId",
                table: "serviceDetails",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_serviceDetails_ServiceType_ServiceTypeId",
                table: "serviceDetails",
                column: "ServiceTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serviceDetails_ServiceType_ServiceTypeId",
                table: "serviceDetails");

            migrationBuilder.DropIndex(
                name: "IX_serviceDetails_ServiceTypeId",
                table: "serviceDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_serviceDetails_ServiceType_ServiceheaderId",
                table: "serviceDetails",
                column: "ServiceheaderId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
