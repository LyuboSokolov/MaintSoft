using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaintSoft.Infrastructure.Migrations
{
    public partial class SeedAllDataInDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserDeletedId",
                table: "Assets",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCreatedId",
                table: "Assets",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "JobPosition", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "867d24b4-0da6-408b-b316-c5d42b80c032", "lubo@abv.bg", "Lyubo", "Manager", "Sokolov", "lubo@abv.bg", "lubo", "AQAAAAEAACcQAAAAEOaBQoU/7uFxDsv51nWci3Ac0qK7MKd0pAnTvXaGAg5+ptfXGWraG2nx003TDzyT9g==", "59fb31c8-211c-4b02-82d3-3af91d596234", "lyubo" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDelete", "JobPosition", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "9476b775-e847-4b45-923e-f79d205e14ef", "ivan@abv.bg", false, "Ivan", false, "Engineer", "Ivanov", false, null, "ivan@abv.bg", "ivan", "AQAAAAEAACcQAAAAEGV5ci/54SswI6zFWd1YlQfYpSbL88GdEK+am/x8UaA5ZkqRODC9OJYlEo++vit3xA==", null, false, "0cd89f21-81b0-4bb8-b4b5-97c95bf46d8b", false, "Ivan" });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "Code", "Description", "ImageUrl", "IsDelete", "Location", "Name", "UserCreatedId", "UserDeletedId" },
                values: new object[,]
                {
                    { 1, "GHW1_221_314", "for mcb", "https://teeptrak.com/wp-content/uploads/2020/10/TRS-mesurervotreperformancemachine-scaled.jpeg", false, "Desto", "Final Assembly", "1", null },
                    { 2, "GHW1_386_441", "Magnetic tester for MCB", "https://img.directindustry.com/images_di/photo-g/19857-14864675.webp", false, "Desto", "Magnetic Test", "2", null },
                    { 3, "GHW2_386_441", "Thermal tester for MCB", "https://img.directindustry.com/images_di/photo-mg/19857-17472673.jpg", false, "Desto", "Thermal Test", "1", null }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "Address", "Contacts", "Description", "IsDelete", "Name", "UserCreatedId", "UserDeletedId", "VAT" },
                values: new object[,]
                {
                    { 1, "Germany str.20", "+359 000 23 93", "Production of cylinder", false, "Festo", "1", null, "GB999 99 9991" },
                    { 2, "Sofia str.Vasil Levski", "+402 000 22 93", "Production of sensor", false, "Omron", "2", null, "BG1 232 771" },
                    { 3, "Plovdiv str.Vasil Levski", "+23 11 3345 93", "Production of sensor and scaner", false, "IFM", "1", null, "BG1 123 334" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "In Process" },
                    { 3, "Stopped" },
                    { 4, "Done" }
                });

            migrationBuilder.InsertData(
                table: "AppTasks",
                columns: new[] { "Id", "CreatedDate", "Description", "IsDelete", "Name", "StatusId", "UpdatedDate", "UserContractorId", "UserCreatedId", "UserDeleteId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 7, 22, 25, 39, 376, DateTimeKind.Local).AddTicks(580), "Repair clutch", false, "broken clutch", 1, new DateTime(2023, 8, 7, 22, 25, 39, 376, DateTimeKind.Local).AddTicks(617), "1", "1", null },
                    { 2, new DateTime(2023, 8, 7, 22, 25, 39, 376, DateTimeKind.Local).AddTicks(625), "Repair contactor", false, "broken contactor", 2, new DateTime(2023, 8, 7, 22, 25, 39, 376, DateTimeKind.Local).AddTicks(627), "2", "1", null }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "Code", "Description", "ImageUrl", "IsDelete", "Location", "ManufacturerId", "Name", "Quantity", "UserCreatedId", "UserDeletedId" },
                values: new object[,]
                {
                    { 1, "DSNU-16-20 ADNGF", "Standart cilinder", "https://ch.farnell.com/productimages/large/en_GB/3431515-40.jpg", false, "Desto", 1, "Cylinder", 2, "1", null },
                    { 2, "ABB 07-10-30", "Standart contactor", "https://bg.farnell.com/productimages/large/en_GB/1846130-40.jpg", false, "Desto", 1, "Contactor", 1, "1", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SpareParts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SpareParts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "UserDeletedId",
                table: "Assets",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserCreatedId",
                table: "Assets",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "Email", "FirstName", "JobPosition", "LastName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4bec0ca9-2fd8-4652-b254-42fa1705df30", "petko@abv.bg", "Petko", "maintenance technician", "Petkov", null, null, null, "ce1f2917-f0cf-4533-b538-747452913e07", "pecata" });
        }
    }
}
