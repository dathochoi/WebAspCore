﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAspCore.Data.Context;
using WebAspCore.Data.Entities;
using WebAspCore.Data.Enums;
using WebAspCore.Services.AutoMapper;
using WebAspCore.Services.Interfaces;
using WebAspCore.Utilities.DTOs;
using WebAspCore.ViewModel.ViewModels;
using WebAspCore.ViewModel.ViewModels.Products;

namespace WebAspCore.Services.Implementation
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly WebDbContext _context;
        private readonly IMapper _mapper;
        public ProductCategoryService(WebDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm)
        {
            // var productCategory =_mapper.Map<ProductCategory>(productCategoryVm);
            var productCategory = MapperExtend.VMToProductCategory(productCategoryVm);
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
            return productCategoryVm;
        }

        public void Delete(int id)
        {
            var productCategory = _context.ProductCategories.Find(id);
            if (productCategory ==null)
            {
                throw new Exception("Can't not Product Category " + id);
            }
            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            //return _context.ProductCategories.Find();
            //throw new NotImplementedException();
            var list = _context.ProductCategories.ToList();
            var listvm = new List<ProductCategoryViewModel>();
            foreach( var item in list)
            {
                var vm = new ProductCategoryViewModel();
                vm = MapperExtend.ProductCategoryToVM(item);

                listvm.Add(vm);
            }
            return listvm;

        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            List<ProductCategory> listvm = new List<ProductCategory>();
            if (!string.IsNullOrEmpty(keyword))
            {
                 listvm = _context.ProductCategories.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword))
                      .OrderBy(x => x.ParentId)
                      .ToList();
            }
            else
            {
                 listvm = _context.ProductCategories.ToList();
            }
            List<ProductCategoryViewModel> list = new List<ProductCategoryViewModel>();
            foreach(var item in listvm)
            {
                ProductCategoryViewModel vm = new ProductCategoryViewModel();
                vm = MapperExtend.ProductCategoryToVM(item);
                list.Add(vm);
            }
            return list;
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            List<ProductCategory> list = _context.ProductCategories.Where(x => x.Status == Data.Enums.Status.Active && x.ParentId == parentId).ToList();
            List<ProductCategoryViewModel> listvm = new List<ProductCategoryViewModel>();
            foreach( var  item in list)
            {
                ProductCategoryViewModel vm = new ProductCategoryViewModel();
                vm = MapperExtend.ProductCategoryToVM(item);
                listvm.Add(vm);
            }
            return listvm;
        }

        public PagedResult<ProductCategoryViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _context.ProductCategories.Where(x => x.Status == Status.Active || x.Status == Status.InActive);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.Name)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ToList();

            List<ProductCategoryViewModel> listProductCategoryVM = new List<ProductCategoryViewModel>();
            foreach (var item in data)
            {
                var vm = new ProductCategoryViewModel();
                vm.Id = item.Id;
                vm.Name = item.Name;
                vm.Status = item.Status;
                listProductCategoryVM.Add(vm);
            }

            var paginationSet = new PagedResult<ProductCategoryViewModel>()
            {
                Results = listProductCategoryVM,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public async Task<List<ProductCategoryViewModel>> GetAllVC()
        {
            var list = await _context.ProductCategories.ToListAsync();
            var listvm = new List<ProductCategoryViewModel>();
            foreach (var item in list)
            {
                var vm = new ProductCategoryViewModel();
                vm = MapperExtend.ProductCategoryToVM(item);

                listvm.Add(vm);
            }
            return listvm;
        }

        public ProductCategoryViewModel GetById(int id)
        {
            var item = _context.ProductCategories.Find(id);
            if (item ==null)
            {
                throw new Exception("Product Category " + id + " not exist.");

            }
            return MapperExtend.ProductCategoryToVM(item);
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            var list = _context.ProductCategories.Where(x => x.HomeFlag == true).OrderBy(x => x.HomeOrder)
                .Take(top).ToList();
            var listvm = new List<ProductCategoryViewModel>();
            foreach( var item in list)
            {
                ProductCategoryViewModel vm = new ProductCategoryViewModel();
                vm = MapperExtend.ProductCategoryToVM(item);
                listvm.Add(vm);

            }
            return listvm;
        }

        public void ReOrder(int sourceId, int targetId)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategoryViewModel productCategoryVm)
        {
            var item = MapperExtend.VMToProductCategory(productCategoryVm);
            _context.ProductCategories.Update(item);
            _context.SaveChanges();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }
    }
}