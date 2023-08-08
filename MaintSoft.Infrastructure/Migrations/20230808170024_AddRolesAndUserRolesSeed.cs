using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class AddRolesAndUserRolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 0, 24, 29, DateTimeKind.Local).AddTicks(8967), new DateTime(2023, 8, 8, 20, 0, 24, 29, DateTimeKind.Local).AddTicks(9005) });

            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 0, 24, 29, DateTimeKind.Local).AddTicks(9019), new DateTime(2023, 8, 8, 20, 0, 24, 29, DateTimeKind.Local).AddTicks(9027) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "e821c43e-236a-4615-a454-7af10dd382e3", "Administrator", "ADMINISTRATOR" },
                    { "2", "c20198be-88e7-48e8-a58f-920717c23954", "Engineer", "ENGINEER" },
                    { "3", "f4124e32-6f00-4b83-895f-d50317234f01", "Operator", "Operator" },
                    { "4", "ba2e85bb-669f-404a-bfe1-b479b75098a9", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d81b81c-0e6f-496c-8f2d-45b81aa015d2", "AQAAAAEAACcQAAAAEKN/g9gUKlYnTVog/7zTRq4D1eeQECqTcKYes+1dMoJFIDYA4kguSfek8/VrB1Xrfw==", "5c986303-e3db-4d57-ad17-c71aefc05a5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06120052-4b75-4c41-bbba-40033d5e0720", "AQAAAAEAACcQAAAAEBshUXvGy5ty6KubAre5ntN1WEpiCAEQLxh4iQo+Yj5uURnjIZyvXTKK1fhkJAyakQ==", "b7409c7c-773c-4bab-a3cc-c0480ce034fe" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

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
        }
    }
}
