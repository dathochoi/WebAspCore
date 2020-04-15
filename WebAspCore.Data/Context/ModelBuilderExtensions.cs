
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAspCore.Data.Entities;
using WebAspCore.Data.Enums;

namespace WebAspCore.Data.Context
{
    public  static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleId1 = Guid.NewGuid();
            var roleId2 = Guid.NewGuid();
            var roleId3 = Guid.NewGuid();
            var adminId = Guid.NewGuid();
            modelBuilder.Entity<AppRole>().HasData(
                 new AppRole()
                 {
                     Id = roleId1,
                     Name = "Admin",
                     NormalizedName = "Admin",
                     Description = "Top manager"
                 },
                 new AppRole()
                 {
                     Id = roleId2,
                     Name = "Staff",
                     NormalizedName = "Staff",
                     Description = "Staff"
                 },
                 new AppRole()
                 {
                     Id = roleId3,
                     Name = "Customer",
                     NormalizedName = "Customer",
                     Description = "Customer"
                 }
            );
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                  new AppUser()
                  {
                        Id = adminId,
                        UserName = "admin",
                        NormalizedUserName = "admin",
                        Email = "dan@gmail.com",
                        NormalizedEmail = "dandan@gmail.com",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "12345"),
                        SecurityStamp = string.Empty,
                  }
                );
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId1,
                UserId = adminId
            });

            modelBuilder.Entity<Function>().HasData(
                new Function() { Id = "SYSTEM", Name = "Hệ thống", ParentId = null, SortOrder = 1, Status = Status.Active, URL = "/", IconCss = "fa-desktop" },
                    new Function() { Id = "ROLE", Name = "Nhóm", ParentId = "SYSTEM", SortOrder = 1, Status = Status.Active, URL = "/admin/role/index", IconCss = "fa-home" },
                    new Function() { Id = "FUNCTION", Name = "Chức năng", ParentId = "SYSTEM", SortOrder = 2, Status = Status.Active, URL = "/admin/function/index", IconCss = "fa-home" },
                    new Function() { Id = "USER", Name = "Người dùng", ParentId = "SYSTEM", SortOrder = 3, Status = Status.Active, URL = "/admin/user/index", IconCss = "fa-home" },
                    new Function() { Id = "ACTIVITY", Name = "Nhật ký", ParentId = "SYSTEM", SortOrder = 4, Status = Status.Active, URL = "/admin/activity/index", IconCss = "fa-home" },
                    new Function() { Id = "ERROR", Name = "Lỗi", ParentId = "SYSTEM", SortOrder = 5, Status = Status.Active, URL = "/admin/error/index", IconCss = "fa-home" },
                    new Function() { Id = "SETTING", Name = "Cấu hình", ParentId = "SYSTEM", SortOrder = 6, Status = Status.Active, URL = "/admin/setting/index", IconCss = "fa-home" },
                    new Function() { Id = "PRODUCT", Name = "Sản phẩm", ParentId = null, SortOrder = 2, Status = Status.Active, URL = "/", IconCss = "fa-chevron-down" },
                    new Function() { Id = "PRODUCT_CATEGORY", Name = "Danh mục", ParentId = "PRODUCT", SortOrder = 1, Status = Status.Active, URL = "/admin/productcategory/index", IconCss = "fa-chevron-down" },
                    new Function() { Id = "PRODUCT_LIST", Name = "Sản phẩm", ParentId = "PRODUCT", SortOrder = 2, Status = Status.Active, URL = "/admin/product/index", IconCss = "fa-chevron-down" },
                    new Function() { Id = "BILL", Name = "Hóa đơn", ParentId = "PRODUCT", SortOrder = 3, Status = Status.Active, URL = "/admin/bill/index", IconCss = "fa-chevron-down" },
                    new Function() { Id = "CONTENT", Name = "Nội dung", ParentId = null, SortOrder = 3, Status = Status.Active, URL = "/", IconCss = "fa-table" },
                    new Function() { Id = "BLOG", Name = "Bài viết", ParentId = "CONTENT", SortOrder = 1, Status = Status.Active, URL = "/admin/blog/index", IconCss = "fa-table" },
                    new Function() { Id = "UTILITY", Name = "Tiện ích", ParentId = null, SortOrder = 4, Status = Status.Active, URL = "/", IconCss = "fa-clone" },
                    new Function() { Id = "FOOTER", Name = "Footer", ParentId = "UTILITY", SortOrder = 1, Status = Status.Active, URL = "/admin/footer/index", IconCss = "fa-clone" },
                    new Function() { Id = "FEEDBACK", Name = "Phản hồi", ParentId = "UTILITY", SortOrder = 2, Status = Status.Active, URL = "/admin/feedback/index", IconCss = "fa-clone" },
                    new Function() { Id = "ANNOUNCEMENT", Name = "Thông báo", ParentId = "UTILITY", SortOrder = 3, Status = Status.Active, URL = "/admin/announcement/index", IconCss = "fa-clone" },
                    new Function() { Id = "CONTACT", Name = "Liên hệ", ParentId = "UTILITY", SortOrder = 4, Status = Status.Active, URL = "/admin/contact/index", IconCss = "fa-clone" },
                    new Function() { Id = "SLIDE", Name = "Slide", ParentId = "UTILITY", SortOrder = 5, Status = Status.Active, URL = "/admin/slide/index", IconCss = "fa-clone" },
                    new Function() { Id = "ADVERTISMENT", Name = "Quảng cáo", ParentId = "UTILITY", SortOrder = 6, Status = Status.Active, URL = "/admin/advertistment/index", IconCss = "fa-clone" },

                    new Function() { Id = "REPORT", Name = "Báo cáo", ParentId = null, SortOrder = 5, Status = Status.Active, URL = "/", IconCss = "fa-bar-chart-o" },
                    new Function() { Id = "REVENUES", Name = "Báo cáo doanh thu", ParentId = "REPORT", SortOrder = 1, Status = Status.Active, URL = "/admin/report/revenues", IconCss = "fa-bar-chart-o" },
                    new Function() { Id = "ACCESS", Name = "Báo cáo truy cập", ParentId = "REPORT", SortOrder = 2, Status = Status.Active, URL = "/admin/report/visitor", IconCss = "fa-bar-chart-o" },
                    new Function() { Id = "READER", Name = "Báo cáo độc giả", ParentId = "REPORT", SortOrder = 3, Status = Status.Active, URL = "/admin/report/reader", IconCss = "fa-bar-chart-o" }
                );

            modelBuilder.Entity<Color>().HasData(
                    new Color() { Id = 1, Name = "Đen", Code = "#000000" },
                    new Color() { Id = 2, Name = "Trắng", Code = "#FFFFFF" },
                    new Color() { Id = 3, Name = "Đỏ", Code = "#ff0000" },
                    new Color() { Id = 4, Name = "Xanh", Code = "#1000ff" }
                );

            modelBuilder.Entity<AdvertistmentPage>().HasData(
                new AdvertistmentPage()
                {
                    Id = "home",
                    Name = "Trang chủ"
                },
                new AdvertistmentPage()
                {
                    Id = "product-cate",
                    Name = "Danh mục sản phẩm"
                },
                new AdvertistmentPage()
                {
                    Id = "product-detail",
                    Name = "Chi tiết sản phẩm"
                  
                }
             );
            modelBuilder.Entity<AdvertistmentPosition>().HasData(
                     new AdvertistmentPosition() { Id = "product-detail-left", Name = "Bên trái", PageId = "product-detail" },
                     new AdvertistmentPosition() { Id = "product-cate-left", Name = "Bên trái", PageId = "product-cate" },
                     new AdvertistmentPosition() { Id = "home-left", Name = "Bên trái", PageId = "home" }
                );
           
            modelBuilder.Entity<Slide>().HasData(
                    new Slide() { Id = 1, Name = "Slide 1", Image = "/client-side/images/slider/slide-1.jpg", Url = "#", DisplayOrder = 0, GroupAlias = "top", Status = true },
                    new Slide() { Id = 2, Name = "Slide 2", Image = "/client-side/images/slider/slide-2.jpg", Url = "#", DisplayOrder = 1, GroupAlias = "top", Status = true },
                    new Slide() { Id = 3, Name = "Slide 3", Image = "/client-side/images/slider/slide-3.jpg", Url = "#", DisplayOrder = 2, GroupAlias = "top", Status = true },

                    new Slide() { Id = 4, Name = "Slide 1", Image = "/client-side/images/brand1.png", Url = "#", DisplayOrder = 1, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 5, Name = "Slide 2", Image = "/client-side/images/brand2.png", Url = "#", DisplayOrder = 2, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 6, Name = "Slide 3", Image = "/client-side/images/brand3.png", Url = "#", DisplayOrder = 3, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 7, Name = "Slide 4", Image = "/client-side/images/brand4.png", Url = "#", DisplayOrder = 4, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 8, Name = "Slide 5", Image = "/client-side/images/brand5.png", Url = "#", DisplayOrder = 5, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 9, Name = "Slide 6", Image = "/client-side/images/brand6.png", Url = "#", DisplayOrder = 6, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 10, Name = "Slide 7", Image = "/client-side/images/brand7.png", Url = "#", DisplayOrder = 7, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 11, Name = "Slide 8", Image = "/client-side/images/brand8.png", Url = "#", DisplayOrder = 8, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 12, Name = "Slide 9", Image = "/client-side/images/brand9.png", Url = "#", DisplayOrder = 9, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 13, Name = "Slide 10", Image = "/client-side/images/brand10.png", Url = "#", DisplayOrder = 10, GroupAlias = "brand", Status = true },
                    new Slide() { Id = 14, Name = "Slide 11", Image = "/client-side/images/brand11.png", Url = "#", DisplayOrder = 11, GroupAlias = "brand", Status = true }
            );

            modelBuilder.Entity<Size>().HasData(
                    new Size() { Id = 1, Name = "XXL" },
                    new Size() { Id = 2, Name = "XL" },
                    new Size() { Id = 3, Name = "L" },
                    new Size() { Id = 4, Name = "M" },
                    new Size() { Id = 5, Name = "S" },
                    new Size() { Id = 6, Name = "XS" }
                );
            modelBuilder.Entity<ProductCategory>().HasData(
                    new ProductCategory()
                    {
                        Id = 1,
                        Name = "Áo nam",
                        SeoAlias = "ao-nam",
                        ParentId = null,
                        Status = Status.Active,
                        SortOrder = 1
                    },
                    new ProductCategory()
                    {
                        Id = 2,
                        Name = "Áo nữ",
                        SeoAlias = "ao-nu",
                        ParentId = null,
                        Status = Status.Active,
                        SortOrder = 2
                    },
                    new ProductCategory()
                    {
                        Id = 3,
                        Name = "Giày nam",
                        SeoAlias = "giay-nam",
                        ParentId = null,
                        Status = Status.Active,
                        SortOrder = 3
                    },
                    new ProductCategory()
                    {
                        Id = 4,
                        Name = "Giày nữ",
                        SeoAlias = "giay-nu",
                        ParentId = null,
                        Status = Status.Active,
                        SortOrder = 4
                    }
                );
            modelBuilder.Entity<Product>().HasData(
                    new Product() { Id = 1, CategoryId = 2, Name = "Sản phẩm 6", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-6", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 2, CategoryId = 2, Name = "Sản phẩm 7", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-7", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 3, CategoryId = 2, Name = "Sản phẩm 8", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-8", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 4, CategoryId = 2, Name = "Sản phẩm 9", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-9", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 5, CategoryId = 2, Name = "Sản phẩm 10", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-10", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },

                    new Product() { Id = 6, CategoryId = 3, Name = "Sản phẩm 11", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-11", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 7, CategoryId = 3, Name = "Sản phẩm 12", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-12", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 8, CategoryId = 3, Name = "Sản phẩm 13", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-13", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 9, CategoryId = 3, Name = "Sản phẩm 14", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-14", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 10, CategoryId = 3, Name = "Sản phẩm 15", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-15", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },

                    new Product() { Id = 11, CategoryId = 4, Name = "Sản phẩm 16", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-16", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 12, CategoryId = 4, Name = "Sản phẩm 17", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-17", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 13, CategoryId = 4, Name = "Sản phẩm 18", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-18", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 14, CategoryId = 4, Name = "Sản phẩm 19", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-19", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 15, CategoryId = 4, Name = "Sản phẩm 20", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-20", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },

                    new Product() { Id = 16, CategoryId = 1, Name = "Sản phẩm 1", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-1", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 17, CategoryId = 1, Name = "Sản phẩm 2", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-2", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 18, CategoryId = 1, Name = "Sản phẩm 3", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-3", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 19, CategoryId = 1, Name = "Sản phẩm 4", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-4", Price = 1000, Status = Status.Active, OriginalPrice = 1000 },
                    new Product() { Id = 20, CategoryId = 1, Name = "Sản phẩm 5", Image = "/client-side/images/products/product-1.jpg", SeoAlias = "san-pham-5", Price = 1000, Status = Status.Active, OriginalPrice = 1000 }
               );
            modelBuilder.Entity<SystemConfig>().HasData(
                new SystemConfig()
                {
                    Id = "HomeTitle",
                    Name = "Tiêu đề trang chủ",
                    Value1 = "Trang chủ TeduShop",
                    Status = Status.Active
                },
                new SystemConfig()
                {
                    Id = "HomeMetaKeyword",
                    Name = "Từ khoá trang chủ",
                    Value1 = "Trang chủ TeduShop",
                    Status = Status.Active
                },
                new SystemConfig()
                {
                    Id = "HomeMetaDescription",
                    Name = "Mô tả trang chủ",
                    Value1 = "Trang chủ TeduShop",
                    Status = Status.Active
                });
        }
    }
}
