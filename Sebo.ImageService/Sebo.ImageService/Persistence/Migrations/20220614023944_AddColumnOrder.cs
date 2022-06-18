using Microsoft.EntityFrameworkCore.Migrations;

namespace Sebo.ImageService.Persistence.Migrations
{
    public partial class AddColumnOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "File",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "File");
        }
    }
}
