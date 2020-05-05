using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCore.Data.Migrations
{
    public partial class admakein : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "MakeInId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MakeIns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeIns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_ProductId",
                table: "ProductTypes",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MakeIns");

            migrationBuilder.DropTable(
                name: "ProductTypes");

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

            migrationBuilder.DropColumn(
                name: "MakeInId",
                table: "Products");

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
    }
}
