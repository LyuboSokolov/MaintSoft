using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class RemoveRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Status_StatusId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_Status_StatusId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_StatusId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Assets_StatusId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Assets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Assets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Status_StatusId",
                table: "Status",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_StatusId",
                table: "Assets",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Status_StatusId",
                table: "Assets",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Status_StatusId",
                table: "Status",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }
    }
}
