using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Products;

namespace WebAspCore.Controllers.Components
{
    public class MenuViewComponent: ViewComponent
    {
        private readonly IMakeInService _makeInservice;
        public MenuViewComponent(IMakeInService makeInservice)
        {
            _makeInservice = makeInservice;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<MakeInViewModel> list = await _makeInservice.GetAll();

            return View(list);
        }
    }
}
