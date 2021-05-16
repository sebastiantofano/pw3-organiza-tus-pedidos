using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class HomeController : Controller
    {
        //Probando los Route para cambiar la URL
        //[Route("Home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
