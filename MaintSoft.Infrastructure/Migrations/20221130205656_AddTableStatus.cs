using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class AddTableStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "AppTasks");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "AppTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppTasks_StatusId",
                table: "AppTasks",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTasks_Status_StatusId",
                table: "AppTasks",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTasks_Status_StatusId",
                table: "AppTasks");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_AppTasks_StatusId",
                table: "AppTasks");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "AppTasks");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AppTasks",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
