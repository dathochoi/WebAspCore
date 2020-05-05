using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebAspCore.Services.Interfaces;
using WebAspCore.Utilities.Helpers;
using WebAspCore.ViewModel.ViewModels.Products;

namespace WebAspCore.Areas.Admin.Controllers
{

    public class ProductController : AdminController
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        private IMakeInService _makeInService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IMakeInService makeInService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _makeInService = makeInService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _productService.GetAll();
            return new OkObjectResult(model);
            
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var model = _productCategoryService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMakeIns()
        {
            var model = await _makeInService.GetAll();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetAllPaging(int? categoryId, string keyword, int page, int pageSize, int? makeInId)
        {
            //if((string.IsNullOrEmpty(categoryId.ToString()))|| !string.IsNullOrEmpty(keyword) )
            //{
            //    page = 1;
            //}

            var model = _productService.GetAllPaging(categoryId, keyword, page, pageSize,makeInId);
            if (model.Results.Count == 0)
                return BadRequest();
            return new OkObjectResult(model);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var model = _productService.GetById(id);
            return new OkObjectResult(model);

        }
        [HttpPost]
        public IActionResult SaveImages(int productId, List<ImageCheckViewModel> images)
        {
            _productService.AddImages(productId, images);
           
            return new OkObjectResult(images);
        }

        [HttpGet]
        public IActionResult GetImages(int productId)
        {
            var images = _productService.GetImages(productId);
            return new OkObjectResult(images);
        }

        [HttpPost]
        public IActionResult SaveEntity(ProductViewModel productVm)
        {
            
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            else
            {
                
                productVm.SeoAlias = TextHelper.ToUnsignString(productVm.Name);
                if (productVm.Id == 0)
                {
                    _productService.Add(productVm);
                }
                else
                {
                    _productService.Update(productVm);
                }
               
                return new OkObjectResult(productVm);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            else
            {

                _productService.Delete(id);
                

                return new OkObjectResult(id);
            }
        }
       
    }
}