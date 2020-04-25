using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels;

namespace WebAspCore.Controllers.Components
{
    public class SideBarCategoryViewComponent :ViewComponent
    {
        private IProductCategoryService _productCategoryService;
        public SideBarCategoryViewComponent(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ProductCategoryViewModel> list = await _productCategoryService.GetAllVC();

            return View(list);
        }
    }
}
