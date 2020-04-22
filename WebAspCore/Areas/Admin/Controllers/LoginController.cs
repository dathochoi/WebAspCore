using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
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


                    //var user = await _signInManager.UserManager.FindByNameAsync(model.UserName);
                    //var roles = await _userManager.GetRolesAsync(user);
                    //var listClaims = new List<Claim>()
                    //{
                    //    new Claim("Email",user.Email),
                    //    //new Claim("FullName",user.FullName),
                    //    //new Claim("Avatar",user.Avatar??string.Empty),
                    //    new Claim("Roles",string.Join(";",roles))
                    //};

                    //var claimIdentity = new ClaimsIdentity(listClaims);
                    //var userprincipal = new ClaimsPrincipal(new[] { claimIdentity });
                    //_ = HttpContext.SignInAsync(userprincipal);
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