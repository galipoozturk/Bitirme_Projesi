using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierSample.DAL.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ListItem",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 45, 41, 136, DateTimeKind.Local).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 45, 41, 136, DateTimeKind.Local).AddTicks(1707));

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreatedDate", "Image", "IsActive", "Name" },
                values: new object[] { 2, new DateTime(2023, 8, 5, 14, 45, 41, 136, DateTimeKind.Local).AddTicks(1731), "https://static.vecteezy.com/system/resources/previews/008/848/360/original/fresh-apple-fruit-free-png.png", true, "Samsung" });

            migrationBuilder.UpdateData(
                table: "ShoppingList",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 45, 41, 136, DateTimeKind.Local).AddTicks(3197));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 45, 41, 136, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.InsertData(
                table: "ListItem",
                columns: new[] { "ID", "CreatedDate", "Description", "IsActive", "ProductId", "ShoppingListId" },
                values: new object[] { 2, new DateTime(2023, 8, 5, 14, 45, 41, 136, DateTimeKind.Local).AddTicks(3621), null, true, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ListItem",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ListItem",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 5, 14, 44, 5, 734, DateTimeKind.Local).AddTicks(1203));

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
    }
}
