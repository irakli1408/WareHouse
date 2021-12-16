using Microsoft.EntityFrameworkCore.Migrations;

namespace WareHouseLibrary.Migrations
{
    public partial class addRequisiteNewColumnCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "count",
                table: "Requisites",
                newName: "Count");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Requisites",
                newName: "count");
        }
    }
}
