using DAL.Modelos;
using DAL.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.UsuarioGeneral;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.UsuarioGeneral.Controllers
{
    [Area("UsuarioGeneral")] // Defino a que area corresponde el controller
    [Authorize(Roles = "Administrador, Moderador")]
    public class PedidosController : Controller
    {
        private readonly IPedidosService pedidosService;

        public PedidosController(/*IPedidosService pedidosService*/) // Esto sera la inyeccion de dependencias
        {
            //this.pedidosService = pedidosService;
            pedidosService = new PedidosServiceImpl(new PedidosRepositoryImpl(new PedidosPW3Context())); // Debo instanciar el servicio ya que todavia no tenemos inyeccion de dependencias
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
