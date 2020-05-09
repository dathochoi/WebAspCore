using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebAspCore.Services.Interfaces;

namespace WebAspCore.Controllers
{
    public class ContactController : Controller
    {
        private readonly ISystemsService _systemsService;
        public ContactController(ISystemsService  systemsService)
        {
            _systemsService = systemsService;
        }
        public IActionResult Index()
        {
            var model = _systemsService.GetContact();
            return View(model);
        }
    }
}