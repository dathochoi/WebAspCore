using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Controllers.Components
{
    public class NameWebSiteViewComponent : ViewComponent
    {
        private ISystemsService _systemsService;
        public NameWebSiteViewComponent(ISystemsService systemsService)
        {
            _systemsService = systemsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            NameWebSiteViewModel model = new NameWebSiteViewModel();
            model = await _systemsService.GetNameWebSite();

            return View(model);
        }
    }
}
