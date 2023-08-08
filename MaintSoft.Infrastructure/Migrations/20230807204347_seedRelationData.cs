using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class seedRelationData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
