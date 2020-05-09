using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Controllers.Components
{
    public class LogoViewComponent : ViewComponent
    {
        private ISystemsService _systemsService;
        public LogoViewComponent(ISystemsService systemsService)
        {
            _systemsService = systemsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ImageViewModel item = await _systemsService.GetImage();
            item.Logo = item.Logo + "?w=129&h=50&autorotate=true&format=png&mode=pad";
            return View(item);
        }
    }
}
