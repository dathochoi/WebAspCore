using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCore.Data.Migrations
{
    public partial class system : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("9bb94322-9a76-4e42-940a-729c801835ae"), "c79e2e00-bb96-4754-a7e9-af570c7d4d26", "Top manager", "Admin", "Admin" },
                    { new Guid("563d78c7-ce49-46cf-8351-086901ce2163"), "85560daa-c4c6-4a5c-8537-3e635cc6bdc0", "Staff", "Staff", "Staff" },
                    { new Guid("d0930b5c-19e6-4982-90df-66c4a6fd2584"), "cee50a77-7e40-498b-ae58-8f94046cdd3f", "Customer", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7fe7fa95-6618-4af6-a900-a5afcb03cf5f"), 0, null, 0m, null, "5f3b41b5-456a-4398-8b5c-163dfc5feb9a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEMJlZvv0o2lEOUNa2HJ1+IlliP3lKaDt27ej43h44DlxX/fNXCtcbs2TeoWu7xWwrw==", null, false, "", 0, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("7fe7fa95-6618-4af6-a900-a5afcb03cf5f"), new Guid("9bb94322-9a76-4e42-940a-729c801835ae") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("563d78c7-ce49-46cf-8351-086901ce2163"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("9bb94322-9a76-4e42-940a-729c801835ae"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("d0930b5c-19e6-4982-90df-66c4a6fd2584"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("7fe7fa95-6618-4af6-a900-a5afcb03cf5f"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("7fe7fa95-6618-4af6-a900-a5afcb03cf5f"), new Guid("9bb94322-9a76-4e42-940a-729c801835ae") });

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
    }
}
