using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class AddStatusAppTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AppTasks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppTasks");
        }
    }
}
