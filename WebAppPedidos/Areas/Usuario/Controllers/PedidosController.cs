using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Usuario")]
    public class PedidosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[Route("AgregarPedido")]
        public IActionResult AgregarPedido()
        {
            return View();
        }
    }
}
