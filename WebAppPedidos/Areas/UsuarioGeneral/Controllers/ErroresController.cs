using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.UsuarioGeneral.Controllers
{
    [Area("UsuarioGeneral")]
    public class ErroresController : Controller
    {
        public ErroresController()
        {

        }

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
