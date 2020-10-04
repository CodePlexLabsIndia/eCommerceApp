using eCommerceApp.DataAccess;
using eCommerceApp.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace eCommerceApp.Controllers
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext _db;

        public UserManager(ApplicationDbContext db)
        {
            _db = db;
        }

        public async void SignIn(HttpContext httpContext, Users user, bool isPersistent = false)
        {
            Users userFromDb = new Users();
            userFromDb = _db.Users.AsEnumerable().Where(option =>
                        option.UserName == user.Email &&
                        option.Password == user.Password).ToList().SingleOrDefault();

            ClaimsIdentity identity = new ClaimsIdentity(this.GetUserClaims(userFromDb), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        public async void SignOut(HttpContext httpContext)
        {
            await httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserClaims(Users user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.AddRange(this.GetUserRoleClaims(user));
            return claims;
        }

        private IEnumerable<Claim> GetUserRoleClaims(Users user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            return claims;
        }
    }
}
