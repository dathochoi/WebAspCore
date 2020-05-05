using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAspCore.Utilities.DTOs;
using WebAspCore.ViewModel.ViewModels;
using WebAspCore.ViewModel.ViewModels.Products;

namespace WebAspCore.Services.Interfaces
{
    public interface IProductCategoryService
    {
        ProductCategoryViewModel Add(ProductCategoryViewModel productCategoryVm);

        void Update(ProductCategoryViewModel productCategoryVm);

        void Delete(int id);

        List<ProductCategoryViewModel> GetAll();

        Task<List<ProductCategoryViewModel>> GetAllVC();

        List<ProductCategoryViewModel> GetAll(string keyword);

        List<ProductCategoryViewModel> GetAllByParentId(int parentId);

        ProductCategoryViewModel GetById(int id);

        void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items);
        void ReOrder(int sourceId, int targetId);

        List<ProductCategoryViewModel> GetHomeCategories(int top);
        PagedResult<ProductCategoryViewModel> GetAllPaging(string keyword, int page, int pageSize);

        void Save();
    }
}


