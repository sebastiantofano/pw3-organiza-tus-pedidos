using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class ArticulosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdministrarArticulos()
        {
            return View();
        }
        public IActionResult AgregarArticulo()
        {
            return View();
        }

        public IActionResult EditarArticulo()
        {
            return View();
        }
    }
}
