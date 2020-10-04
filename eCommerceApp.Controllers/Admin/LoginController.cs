using eCommerceApp.DataAccess;
using eCommerceApp.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace eCommerceApp.Controllers.Admin
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IUserManager _userManager;

        public LoginController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewData["AppName"] = "VegeFoods";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Users user)
        {
            if (!string.IsNullOrEmpty(user.UserName) && string.IsNullOrEmpty(user.Password))
                return RedirectToAction("Login");
            _userManager.SignIn(this.HttpContext, user);
            return RedirectToAction("Index", "Admin");
        }
    }
}
