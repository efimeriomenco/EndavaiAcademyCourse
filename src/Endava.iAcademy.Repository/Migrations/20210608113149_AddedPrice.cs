using Microsoft.EntityFrameworkCore.Migrations;

namespace Endava.iAcademy.Repository.Migrations
{
    public partial class AddedPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Courses",
                maxLength: 150,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Courses");
        }
    }
}
