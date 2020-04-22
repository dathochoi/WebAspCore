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
            _context.Products.Add(p);
            _context.SaveChanges();
            return product;

        }

        public void Delete(int id)
        {
            Product p = _context.Products.Find(id);
            if (p == null)
            {
                throw new Exception("Product isn't exsit");

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

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            //var query = _context.Products.Find(x => x.Status == Status.Active).ToList();
            var query = _context.Products.Where(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }
            if(categoryId.HasValue)
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
            return vm;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductViewModel product)
        {
            //var vm = _mapper.Map<Product>(product);
            var vm = MapperExtend.VMToProduct(product);
            _context.Products.Update(vm);

        }
    }
}
