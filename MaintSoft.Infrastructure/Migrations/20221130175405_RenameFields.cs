using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class RenameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersAppTasks_AppTasks_TaskId",
                table: "ApplicationUsersAppTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_MachinesAppTasks_AppTasks_TaskId",
                table: "MachinesAppTasks");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "MachinesAppTasks",
                newName: "AppTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_MachinesAppTasks_TaskId",
                table: "MachinesAppTasks",
                newName: "IX_MachinesAppTasks_AppTaskId");

            migrationBuilder.RenameColumn(
                name: "ContractorId",
                table: "AppTasks",
                newName: "UserContractorId");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "ApplicationUsersAppTasks",
                newName: "AppTaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersAppTasks_TaskId",
                table: "ApplicationUsersAppTasks",
                newName: "IX_ApplicationUsersAppTasks_AppTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersAppTasks_AppTasks_AppTaskId",
                table: "ApplicationUsersAppTasks",
                column: "AppTaskId",
                principalTable: "AppTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachinesAppTasks_AppTasks_AppTaskId",
                table: "MachinesAppTasks",
                column: "AppTaskId",
                principalTable: "AppTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsersAppTasks_AppTasks_AppTaskId",
                table: "ApplicationUsersAppTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_MachinesAppTasks_AppTasks_AppTaskId",
                table: "MachinesAppTasks");

            migrationBuilder.RenameColumn(
                name: "AppTaskId",
                table: "MachinesAppTasks",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_MachinesAppTasks_AppTaskId",
                table: "MachinesAppTasks",
                newName: "IX_MachinesAppTasks_TaskId");

            migrationBuilder.RenameColumn(
                name: "UserContractorId",
                table: "AppTasks",
                newName: "ContractorId");

            migrationBuilder.RenameColumn(
                name: "AppTaskId",
                table: "ApplicationUsersAppTasks",
                newName: "TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUsersAppTasks_AppTaskId",
                table: "ApplicationUsersAppTasks",
                newName: "IX_ApplicationUsersAppTasks_TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsersAppTasks_AppTasks_TaskId",
                table: "ApplicationUsersAppTasks",
                column: "TaskId",
                principalTable: "AppTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachinesAppTasks_AppTasks_TaskId",
                table: "MachinesAppTasks",
                column: "TaskId",
                principalTable: "AppTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
