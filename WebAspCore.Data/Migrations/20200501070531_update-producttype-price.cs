using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCore.Data.Migrations
{
    public partial class updateproducttypeprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "OriginPrice",
                table: "ProductTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SalePrice",
                table: "ProductTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("57639d76-b14b-4eef-9081-82788cec4094"), "32d9227b-0fd9-4863-9481-d0c1765e6fb1", "Top manager", "Admin", "Admin" },
                    { new Guid("24590a78-c0cf-4dfd-a55e-b32af1c05561"), "00766d2e-036e-4988-9942-c0a36f6220b3", "Staff", "Staff", "Staff" },
                    { new Guid("2138c3e9-a4c3-47ac-af82-07e4494c824b"), "cb71974e-7c65-4b28-84d2-d2d64b7efb78", "Customer", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ef166949-88ec-447a-b039-8ec6b3c07a30"), 0, null, 0m, null, "59379dfb-c32a-4d16-a350-469844936ad8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEAUYC/6z5ZhIZWmtHh44kl7EzJvIU+6Aaos9lfY5kUWIky7T1vD7cR8tEP/JFDo2+g==", null, false, "", 0, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("ef166949-88ec-447a-b039-8ec6b3c07a30"), new Guid("57639d76-b14b-4eef-9081-82788cec4094") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("2138c3e9-a4c3-47ac-af82-07e4494c824b"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("24590a78-c0cf-4dfd-a55e-b32af1c05561"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("57639d76-b14b-4eef-9081-82788cec4094"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("ef166949-88ec-447a-b039-8ec6b3c07a30"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("ef166949-88ec-447a-b039-8ec6b3c07a30"), new Guid("57639d76-b14b-4eef-9081-82788cec4094") });

            migrationBuilder.DropColumn(
                name: "OriginPrice",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "ProductTypes");

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
    }
}
