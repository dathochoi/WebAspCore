using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Controllers.Components
{
    public class BackgroundViewComponent : ViewComponent
    {
        private ISystemsService _systemsService;
        public BackgroundViewComponent(ISystemsService systemsService)
        {
            _systemsService = systemsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ImageViewModel item = await _systemsService.GetImage();
            item.Background = item.Background ;
            return View(item);
        }
    }
}
