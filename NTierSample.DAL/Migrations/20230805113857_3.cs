using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierSample.DAL.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_Product_ProductID",
                table: "ListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_ShoppingList_ShoppingListID",
                table: "ListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_User_UserID",
                table: "ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "ShoppingList",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingList_UserID",
                table: "ShoppingList",
                newName: "IX_ShoppingList_UserId");

            migrationBuilder.RenameColumn(
                name: "ShoppingListID",
                table: "ListItem",
                newName: "ShoppingListId");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "ListItem",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ListItem",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_ListItem_ShoppingListID",
                table: "ListItem",
                newName: "IX_ListItem_ShoppingListId");

            migrationBuilder.RenameIndex(
                name: "IX_ListItem_ProductID",
                table: "ListItem",
                newName: "IX_ListItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserID",
                table: "Orders",
                newName: "IX_Orders_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListId",
                table: "ListItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ListItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ListItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ShipAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "ID");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "CreatedDate", "Image", "IsActive", "Name" },
                values: new object[] { 1, new DateTime(2023, 8, 5, 14, 38, 57, 254, DateTimeKind.Local).AddTicks(785), "https://static.vecteezy.com/system/resources/previews/008/848/360/original/fresh-apple-fruit-free-png.png", true, "Apple" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_Product_ProductId",
                table: "ListItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_ShoppingList_ShoppingListId",
                table: "ListItem",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_User_UserID",
                table: "Orders",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_User_UserId",
                table: "ShoppingList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_Product_ProductId",
                table: "ListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItem_ShoppingList_ShoppingListId",
                table: "ListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_User_UserID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_User_UserId",
                table: "ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ListItem");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ListItem");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingList",
                newName: "UserID");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingList_UserId",
                table: "ShoppingList",
                newName: "IX_ShoppingList_UserID");

            migrationBuilder.RenameColumn(
                name: "ShoppingListId",
                table: "ListItem",
                newName: "ShoppingListID");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ListItem",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ListItem",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ListItem_ShoppingListId",
                table: "ListItem",
                newName: "IX_ListItem_ShoppingListID");

            migrationBuilder.RenameIndex(
                name: "IX_ListItem_ProductId",
                table: "ListItem",
                newName: "IX_ListItem_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserID",
                table: "Order",
                newName: "IX_Order_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingListID",
                table: "ListItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ShipAddress",
                table: "Order",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "ShoppingList",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 17, 40, 48, 301, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 17, 40, 48, 301, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_Product_ProductID",
                table: "ListItem",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItem_ShoppingList_ShoppingListID",
                table: "ListItem",
                column: "ShoppingListID",
                principalTable: "ShoppingList",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserID",
                table: "Order",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_User_UserID",
                table: "ShoppingList",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
