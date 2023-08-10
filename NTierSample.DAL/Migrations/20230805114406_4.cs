using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierSample.DAL.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ListItem",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "ListItem",
                columns: new[] { "ID", "CreatedDate", "Description", "IsActive", "ProductId", "ShoppingListId" },
                values: new object[] { 1, new DateTime(2023, 8, 5, 14, 44, 5, 734, DateTimeKind.Local).AddTicks(1203), null, true, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 44, 5, 733, DateTimeKind.Local).AddTicks(9112));

            migrationBuilder.UpdateData(
                table: "ShoppingList",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 44, 5, 734, DateTimeKind.Local).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 44, 5, 734, DateTimeKind.Local).AddTicks(200));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ListItem",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ListItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 38, 57, 254, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "ShoppingList",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 38, 57, 254, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 38, 57, 254, DateTimeKind.Local).AddTicks(2290));
        }
    }
}
