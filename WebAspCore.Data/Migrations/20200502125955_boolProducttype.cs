using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCore.Data.Migrations
{
    public partial class boolProducttype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "ProductTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6d1c2577-c5ad-4322-9136-e75f6ee785e8"), "f0f71935-8438-4c21-917d-0937ed94752b", "Top manager", "Admin", "Admin" },
                    { new Guid("6de04860-375f-48b5-af9d-971d5835bf89"), "7dd7307c-2d3b-478e-8b36-ae023c3877a1", "Staff", "Staff", "Staff" },
                    { new Guid("a17e93ac-9ef8-4401-80c8-3a9a21070b66"), "ae8f6d1c-bbd6-413b-be8a-09ee9b8a3b49", "Customer", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("f7563a99-14a2-4437-b6a9-89b285ba84f0"), 0, null, 0m, null, "5c3432fc-4264-4849-b1eb-89503b05bd7c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAECUqVXKrgISEQQRJCc2a7vqkkNsEUHj7DYJkzTIKRT967XXv53cW1b8miuSTljafyA==", null, false, "", 0, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("f7563a99-14a2-4437-b6a9-89b285ba84f0"), new Guid("6d1c2577-c5ad-4322-9136-e75f6ee785e8") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6d1c2577-c5ad-4322-9136-e75f6ee785e8"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("6de04860-375f-48b5-af9d-971d5835bf89"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("a17e93ac-9ef8-4401-80c8-3a9a21070b66"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("f7563a99-14a2-4437-b6a9-89b285ba84f0"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("f7563a99-14a2-4437-b6a9-89b285ba84f0"), new Guid("6d1c2577-c5ad-4322-9136-e75f6ee785e8") });

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ProductTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool));

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
    }
}
