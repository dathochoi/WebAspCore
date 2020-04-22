using System;
using System.Collections.Generic;
using System.Text;
using WebAspCore.Utilities.DTOs;
using WebAspCore.ViewModel.ViewModels;

namespace WebAspCore.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);

        ProductViewModel Add(ProductViewModel product);

        void Update(ProductViewModel product);

        void Delete(int id);

        ProductViewModel GetById(int id);

        void Save();
    }
}
