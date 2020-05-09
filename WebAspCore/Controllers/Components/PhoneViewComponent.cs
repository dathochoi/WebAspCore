using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Controllers.Components
{
    public class PhoneViewComponent: ViewComponent
    {
        private ISystemsService _systemsService;
        public PhoneViewComponent(ISystemsService systemsService)
        {
            _systemsService = systemsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            NameWebSiteViewModel item = await _systemsService.GetNameWebSite();
           
            return View(item);
        }
    }
}
