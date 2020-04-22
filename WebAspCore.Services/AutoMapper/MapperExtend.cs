using System;
using System.Collections.Generic;
using System.Text;
using WebAspCore.Data.Entities;
using WebAspCore.Utilities.Helpers;
using WebAspCore.ViewModel.ViewModels;

namespace WebAspCore.Services.AutoMapper
{
    public static class MapperExtend
    {
        public static ProductViewModel ProductToVM(Product product)
        {
            ProductViewModel vm = new ProductViewModel();
            vm.Id = product.Id;
            vm.Name = product.Name;
            vm.CategoryId = product.CategoryId;

            vm.Image = product.Image;
            vm.Price = product.Price;

            vm.PromotionPrice = product.PromotionPrice;
            vm.OriginalPrice = product.OriginalPrice;

            vm.Description = product.Description;
            vm.Content = product.Content;
            vm.HomeFlag = product.HomeFlag;
            vm.HotFlag = product.HotFlag;
            vm.ViewCount = product.ViewCount;
            vm.Tags = product.Tags;
            vm.Unit = product.Unit;
           
            if (product.ProductCategory !=null)
            {
                vm.ProductCategory = MapperExtend.ProductCategoryToVM(product.ProductCategory);
            }
            

            vm.SeoPageTitle = product.SeoPageTitle;
            vm.SeoAlias = TextHelper.ToUnsignString(product.SeoAlias);
            vm.SeoKeywords = product.SeoKeywords;

            vm.SeoDescription = product.SeoDescription;
            vm.DateCreated = product.DateCreated;
            vm.DateModified = product.DateCreated;
            vm.Status = product.Status;

            return vm;
        }

        public static Product VMToProduct(ProductViewModel product)
        {
            Product vm = new Product();
            vm.Id = product.Id;
            vm.Name = product.Name;
            vm.CategoryId = product.CategoryId;

            vm.Image = product.Image;
            vm.Price = product.Price;

            vm.PromotionPrice = product.PromotionPrice;
            vm.OriginalPrice = product.OriginalPrice;

            vm.Description = product.Description;
            vm.Content = product.Content;
            vm.HomeFlag = product.HomeFlag;
            vm.HotFlag = product.HotFlag;
            vm.ViewCount = product.ViewCount;
            vm.Tags = product.Tags;
            vm.Unit = product.Unit;

            //vm.ProductCategory = MapperExtend.VMToProductCategory( product.ProductCategory);
            if (product.ProductCategory != null)
            {
                vm.ProductCategory = MapperExtend.VMToProductCategory(product.ProductCategory);
            }

            vm.SeoPageTitle = product.SeoPageTitle;
            vm.SeoAlias = TextHelper.ToUnsignString(product.SeoAlias);
            vm.SeoKeywords = product.SeoKeywords;

            vm.SeoDescription = product.SeoDescription;
            vm.DateCreated = product.DateCreated;
            vm.DateModified = product.DateCreated;
            vm.Status = product.Status;

            return vm;
        }

        public static ProductCategoryViewModel ProductCategoryToVM(ProductCategory productCategory)
        {
            ProductCategoryViewModel vm = new ProductCategoryViewModel();
            vm.Id = productCategory.Id;
            vm.Name = productCategory.Name;

            vm.Description = productCategory.Description;

            vm.ParentId = productCategory.ParentId;

            vm.HomeOrder = productCategory.ParentId;

            vm.Image = productCategory.Image;

            vm.HomeFlag = productCategory.HomeFlag;

            vm.DateCreated = productCategory.DateCreated;
            vm.DateModified = productCategory.DateModified;
            vm.SortOrder = productCategory.SortOrder;
            vm.Status = productCategory.Status;
            vm.SeoPageTitle = productCategory.SeoPageTitle;
            vm.SeoAlias = TextHelper.ToUnsignString(productCategory.SeoAlias);
            vm.SeoKeywords = productCategory.SeoKeywords;
            vm.SeoDescription = productCategory.SeoDescription;
            return vm;

        // ICollection<Product> Products 
        }

        public static ProductCategory VMToProductCategory (ProductCategoryViewModel productCategory)
        {
            ProductCategory vm = new ProductCategory();
            vm.Id = productCategory.Id;
            vm.Name = productCategory.Name;

            vm.Description = productCategory.Description;

            vm.ParentId = productCategory.ParentId;

            vm.HomeOrder = productCategory.ParentId;

            vm.Image = productCategory.Image;

            vm.HomeFlag = productCategory.HomeFlag;

            vm.DateCreated = productCategory.DateCreated;
            vm.DateModified = productCategory.DateModified;
            vm.SortOrder = productCategory.SortOrder;
            vm.Status = productCategory.Status;
            vm.SeoPageTitle = productCategory.SeoPageTitle;
            vm.SeoAlias = TextHelper.ToUnsignString(productCategory.SeoAlias);
            vm.SeoKeywords = productCategory.SeoKeywords;
            vm.SeoDescription = productCategory.SeoDescription;
            return vm;

            // ICollection<Product> Products 
        }
    }
}
