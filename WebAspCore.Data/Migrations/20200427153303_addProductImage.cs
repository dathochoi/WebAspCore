using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCore.Data.Migrations
{
    public partial class addProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("600ff89a-5b95-441a-aada-5dab1d36522d"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("b3063e3f-635a-428b-9723-f075ec93ff9a"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("cc12640e-28d5-4e89-b169-1e5eecf729c8"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("57ef887d-b68a-4d69-b82f-7cf1b87cbacf"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("57ef887d-b68a-4d69-b82f-7cf1b87cbacf"), new Guid("cc12640e-28d5-4e89-b169-1e5eecf729c8") });

            migrationBuilder.AddColumn<bool>(
                name: "Selected",
                table: "ProductImages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7fe43f3f-c326-47f1-ae26-2334a2c796b1"), "4ba7e85f-cfbd-4eb8-9540-3e564e0b6a95", "Top manager", "Admin", "Admin" },
                    { new Guid("7bb5879e-1d26-4078-b1ab-88b933fa19b7"), "7577924c-a8cb-4529-b62e-dd3588447f16", "Staff", "Staff", "Staff" },
                    { new Guid("04846256-7007-4101-8b2f-b879d49026b9"), "cbb33907-a8fd-4355-ac86-b74305104cb8", "Customer", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("172393a6-4d3c-45a2-a06f-0dc9575cad2b"), 0, null, 0m, null, "2cf3c0ba-1e7a-4b82-90b2-ad5ef593b643", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAECYHpQXzrAsVwmFn516H6RvtheidNvvNgp1i6sqwgXJsA7shns5Df7w+605cuVQdCA==", null, false, "", 0, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("172393a6-4d3c-45a2-a06f-0dc9575cad2b"), new Guid("7fe43f3f-c326-47f1-ae26-2334a2c796b1") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("04846256-7007-4101-8b2f-b879d49026b9"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("7bb5879e-1d26-4078-b1ab-88b933fa19b7"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("7fe43f3f-c326-47f1-ae26-2334a2c796b1"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("172393a6-4d3c-45a2-a06f-0dc9575cad2b"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("172393a6-4d3c-45a2-a06f-0dc9575cad2b"), new Guid("7fe43f3f-c326-47f1-ae26-2334a2c796b1") });

            migrationBuilder.DropColumn(
                name: "Selected",
                table: "ProductImages");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cc12640e-28d5-4e89-b169-1e5eecf729c8"), "6537d1d5-00ad-4a55-9ac0-25b446fadea4", "Top manager", "Admin", "Admin" },
                    { new Guid("b3063e3f-635a-428b-9723-f075ec93ff9a"), "2bb689a6-9f6a-46c3-acab-6c7083a31813", "Staff", "Staff", "Staff" },
                    { new Guid("600ff89a-5b95-441a-aada-5dab1d36522d"), "cb503a29-0778-4c10-84f6-2edab5102366", "Customer", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("57ef887d-b68a-4d69-b82f-7cf1b87cbacf"), 0, null, 0m, null, "978fe55f-9562-44aa-bc6f-4a88d9dc868b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEOCsWIdIL+GrDT14bpWHriVLd9z2zeBDrYrOVG+h2KDPXbAfjKIiJsVoDGUcgSL5gA==", null, false, "", 0, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("57ef887d-b68a-4d69-b82f-7cf1b87cbacf"), new Guid("cc12640e-28d5-4e89-b169-1e5eecf729c8") });
        }
    }
}
