using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class AddDataForRelationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 8, 19, 28, 14, 784, DateTimeKind.Local).AddTicks(960), new DateTime(2023, 8, 8, 19, 28, 14, 784, DateTimeKind.Local).AddTicks(997) });

            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 8, 19, 28, 14, 784, DateTimeKind.Local).AddTicks(1003), new DateTime(2023, 8, 8, 19, 28, 14, 784, DateTimeKind.Local).AddTicks(1005) });

            migrationBuilder.InsertData(
                table: "ApplicationUsersAppTasks",
                columns: new[] { "AppTaskId", "ApplicationUserId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "1" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1b3980a-2324-4d9a-a2e2-226d1a38ce15", "AQAAAAEAACcQAAAAEOSVkGOLpuqBOnFzhFl0BVOByjCNfaWeiiUTTewg9o8x7f88ln0LtPLRamoP0BhMig==", "80fcf018-235f-4cb9-a353-02b292b10a2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8d72a76-5bc4-4500-a46f-44f07f26b167", "AQAAAAEAACcQAAAAED29OVt8rKTfnOq6YFMUwns1xe6kO/3PbjJdjlgpHWDjA6PR39taQCS2dv9Gom1PjA==", "9b714191-d408-47a0-a3f7-9861b8a9b97e" });

            migrationBuilder.InsertData(
                table: "MachinesAppTasks",
                columns: new[] { "AppTaskId", "MachineId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUsersAppTasks",
                keyColumns: new[] { "AppTaskId", "ApplicationUserId" },
                keyValues: new object[] { 1, "1" });

            migrationBuilder.DeleteData(
                table: "ApplicationUsersAppTasks",
                keyColumns: new[] { "AppTaskId", "ApplicationUserId" },
                keyValues: new object[] { 2, "1" });

            migrationBuilder.DeleteData(
                table: "MachinesAppTasks",
                keyColumns: new[] { "AppTaskId", "MachineId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MachinesAppTasks",
                keyColumns: new[] { "AppTaskId", "MachineId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 7, 23, 43, 47, 156, DateTimeKind.Local).AddTicks(6408), new DateTime(2023, 8, 7, 23, 43, 47, 156, DateTimeKind.Local).AddTicks(6451) });

            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 7, 23, 43, 47, 156, DateTimeKind.Local).AddTicks(6469), new DateTime(2023, 8, 7, 23, 43, 47, 156, DateTimeKind.Local).AddTicks(6472) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bb2ad9b-e17b-48da-9704-7bc10c8a6cbe", "AQAAAAEAACcQAAAAEPWtXLgStT24gOMH3CXg9LcX/MVe3+6lGUL27yHpuUw+Zn/BLEQUq5AMxwdpjmkWgA==", "b4e970d8-7f26-4924-8eeb-1f346b8f301f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f221c7c9-6183-45cb-a9ff-09077f433a04", "AQAAAAEAACcQAAAAENdOYKz2SkE2jQXzibkpq2HfR9fIVErtd2xpCJCN4hlgwNG4HXJ63tjvcgjKv4GXUw==", "030f1ffa-786d-4607-80ae-3088fe5952f7" });
        }
    }
}
