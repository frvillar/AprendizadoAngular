using System;
using Microsoft.AspNetCore.Mvc;

namespace Cproj1.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
