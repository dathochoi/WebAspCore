using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCore.Data.Migrations
{
    public partial class addsystems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Systems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    PhongNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    IconLogo = table.Column<string>(maxLength: 255, nullable: false),
                    ImageCover = table.Column<string>(maxLength: 255, nullable: false),
                    Lat = table.Column<float>(nullable: false),
                    Lng = table.Column<float>(nullable: false),
                    LinkFaceBook = table.Column<string>(nullable: false),
                    LinkInstargram = table.Column<string>(nullable: true),
                    Descaription = table.Column<string>(maxLength: 255, nullable: false),
                    NameWebsite = table.Column<string>(maxLength: 255, nullable: false),
                    Node = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Systems", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Systems");

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
    }
}
