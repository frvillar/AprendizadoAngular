using System;
using Microsoft.AspNetCore.Mvc;

namespace Cproj3.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
