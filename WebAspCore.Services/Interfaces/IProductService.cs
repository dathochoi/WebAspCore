using System.Collections.Generic;
using WebAspCore.Utilities.DTOs;
using WebAspCore.ViewModel.ViewModels.Products;

namespace WebAspCore.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize, int? makeInId);

       // PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);


        PagedResult<ProductViewModel> GetAllPagingInHome(int? categoryId, string keyword, int page, int pageSize, bool hotFlag, int? makeInId);

        ProductViewModel GetDetails(int id);

        ProductViewModel Add(ProductViewModel product);

        void Update(ProductViewModel product);

        void Delete(int id);

        ProductViewModel GetById(int id);
        void AddImages(int productId, List<ImageCheckViewModel> images);
        public List<ProductImageViewModel> GetImages(int productId);
       // void Save();
    }
}
