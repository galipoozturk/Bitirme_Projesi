using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTierSample.DAL.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShoppingList_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShoppingListID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListItem_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListItem_ShoppingList_ShoppingListID",
                        column: x => x.ShoppingListID,
                        principalTable: "ShoppingList",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "ShoppingList",
                columns: new[] { "ID", "CreatedDate", "IsActive", "Name", "Status", "UserID" },
                values: new object[] { 1, new DateTime(2023, 8, 4, 17, 40, 48, 301, DateTimeKind.Local).AddTicks(2653), true, "Martys List", 0, 1 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 17, 40, 48, 301, DateTimeKind.Local).AddTicks(2129));

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ProductID",
                table: "ListItem",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ListItem_ShoppingListID",
                table: "ListItem",
                column: "ShoppingListID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_UserID",
                table: "ShoppingList",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListItem");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 8, 4, 16, 59, 45, 487, DateTimeKind.Local).AddTicks(6032));
        }
    }
}
