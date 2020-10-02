using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceApp.Controllers
{
    [Area("Customer")]
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View("Orders");
        }
    }
}
