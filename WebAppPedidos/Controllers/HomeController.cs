using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppPedidos.Models;

namespace WebAppPedidos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            bool estaLogeado = true;
            bool esAdmin = true;

            /* Logica para mostrar la primera vista al iniciar la aplicación o ingresar a la página*/
            if (estaLogeado)
            {
                if (esAdmin)
                {
                    return RedirectToAction("Index", "Home", new { Area = "Administrador" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { Area = "Moderador" });
                }
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Usuario" });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
