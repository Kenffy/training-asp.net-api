using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AddVillaNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    villaNo = table.Column<int>(type: "int", nullable: false),
                    specialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.villaNo);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 6, 52, 388, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 6, 52, 388, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 3,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 6, 52, 388, DateTimeKind.Local).AddTicks(6585));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 4,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 6, 52, 388, DateTimeKind.Local).AddTicks(6588));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 5,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 6, 52, 388, DateTimeKind.Local).AddTicks(6592));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8758));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 3,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8801));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 4,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 5,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 9, 16, 24, 748, DateTimeKind.Local).AddTicks(8807));
        }
    }
}
