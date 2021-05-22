using Microsoft.AspNetCore.Mvc;
using Servicios.UsuarioGeneral;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.UsuarioGeneral.Controllers
{
    [Area("UsuarioGeneral")]
    public class PedidosController : Controller
    {
        private readonly IPedidosService pedidosService;

        public PedidosController(/*IPedidosService pedidosService*/)
        {
            //this.pedidosService = pedidosService;
            pedidosService = new PedidosServiceImpl(); // Debo instanciar el servicio ya que todavia no tenemos inyeccion de dependencias
        }

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
