using System;
using System.Collections.Generic;
using System.Text;
using WebAspCore.Data.Entities;
using WebAspCore.Utilities.Helpers;
using WebAspCore.ViewModel.ViewModels;
using WebAspCore.ViewModel.ViewModels.Products;
using WebAspCore.ViewModel.ViewModels.Systems;

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
           
            if (string.IsNullOrEmpty(product.CategoryId.ToString()))
            {
                //var cate  = _co
                vm.ProductCategory = MapperExtend.ProductCategoryToVM(product.ProductCategory);
            }
            //vm.ProductTypeList = new List<ProductTypeViewModel>();
            //if (product.ProductTypes != null)
            //{
            //    foreach (var item in product.ProductTypes)
            //    {
            //        ProductTypeViewModel pT = new ProductTypeViewModel();
            //        pT.Id = item.Id;
            //        pT.Name = item.Name;
            //        pT.OriginPrice = item.OriginPrice;
            //        pT.Price = item.Price;
            //        pT.SalePrice = item.Price;
            //        pT.Status = item.Status;
            //        pT.ProductId = item.ProductId;
            //        vm.ProductTypeList.Add(pT);
            //    }
            //}
            

            vm.SeoPageTitle = product.SeoPageTitle;
            vm.SeoAlias = TextHelper.ToUnsignString(product.SeoAlias);
            vm.SeoKeywords = product.SeoKeywords;

            vm.SeoDescription = product.SeoDescription;
            vm.DateCreated = product.DateCreated;
            vm.DateModified = product.DateCreated;
            vm.Status = product.Status;
            vm.MakeInId = product.MakeInId;
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
            if (string.IsNullOrEmpty(product.CategoryId.ToString()))
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
            vm.MakeInId = product.MakeInId;



            return vm;
        }

        public static ViewModel.ViewModels.Products.ProductCategoryViewModel ProductCategoryToVM(ProductCategory productCategory)
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
        //public static ProductToProductAndImageViewModel()
        //{

        //}

        public static Systems VMToSystems(SystemsViewModel vm)
        {
            Systems s = new Systems();
            s.Id = vm.Id;
            s.Name = vm.Name;
            s.FullName = vm.FullName;
            s.PhongNumber = vm.PhoneNumber;
            s.Address = vm.Address;
            s.IconLogo = vm.IconLogo;
            s.ImageCover = vm.ImageCover;
            s.Lng = vm.Lng;
            s.Lat = vm.Lat;
            s.LinkFaceBook = vm.LinkFaceBook;
            s.LinkInstargram = vm.LinkInstargram;
            s.Descaription = vm.Descaription;
            s.NameWebsite = vm.NameWebsite;
            s.Node = vm.Node;
            s.Email = vm.Email;
            return s;
        }

        public static SystemsViewModel SystemsToVM(Systems vm)
        {
            SystemsViewModel s = new SystemsViewModel();
            s.Id = vm.Id;
            s.Name = vm.Name;
            s.FullName = vm.FullName;
            s.PhoneNumber = vm.PhongNumber;
            s.Address = vm.Address;
            s.IconLogo = vm.IconLogo;
            s.ImageCover = vm.ImageCover;
            s.Lng = vm.Lng;
            s.Lat = vm.Lat;
            s.LinkFaceBook = vm.LinkFaceBook;
            s.LinkInstargram = vm.LinkInstargram;
            s.Descaription = vm.Descaription;
            s.NameWebsite = vm.NameWebsite;
            s.Node = vm.Node;
            s.Email = vm.Email;
            return s;
        }
    }
}
