using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAspCore.Data.Entities;

namespace WebAspCore.Helpers
{
    public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<AppUser, AppRole>
    {
        UserManager<AppUser> _userManger;

        public CustomClaimsPrincipalFactory(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
            _userManger = userManager;
        }

        public async override Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var roles = await _userManger.GetRolesAsync(user);
            //var userfullnam = user.FullName;
            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
            {
                new Claim("Email",user.Email),
                new Claim("FullName",user.FullName??string.Empty),
                new Claim("Avatar",user.Avatar??string.Empty),
                new Claim("Roles",string.Join(";",roles))
            });

            return principal;

            //var listClaims = new List<Claim>()
            //{
            //    new Claim("Email",user.Email),
            //    //new Claim("FullName",user.FullName),
            //    //new Claim("Avatar",user.Avatar??string.Empty),
            //    new Claim("Roles",string.Join(";",roles))
            //};

            //var claimIdentity = new ClaimsIdentity(listClaims);
            //var userprincipal = new ClaimsPrincipal(new[] { claimIdentity });

            //return userprincipal;
        }
    }
}
