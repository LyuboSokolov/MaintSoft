using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class AddDateToAppTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AppTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AppTasks",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AppTasks");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AppTasks");
        }
    }
}
