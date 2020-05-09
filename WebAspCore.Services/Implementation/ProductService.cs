using System.Linq;
using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using WebAspCore.Data.Context;
using WebAspCore.Data.Entities;
using WebAspCore.Services.Interfaces;
using WebAspCore.Utilities.DTOs;
using WebAspCore.ViewModel.ViewModels;
using WebAspCore.Data.Enums;
using WebAspCore.Services.AutoMapper;
using WebAspCore.ViewModel.ViewModels.Products;

namespace WebAspCore.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly WebDbContext _context;
        //private readonly IMapper _mapper;
        public ProductService(WebDbContext context)
        {
            _context = context;
           // _mapper = mapper;
        }
        public ProductViewModel Add(ProductViewModel product)
        {
            ///var p = _mapper.Map<Product>(product);
            ///
            var p = MapperExtend.VMToProduct(product);
            p.ProductTypes = new List<ProductType>();
            foreach ( var item in product.ProductTypeList)
            {
                ProductType pT = new ProductType();
                pT.Name = item.Name;
                pT.OriginPrice = item.OriginPrice;
                pT.Price = item.Price;
                pT.SalePrice = item.SalePrice;
                pT.Status = item.Status;
                p.ProductTypes.Add(pT);
            }       
            p.DateCreated = DateTime.Now;
            
            _context.Products.Add(p);
            _context.SaveChanges();
            return product;

        }

        public void AddImages(int productId, List<ImageCheckViewModel> images)
        {
            _context.ProductImages.RemoveRange(_context.ProductImages.Where(x => x.ProductId == productId).ToList());
            foreach (var image in images)
            {
                _context.ProductImages.Add(new ProductImage()
                {
                    Path = image.Src,
                    ProductId = productId,
                    Caption = string.Empty,
                    Selected = image.Check
                }); 
            }
            _context.SaveChanges();
        }

        public List<ProductImageViewModel> GetImages(int productId)
        {
            var list = _context.ProductImages.Where(x => x.ProductId == productId).ToList();
            List<ProductImageViewModel> listvm = new List<ProductImageViewModel>();
            if (list != null)
            { 
                foreach (var item in list)
                {
                    ProductImageViewModel vm = new ProductImageViewModel();
                    vm.Id = item.Id;
                    vm.ProductId = item.ProductId;
                    vm.Path = item.Path;
                    vm.Caption = item.Caption;
                    vm.Checked = item.Selected;
                   // vm.Product = MapperExtend.ProductToVM(item.Product);
                    listvm.Add(vm);
                }
            }
            return listvm;
        }


              

        public void Delete(int id)
        {
            Product p = _context.Products.Find(id);
            if (p == null)
            {
                throw new Exception("Product isn't exsit");

            }
            var type = _context.ProductTypes.Where(x => x.ProductId ==id).ToList();
            if( type != null)
            {
                _context.ProductTypes.RemoveRange(type);
            }
            _context.Products.Remove(p);
            _context.SaveChanges();
        }

        public List<ProductViewModel> GetAll()
        {
            var listItems = _context.Products.ToList();
            List<ProductViewModel> listVM = new List<ProductViewModel>();
            foreach( var item in listItems)
            {
                ProductViewModel vm = new ProductViewModel();
                //vm = _mapper.Map<ProductViewModel>(item);
                vm = MapperExtend.ProductToVM(item);
                listVM.Add(vm);
            }
            return listVM;
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize, int? makeInId)
        {
            //var query = _context.Products.Find(x => x.Status == Status.Active).ToList();
            var query = _context.Products.Where(x=>x.Status == Status.Active || x.Status == Status.InActive);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            if (makeInId.HasValue)
            {
                query = query.Where(x => x.MakeInId == makeInId);
            }
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }
            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ToList();

            List<ProductViewModel> listProductVM = new List<ProductViewModel>();
            foreach(var item in data)
            {
                //ProductViewModel vm = _mapper.Map<ProductViewModel>(item);
                var vm = MapperExtend.ProductToVM(item);
                if (!string.IsNullOrEmpty(item.CategoryId.ToString()))
                {
                    var p = _context.ProductCategories.Find(item.CategoryId);
                    vm.ProductCategory = MapperExtend.ProductCategoryToVM(p);
                 }
                listProductVM.Add(vm);
            }
            
            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = listProductVM,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public ProductViewModel GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product ==null)
            {
                throw new Exception("Not product in data.");
            }
            //var vm = _mapper.Map<ProductViewModel>(product);
            var vm = MapperExtend.ProductToVM(product);

            vm.ProductTypeList = new List<ProductTypeViewModel>();
            var listType = _context.ProductTypes.Where(x => x.ProductId == product.Id);
            if (listType != null)
            {
                foreach (var item in listType)
                {
                    ProductTypeViewModel pT = new ProductTypeViewModel();
                    pT.Id = item.Id;
                    pT.Name = item.Name;
                    pT.OriginPrice = item.OriginPrice;
                    pT.Price = item.Price;
                    pT.SalePrice = item.SalePrice;
                    pT.Status = item.Status;
                    pT.ProductId = item.ProductId;
                    vm.ProductTypeList.Add(pT);
                }
            }
            return vm;
        }

        //public void Save()
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(ProductViewModel product)
        {
            //var vm = _mapper.Map<Product>(product);
            var vm = MapperExtend.VMToProduct(product);
           // vm.ProductTypes. = product.ProductTypeList;

            vm.DateModified = DateTime.Now;
            var type = _context.ProductTypes.Where(x => x.ProductId == product.Id).ToList();
            if (type != null)
            {
                _context.ProductTypes.RemoveRange(type);
            }

            //vm.ProductTypes = new List<ProductType>();
            foreach (var item in product.ProductTypeList)
            {
                ProductType pT = new ProductType();
                pT.ProductId = product.Id;
                pT.Name = item.Name;
                pT.OriginPrice = item.OriginPrice;
                pT.Price = item.Price;
                pT.SalePrice = item.SalePrice;
                pT.Status = item.Status;
                _context.ProductTypes.Add(pT);
            }

            _context.Products.Update(vm);
            _context.SaveChanges();

        }

        public PagedResult<ProductViewModel> GetAllPagingInHome(int? categoryId, string keyword, int page, int pageSize, bool hotFlag, int? makeInId)
        {
            var query = _context.Products.Where(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            if (makeInId.HasValue && makeInId  >0 )
            {
                query = query.Where(x => x.MakeInId == makeInId);
            }
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }
            if( hotFlag == true)
            {
                query = query.Where(x => x.HotFlag == true);
            }

            //if(saleFlag == true )
            //{
            //    query = query.Where(x=>x.ProductTypes.)
            //}
            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.DateCreated).ThenBy(x =>x.DateModified)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ToList();

            List<ProductViewModel> listProductVM = new List<ProductViewModel>();
            foreach (var item in data)
            {
                //ProductViewModel vm = _mapper.Map<ProductViewModel>(item);
                var vm = MapperExtend.ProductToVM(item);
                var images = _context.ProductImages.Where(x => x.ProductId == item.Id).ToList();
                var MakeIn = _context.MakeIns.Find(item.MakeInId);
                if (MakeIn != null)
                {
                   
                    vm.MakeInName = MakeIn.Name;
                }
                var vPrice = _context.ProductTypes.Where(x => x.ProductId == item.Id).OrderBy(x => x.SalePrice).ThenBy(x => x.Price).FirstOrDefault();
                if(vPrice != null)
                {
                    vm.Price = (decimal)vPrice.SalePrice > 0 ? (decimal)vPrice.SalePrice : (decimal)vPrice.Price;
                }
                
                if (images != null)
                {
                    foreach (var image in images)
                    {
                        if (image.Selected == true)
                        {
                            vm.Image = image.Path + "?w=300&h=350&autorotate=true&format=png&mode=pad";
                            break;
                        }
                        else
                            vm.Image = image.Path + "?w=300&h=350&autorotate=true&format=png&mode=pad";
                    }
                }
                listProductVM.Add(vm);
            }

            

            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = listProductVM,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public ProductViewModel GetDetails(int id)
        {
            ProductViewModel vm = new ProductViewModel();
            vm.ImageList = new List<ImageCheckViewModel>();
            Product product = _context.Products.Find(id);
            if (product != null)
            {
                vm = MapperExtend.ProductToVM(product);
                var images = _context.ProductImages.Where(x => x.ProductId == product.Id).ToList();
                if (images.Count > 0)
                {
                    foreach (var image in images)
                    {
                        ImageCheckViewModel img = new ImageCheckViewModel();
                        img.Id = image.Id;
                        img.Src = image.Path;
                        img.Check = image.Selected;
                        vm.ImageList.Add(img);
                    }
                }
                vm.ProductTypeList = new List<ProductTypeViewModel>();
                var typeList = _context.ProductTypes.Where(x => x.ProductId == id).ToList();
                if (typeList.Count > 0)
                {
                    foreach (var type in typeList)
                    {
                        ProductTypeViewModel typeVM = new ProductTypeViewModel();
                        typeVM.Id = type.Id;
                        typeVM.Name = type.Name;
                        typeVM.ProductId = type.ProductId;
                        typeVM.Price = type.Price;
                        typeVM.OriginPrice = type.OriginPrice;
                        typeVM.SalePrice = type.SalePrice;
                        typeVM.Status = type.Status;
                        vm.ProductTypeList.Add(typeVM);
                    }
                }
            }
             
            return vm;

        }
    }
}
