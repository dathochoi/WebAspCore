using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAspCore.Data.Migrations
{
    public partial class initseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AdvertistmentPages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "home", "Trang chủ" },
                    { "product-cate", "Danh mục sản phẩm" },
                    { "product-detail", "Chi tiết sản phẩm" }
                });

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

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 3, "#ff0000", "Đỏ" },
                    { 4, "#1000ff", "Xanh" },
                    { 1, "#000000", "Đen" },
                    { 2, "#FFFFFF", "Trắng" }
                });

            migrationBuilder.InsertData(
                table: "Functions",
                columns: new[] { "Id", "IconCss", "Name", "ParentId", "SortOrder", "Status", "URL" },
                values: new object[,]
                {
                    { "UTILITY", "fa-clone", "Tiện ích", null, 4, 1, "/" },
                    { "READER", "fa-bar-chart-o", "Báo cáo độc giả", "REPORT", 3, 1, "/admin/report/reader" },
                    { "ACCESS", "fa-bar-chart-o", "Báo cáo truy cập", "REPORT", 2, 1, "/admin/report/visitor" },
                    { "REVENUES", "fa-bar-chart-o", "Báo cáo doanh thu", "REPORT", 1, 1, "/admin/report/revenues" },
                    { "REPORT", "fa-bar-chart-o", "Báo cáo", null, 5, 1, "/" },
                    { "SLIDE", "fa-clone", "Slide", "UTILITY", 5, 1, "/admin/slide/index" },
                    { "CONTACT", "fa-clone", "Liên hệ", "UTILITY", 4, 1, "/admin/contact/index" },
                    { "ANNOUNCEMENT", "fa-clone", "Thông báo", "UTILITY", 3, 1, "/admin/announcement/index" },
                    { "FEEDBACK", "fa-clone", "Phản hồi", "UTILITY", 2, 1, "/admin/feedback/index" },
                    { "FOOTER", "fa-clone", "Footer", "UTILITY", 1, 1, "/admin/footer/index" },
                    { "BLOG", "fa-table", "Bài viết", "CONTENT", 1, 1, "/admin/blog/index" },
                    { "ADVERTISMENT", "fa-clone", "Quảng cáo", "UTILITY", 6, 1, "/admin/advertistment/index" },
                    { "BILL", "fa-chevron-down", "Hóa đơn", "PRODUCT", 3, 1, "/admin/bill/index" },
                    { "SYSTEM", "fa-desktop", "Hệ thống", null, 1, 1, "/" },
                    { "ROLE", "fa-home", "Nhóm", "SYSTEM", 1, 1, "/admin/role/index" },
                    { "FUNCTION", "fa-home", "Chức năng", "SYSTEM", 2, 1, "/admin/function/index" },
                    { "ACTIVITY", "fa-home", "Nhật ký", "SYSTEM", 4, 1, "/admin/activity/index" },
                    { "USER", "fa-home", "Người dùng", "SYSTEM", 3, 1, "/admin/user/index" },
                    { "SETTING", "fa-home", "Cấu hình", "SYSTEM", 6, 1, "/admin/setting/index" },
                    { "PRODUCT", "fa-chevron-down", "Sản phẩm", null, 2, 1, "/" },
                    { "PRODUCT_CATEGORY", "fa-chevron-down", "Danh mục", "PRODUCT", 1, 1, "/admin/productcategory/index" },
                    { "PRODUCT_LIST", "fa-chevron-down", "Sản phẩm", "PRODUCT", 2, 1, "/admin/product/index" },
                    { "ERROR", "fa-home", "Lỗi", "SYSTEM", 5, 1, "/admin/error/index" },
                    { "CONTENT", "fa-table", "Nội dung", null, 3, 1, "/" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "DateCreated", "DateModified", "Description", "HomeFlag", "HomeOrder", "Image", "Name", "ParentId", "SeoAlias", "SeoDescription", "SeoKeywords", "SeoPageTitle", "SortOrder", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Áo nam", null, "ao-nam", null, null, null, 1, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Áo nữ", null, "ao-nu", null, null, null, 2, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Giày nam", null, "giay-nam", null, null, null, 3, 1 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, null, "Giày nữ", null, "giay-nu", null, null, null, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "XS" },
                    { 5, "S" },
                    { 4, "M" },
                    { 2, "XL" },
                    { 1, "XXL" },
                    { 3, "L" }
                });

            migrationBuilder.InsertData(
                table: "Slides",
                columns: new[] { "Id", "Content", "Description", "DisplayOrder", "GroupAlias", "Image", "Name", "Status", "Url" },
                values: new object[,]
                {
                    { 14, null, null, 11, "brand", "/client-side/images/brand11.png", "Slide 11", true, "#" },
                    { 13, null, null, 10, "brand", "/client-side/images/brand10.png", "Slide 10", true, "#" },
                    { 12, null, null, 9, "brand", "/client-side/images/brand9.png", "Slide 9", true, "#" },
                    { 11, null, null, 8, "brand", "/client-side/images/brand8.png", "Slide 8", true, "#" },
                    { 10, null, null, 7, "brand", "/client-side/images/brand7.png", "Slide 7", true, "#" },
                    { 9, null, null, 6, "brand", "/client-side/images/brand6.png", "Slide 6", true, "#" },
                    { 8, null, null, 5, "brand", "/client-side/images/brand5.png", "Slide 5", true, "#" },
                    { 7, null, null, 4, "brand", "/client-side/images/brand4.png", "Slide 4", true, "#" },
                    { 5, null, null, 2, "brand", "/client-side/images/brand2.png", "Slide 2", true, "#" },
                    { 4, null, null, 1, "brand", "/client-side/images/brand1.png", "Slide 1", true, "#" },
                    { 3, null, null, 2, "top", "/client-side/images/slider/slide-3.jpg", "Slide 3", true, "#" },
                    { 2, null, null, 1, "top", "/client-side/images/slider/slide-2.jpg", "Slide 2", true, "#" },
                    { 1, null, null, 0, "top", "/client-side/images/slider/slide-1.jpg", "Slide 1", true, "#" },
                    { 6, null, null, 3, "brand", "/client-side/images/brand3.png", "Slide 3", true, "#" }
                });

            migrationBuilder.InsertData(
                table: "SystemConfigs",
                columns: new[] { "Id", "Name", "Status", "Value1", "Value2", "Value3", "Value4", "Value5" },
                values: new object[,]
                {
                    { "HomeMetaKeyword", "Từ khoá trang chủ", 1, "Trang chủ TeduShop", null, null, null, null },
                    { "HomeTitle", "Tiêu đề trang chủ", 1, "Trang chủ TeduShop", null, null, null, null },
                    { "HomeMetaDescription", "Mô tả trang chủ", 1, "Trang chủ TeduShop", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "AdvertistmentPositions",
                columns: new[] { "Id", "Name", "PageId" },
                values: new object[,]
                {
                    { "home-left", "Bên trái", "home" },
                    { "product-cate-left", "Bên trái", "product-cate" },
                    { "product-detail-left", "Bên trái", "product-detail" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Content", "DateCreated", "DateModified", "Description", "HomeFlag", "HotFlag", "Image", "Name", "OriginalPrice", "Price", "PromotionPrice", "SeoAlias", "SeoDescription", "SeoKeywords", "SeoPageTitle", "Status", "Tags", "Unit", "ViewCount" },
                values: new object[,]
                {
                    { 13, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 18", 1000m, 1000m, null, "san-pham-18", null, null, null, 1, null, null, null },
                    { 12, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 17", 1000m, 1000m, null, "san-pham-17", null, null, null, 1, null, null, null },
                    { 11, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 16", 1000m, 1000m, null, "san-pham-16", null, null, null, 1, null, null, null },
                    { 10, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 15", 1000m, 1000m, null, "san-pham-15", null, null, null, 1, null, null, null },
                    { 9, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 14", 1000m, 1000m, null, "san-pham-14", null, null, null, 1, null, null, null },
                    { 8, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 13", 1000m, 1000m, null, "san-pham-13", null, null, null, 1, null, null, null },
                    { 7, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 12", 1000m, 1000m, null, "san-pham-12", null, null, null, 1, null, null, null },
                    { 6, 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 11", 1000m, 1000m, null, "san-pham-11", null, null, null, 1, null, null, null },
                    { 5, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 10", 1000m, 1000m, null, "san-pham-10", null, null, null, 1, null, null, null },
                    { 4, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 9", 1000m, 1000m, null, "san-pham-9", null, null, null, 1, null, null, null },
                    { 3, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 8", 1000m, 1000m, null, "san-pham-8", null, null, null, 1, null, null, null },
                    { 2, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 7", 1000m, 1000m, null, "san-pham-7", null, null, null, 1, null, null, null },
                    { 1, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 6", 1000m, 1000m, null, "san-pham-6", null, null, null, 1, null, null, null },
                    { 20, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 5", 1000m, 1000m, null, "san-pham-5", null, null, null, 1, null, null, null },
                    { 19, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 4", 1000m, 1000m, null, "san-pham-4", null, null, null, 1, null, null, null },
                    { 18, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 3", 1000m, 1000m, null, "san-pham-3", null, null, null, 1, null, null, null },
                    { 17, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 2", 1000m, 1000m, null, "san-pham-2", null, null, null, 1, null, null, null },
                    { 16, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 1", 1000m, 1000m, null, "san-pham-1", null, null, null, 1, null, null, null },
                    { 14, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 19", 1000m, 1000m, null, "san-pham-19", null, null, null, 1, null, null, null },
                    { 15, 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "/client-side/images/products/product-1.jpg", "Sản phẩm 20", 1000m, 1000m, null, "san-pham-20", null, null, null, 1, null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdvertistmentPositions",
                keyColumn: "Id",
                keyValue: "home-left");

            migrationBuilder.DeleteData(
                table: "AdvertistmentPositions",
                keyColumn: "Id",
                keyValue: "product-cate-left");

            migrationBuilder.DeleteData(
                table: "AdvertistmentPositions",
                keyColumn: "Id",
                keyValue: "product-detail-left");

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

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "ACCESS");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "ACTIVITY");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "ADVERTISMENT");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "ANNOUNCEMENT");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "BILL");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "BLOG");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "CONTACT");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "CONTENT");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "ERROR");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "FEEDBACK");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "FOOTER");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "FUNCTION");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "PRODUCT");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "PRODUCT_CATEGORY");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "PRODUCT_LIST");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "READER");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "REPORT");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "REVENUES");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "ROLE");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "SETTING");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "SLIDE");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "SYSTEM");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "USER");

            migrationBuilder.DeleteData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "UTILITY");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Slides",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: "HomeMetaDescription");

            migrationBuilder.DeleteData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: "HomeMetaKeyword");

            migrationBuilder.DeleteData(
                table: "SystemConfigs",
                keyColumn: "Id",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "AdvertistmentPages",
                keyColumn: "Id",
                keyValue: "home");

            migrationBuilder.DeleteData(
                table: "AdvertistmentPages",
                keyColumn: "Id",
                keyValue: "product-cate");

            migrationBuilder.DeleteData(
                table: "AdvertistmentPages",
                keyColumn: "Id",
                keyValue: "product-detail");

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
