using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")] // Defino a que area corresponde el controller
    [Authorize(Roles = "Administrador")]
    public class HomeController : Controller 
    {

        public HomeController()
        {

        }

        //Probando los Route para cambiar la URL
        //[Route("Home")]
        public IActionResult Index()
        {
            // Probando el uso de session
            //ViewData["NombreUsuario"] = HttpContext.Session.GetString("NombreUsuario");
            return View();
        }
    }
}
