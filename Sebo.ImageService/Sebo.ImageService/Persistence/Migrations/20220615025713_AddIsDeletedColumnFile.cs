using Microsoft.EntityFrameworkCore.Migrations;

namespace Sebo.ImageService.Persistence.Migrations
{
    public partial class AddIsDeletedColumnFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "File",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "File");
        }
    }
}
