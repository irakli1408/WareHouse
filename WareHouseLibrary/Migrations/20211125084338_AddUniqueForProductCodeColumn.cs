using Microsoft.EntityFrameworkCore.Migrations;

namespace WareHouseLibrary.Migrations
{
    public partial class AddUniqueForProductCodeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCode",
                table: "Products",
                column: "ProductCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCode",
                table: "Products");
        }
    }
}
