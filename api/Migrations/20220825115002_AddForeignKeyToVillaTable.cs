using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class AddForeignKeyToVillaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "villaId",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 1,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 50, 2, 287, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 2,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 50, 2, 287, DateTimeKind.Local).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 3,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 50, 2, 287, DateTimeKind.Local).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 4,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 50, 2, 287, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "id",
                keyValue: 5,
                column: "createdAt",
                value: new DateTime(2022, 8, 25, 13, 50, 2, 287, DateTimeKind.Local).AddTicks(5937));

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_villaId",
                table: "VillaNumbers",
                column: "villaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_villaId",
                table: "VillaNumbers",
                column: "villaId",
                principalTable: "Villas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_villaId",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_villaId",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "villaId",
                table: "VillaNumbers");

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
    }
}
