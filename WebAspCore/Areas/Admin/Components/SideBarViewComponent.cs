using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAspCore.Extensions;
using WebAspCore.Services.Interfaces;
using WebAspCore.Utilities;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Areas.Admin.Components
{
    public class SideBarViewComponent : ViewComponent
    {
        IFunctionService _functionService;
        public SideBarViewComponent(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = ((ClaimsPrincipal)User).GetSpecificClaim("Roles");
            List<FunctionViewModel> functions;
            if (roles.Split(";").Contains(CommonConstants.AdminRole))
            {
                functions = await _functionService.GetAll();
            }
            else
            {
                functions = new List<FunctionViewModel>();
            }
            //functions = await _functionService.GetAll();
            return View(functions);
        }
    }
}
