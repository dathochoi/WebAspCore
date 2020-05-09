using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAspCore.Services.Interfaces;
using WebAspCore.ViewModel.ViewModels.Account;

namespace WebAspCore.Areas.Admin.Controllers
{
    public class UserManagerController : AdminController
    {
        private readonly IUserService _userService;
        public UserManagerController(IUserService userService)
        {
            _userService = userService; 
        }
        // GET: UserManager
        public ActionResult Index()
        {
            var list = _userService.getAllUser();
            return View(list);
        }

        // GET: UserManager/Details/5
        

      

        // POST: UserManager/Update
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Update(UserViewModel userVM)
        {
            try
            {
                // TODO: Add update logic here
                _userService.Update(userVM);
                return new OkObjectResult(userVM);
            }
            catch
            {
                return BadRequest();
            }
        }

        
    }
}