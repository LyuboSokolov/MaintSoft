using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class AddEntityToAppTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContractorId",
                table: "AppTasks",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreatedId",
                table: "AppTasks",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractorId",
                table: "AppTasks");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "AppTasks");
        }
    }
}
