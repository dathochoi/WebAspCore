using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebAspCore.Data.Context;
using WebAspCore.Data.Entities;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels;

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
            var productCategory =_mapper.Map<ProductCategory>(productCategoryVm);
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
            throw new NotImplementedException();

        }

        public List<ProductCategoryViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetAllByParentId(int parentId)
        {
            throw new NotImplementedException();
        }

        public ProductCategoryViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetHomeCategories(int top)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            throw new NotImplementedException();
        }
    }
}