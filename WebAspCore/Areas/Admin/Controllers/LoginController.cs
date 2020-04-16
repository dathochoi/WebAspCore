using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAspCore.Data.Entities;
using WebAspCore.ViewModel.ViewModels.Account;

namespace WebAspCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authen(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return new OkObjectResult(new {Success = true, Data = model });
                }
                if(result.IsLockedOut)
                {
                    return new ObjectResult(new { Success = true, Data = "User is locked" });
                }
                else
                {
                    return new ObjectResult(new { Success = true, Data = "Login fail." });
                }
            }
            return new ObjectResult(new { Success = false, Data = model });
        }
    }
}