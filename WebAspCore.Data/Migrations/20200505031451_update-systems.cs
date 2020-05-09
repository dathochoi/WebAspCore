using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCore.Data.Migrations
{
    public partial class updatesystems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("af3db7ba-c472-48a1-82bd-1a491e7a03ff"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("b0010a0f-c60a-496b-81f6-b7adefe6b35e"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("e5022ae8-b308-4e26-8b60-3189bd021964"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("a3920a37-76fd-4fa3-8fad-2521a75d72a4"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("a3920a37-76fd-4fa3-8fad-2521a75d72a4"), new Guid("af3db7ba-c472-48a1-82bd-1a491e7a03ff") });

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Systems",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2432afe2-ce2f-4150-878a-0d5011ca70ac"), "7d3a37f4-f5bb-4d71-8063-b633076438b6", "Top manager", "Admin", "Admin" },
                    { new Guid("e008f73a-a127-49ed-b67c-fd732f9d7339"), "bb020442-7be4-4ead-9808-03cfd8de325f", "Staff", "Staff", "Staff" },
                    { new Guid("870368ce-f0f9-48ed-b707-8ee73c1689f9"), "ffe1cb41-d628-4f90-a14a-91045ef11acb", "Customer", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("60526190-7469-4268-93d7-9a0c28be86ce"), 0, null, 0m, null, "f5017367-91af-4d02-9932-a45913f5b49b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEFMO7ZyBOPAfV7zPDLTiAIQgLVIy5s5a2s6ohAuCGctYQ5v4fUvZKtkEw4XJoN9GkA==", null, false, "", 0, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("60526190-7469-4268-93d7-9a0c28be86ce"), new Guid("2432afe2-ce2f-4150-878a-0d5011ca70ac") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("2432afe2-ce2f-4150-878a-0d5011ca70ac"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("870368ce-f0f9-48ed-b707-8ee73c1689f9"));

            migrationBuilder.DeleteData(
                table: "AppRole",
                keyColumn: "Id",
                keyValue: new Guid("e008f73a-a127-49ed-b67c-fd732f9d7339"));

            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: new Guid("60526190-7469-4268-93d7-9a0c28be86ce"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("60526190-7469-4268-93d7-9a0c28be86ce"), new Guid("2432afe2-ce2f-4150-878a-0d5011ca70ac") });

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Systems");

            migrationBuilder.InsertData(
                table: "AppRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("af3db7ba-c472-48a1-82bd-1a491e7a03ff"), "d2dab739-ead8-4178-a3ef-30b75821d05e", "Top manager", "Admin", "Admin" },
                    { new Guid("b0010a0f-c60a-496b-81f6-b7adefe6b35e"), "d69f73fa-771c-4c34-84d7-f114cd71c7fd", "Staff", "Staff", "Staff" },
                    { new Guid("e5022ae8-b308-4e26-8b60-3189bd021964"), "385089bc-66c5-4b83-bce1-3fd7254eda96", "Customer", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "Balance", "BirthDay", "ConcurrencyStamp", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a3920a37-76fd-4fa3-8fad-2521a75d72a4"), 0, null, 0m, null, "60bb46f6-03fc-49a3-88c4-b7b72af89aea", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dan@gmail.com", true, null, false, null, "dandan@gmail.com", "admin", "AQAAAAEAACcQAAAAEHl3W88V81Kfp+o6bUm8b4OXc0hzeK6v+AoMj2Hat9fvyLkFcRX4GtbtOSjB8HY+TA==", null, false, "", 0, false, "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("a3920a37-76fd-4fa3-8fad-2521a75d72a4"), new Guid("af3db7ba-c472-48a1-82bd-1a491e7a03ff") });
        }
    }
}
