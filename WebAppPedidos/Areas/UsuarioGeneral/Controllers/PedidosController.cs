using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.UsuarioGeneral.Controllers
{
    [Area("UsuarioGeneral")]
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[Route("GestionarPedidos")]
        public IActionResult GestionarPedidos()
        {
            return View();
        }

        //[Route("AgregarPedido")]
        public IActionResult AgregarPedido()
        {
            return View();
        }

        //[Route("EditarPedido")]
        public IActionResult EditarPedido()
        {
            return View();
        }
    }
}
