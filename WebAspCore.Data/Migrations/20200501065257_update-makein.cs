using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCore.Data.Migrations
{
    public partial class updatemakein : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("12aa56aa-f0d2-4ef8-951d-cb58d7ec2a30"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("7f2f2d60-b079-4f58-b790-853acdb09f45"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("ef3a5ae7-a6ed-4bcf-9fdc-6b72d05eee80"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("03d46538-bc76-4064-ae23-91251a4775cf"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("03d46538-bc76-4064-ae23-91251a4775cf"), new Guid("ef3a5ae7-a6ed-4bcf-9fdc-6b72d05eee80") });

            migrationBuilder.AddColumn<bool>(
                name: "CheckMenu",
                table: "MakeIns",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("05998ff5-6a75-4c81-aff7-feb41e22050c"), "2d082794-bdcd-4370-93b1-da47357a8e67", "Top manager", "Admin", "Admin" },
                    { new Guid("cde2d03c-a060-4048-aa55-375ced073c63"), "368e7367-da73-478f-a132-75b83743c3ff", "Staff", "Staff", "Staff" },
                    { new Guid("79b9dc4c-d6ed-42ae-9e55-102ac1e6f38a"), "c62562e2-12d8-4379-8376-0a7159078177", "Customer", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a1f4c994-0c8b-4820-aa3c-85a0b2e9d3e9"), 0, null, 0m, null, "1ba3c9d6-3efb-48b1-a813-69fe736dd5c9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAELcSkBPjU6j4tsCVzQKRqgEe9bIcjdkbypspq3EkyUjvBiGXB4hdyPsw94Vxq/cmiA==", null, false, "", 0, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("a1f4c994-0c8b-4820-aa3c-85a0b2e9d3e9"), new Guid("05998ff5-6a75-4c81-aff7-feb41e22050c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("05998ff5-6a75-4c81-aff7-feb41e22050c"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("79b9dc4c-d6ed-42ae-9e55-102ac1e6f38a"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("cde2d03c-a060-4048-aa55-375ced073c63"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a1f4c994-0c8b-4820-aa3c-85a0b2e9d3e9"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("a1f4c994-0c8b-4820-aa3c-85a0b2e9d3e9"), new Guid("05998ff5-6a75-4c81-aff7-feb41e22050c") });

            migrationBuilder.DropColumn(
                name: "CheckMenu",
                table: "MakeIns");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ef3a5ae7-a6ed-4bcf-9fdc-6b72d05eee80"), "65d16bae-c5ec-4f21-92f2-2c3fe0388694", "Top manager", "Admin", "Admin" },
                    { new Guid("12aa56aa-f0d2-4ef8-951d-cb58d7ec2a30"), "2a47e6ed-e6b2-41c7-a3f5-a86d4478117d", "Staff", "Staff", "Staff" },
                    { new Guid("7f2f2d60-b079-4f58-b790-853acdb09f45"), "b3524b36-1d7d-47d8-8d71-7a438062bd9d", "Customer", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("03d46538-bc76-4064-ae23-91251a4775cf"), 0, null, 0m, null, "44b48aad-97bd-4e0c-9ae0-a0080e865e59", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEJXPlFt/FIVsri0vvDgGAmwbXL1jKxJiie9FfWtoq19ZRpHwDfOK0xer+VriKqw3Ag==", null, false, "", 0, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("03d46538-bc76-4064-ae23-91251a4775cf"), new Guid("ef3a5ae7-a6ed-4bcf-9fdc-6b72d05eee80") });
        }
    }
}
