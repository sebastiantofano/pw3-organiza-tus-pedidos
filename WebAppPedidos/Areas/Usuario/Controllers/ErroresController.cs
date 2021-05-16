using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Usuario.Controllers
{
    [Area("Usuario")]
    public class ErroresController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [Route("404notfound")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
