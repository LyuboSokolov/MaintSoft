using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class seedAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 28, 32, 971, DateTimeKind.Local).AddTicks(2814), new DateTime(2023, 8, 7, 22, 28, 32, 971, DateTimeKind.Local).AddTicks(2851) });

            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 28, 32, 971, DateTimeKind.Local).AddTicks(2860), new DateTime(2023, 8, 7, 22, 28, 32, 971, DateTimeKind.Local).AddTicks(2862) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19b2ecd4-a5cb-45f5-aec1-f632958b96f3", "AQAAAAEAACcQAAAAEP85gKMSRDTyQZ35ON0sWeS2QY3Ige8+0LXlkaq9gbkZM79dO0AhJszsUatFSupT4g==", "d60fee8d-5084-4a30-b57f-19be62f05d81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd9ebe39-4f0c-4de5-be46-c004e1977b71", "AQAAAAEAACcQAAAAEBQe5XvxiNp+hTJ+4Z29kr4Dp7iYOP5VQ3g94CdbjLOhXQaiNgNmocDXrot8L+2eMA==", "9120ee0a-c0f7-4f41-9835-bde26c9c7c31" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "ApplicationUserId", "Description", "IsAvailable", "IsDelete", "Name", "UserCreatedId", "UserDeletedId" },
                values: new object[,]
                {
                    { 1, "2", "Workstation", true, false, "Laptop_p50", "2", null },
                    { 2, "2", "smartphone", true, false, "Samsung_s20", "2", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 25, 39, 376, DateTimeKind.Local).AddTicks(580), new DateTime(2023, 8, 7, 22, 25, 39, 376, DateTimeKind.Local).AddTicks(617) });

            migrationBuilder.UpdateData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 25, 39, 376, DateTimeKind.Local).AddTicks(625), new DateTime(2023, 8, 7, 22, 25, 39, 376, DateTimeKind.Local).AddTicks(627) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "867d24b4-0da6-408b-b316-c5d42b80c032", "AQAAAAEAACcQAAAAEOaBQoU/7uFxDsv51nWci3Ac0qK7MKd0pAnTvXaGAg5+ptfXGWraG2nx003TDzyT9g==", "59fb31c8-211c-4b02-82d3-3af91d596234" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9476b775-e847-4b45-923e-f79d205e14ef", "AQAAAAEAACcQAAAAEGV5ci/54SswI6zFWd1YlQfYpSbL88GdEK+am/x8UaA5ZkqRODC9OJYlEo++vit3xA==", "0cd89f21-81b0-4bb8-b4b5-97c95bf46d8b" });
        }
    }
}
