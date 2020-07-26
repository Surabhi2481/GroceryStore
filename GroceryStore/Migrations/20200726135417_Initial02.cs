using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroceryStore.Migrations
{
    public partial class Initial02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vendors",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(maxLength: 25, nullable: false),
                    dob = table.Column<DateTime>(nullable: true),
                    contactNumber = table.Column<string>(maxLength: 10, nullable: false),
                    address = table.Column<string>(maxLength: 50, nullable: false),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendors", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(nullable: false),
                    productName = table.Column<string>(nullable: false),
                    availability = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_products_vendors_userId",
                        column: x => x.userId,
                        principalTable: "vendors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_userId",
                table: "products",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "vendors");
        }
    }
}
