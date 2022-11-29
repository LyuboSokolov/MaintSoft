using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class AddSomeEntityesForCreatedAndDeleteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserCreatedId",
                table: "SpareParts",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserDeletedId",
                table: "SpareParts",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreatedId",
                table: "Manufacturers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserDeletedId",
                table: "Manufacturers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreatedId",
                table: "Machines",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserDeletedId",
                table: "Machines",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserCreatedId",
                table: "Assets",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserDeletedId",
                table: "Assets",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "UserDeletedId",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "UserDeletedId",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "UserDeletedId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "UserCreatedId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "UserDeletedId",
                table: "Assets");
        }
    }
}
