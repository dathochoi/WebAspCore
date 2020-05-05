using Microsoft.AspNetCore.Mvc;
using WebAspCore.Models;
using WebAspCore.Services.Implementation;
using Microsoft.Extensions.Configuration;
using WebAspCore.Services.Interfaces;

namespace WebAspCore.Controllers
{
   
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        
       
        private Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public ProductController(IProductService productService, Microsoft.Extensions.Configuration.IConfiguration configuration, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[Route("search.html")]
        public IActionResult Catelog(string keyword, int? pageSize, string sortBy, int page = 1)
        {
            var catalog = new SearchResultViewModel();
           
            if (pageSize == null)
                pageSize = _configuration.GetValue<int>("PageSize");

            catalog.PageSize = pageSize;
            catalog.SortType = sortBy;
            catalog.Data = _productService.GetAllPaging(null, keyword, page, pageSize.Value, null);
            catalog.Keyword = keyword;

            return View(catalog);
        }
        [HttpGet]
        public IActionResult GetAllPaging(int? categoryId, int? makeInId, bool hotFlag, string keyword, int pageSize,  int page = 1 )
        {
            var model = _productService.GetAllPagingInHome(categoryId, keyword, page, pageSize, hotFlag, makeInId);
            return new OkObjectResult(model);
        }

       
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _productService.GetDetails(id);

            return View(model);
        }
    }
}