using Microsoft.EntityFrameworkCore.Migrations;

namespace Sebo.Infrastructure.Persistence.Migrations
{
    public partial class AddProcessColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessingStatus",
                table: "Chapter",
                type: "INT",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessingStatus",
                table: "Chapter");
        }
    }
}
