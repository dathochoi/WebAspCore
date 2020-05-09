using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAspCore.Data.Entities;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Areas.Admin.Controllers
{
    public class SystemController : AdminController
    {
        private readonly ISystemsService _systemsService;
        public SystemController(ISystemsService systemsService)
        {
            _systemsService = systemsService;
        }
    // GET: System
    public ActionResult Index()
        {
            return View();
        }

      

        // GET: System/Edit/5
        public async Task<ActionResult> Edit()
        {
            var model =await _systemsService.GetSystems();
            return View(model);
        }

        // POST: System/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SystemsViewModel systems)
        {
            try
            {
                //if(id == systems.Id )
                //{
                    _systemsService.UpdateSystem(systems);
                    return RedirectToAction(nameof(Edit));
                //}

                ///return View();
            }
            catch
            {
                return View();
            }
        }

     
    }
}