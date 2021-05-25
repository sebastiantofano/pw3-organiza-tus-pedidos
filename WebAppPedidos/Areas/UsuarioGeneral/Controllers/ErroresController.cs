using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.UsuarioGeneral.Controllers
{
    [Area("UsuarioGeneral")] // Defino a que area corresponde el controller
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
        [Authorize(Roles = "Administrador, Moderador")]
        public IActionResult Error404()
        {
            return View();
        }

        [Route("401unauthorized")]
        public IActionResult Error401()
        {
            return View();
        }
    }
}

