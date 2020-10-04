using eCommerceApp.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceApp.Controllers
{
    public interface IUserManager
    {
        public void SignIn(HttpContext httpContext, Users user, bool isPersistent = false);

        public void SignOut(HttpContext httpContext);
    }
}
