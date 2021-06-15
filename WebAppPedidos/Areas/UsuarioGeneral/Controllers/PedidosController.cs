using DAL.Modelos;
using DAL.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador.Interfaces;
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
        private readonly IPedidosService _pedidosService;
        private readonly IArticulosService _articulosService;

        public PedidosController(IPedidosService pedidosService, IArticulosService articulosService) // IoC en StartUp.cs
        {
            _pedidosService = pedidosService;
            _articulosService = articulosService;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("GestionarPedidos");
        }

        [HttpGet]
        public IActionResult GestionarPedidos()
        {
            List<Pedido> pedidos = _pedidosService.ObtenerTodos();
            return View(pedidos);
        }

        [HttpGet]
        public IActionResult AgregarPedido()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EditarPedido(int id)
        {
            Pedido pedido = _pedidosService.ObtenerPorId(id);

            ViewBag.Articulos = _articulosService.ObtenerTodos(); // TODO: VER SI CAMBIAMOS POR VIEWMODELS
            ViewBag.ArticulosYCantidadesDelPedido = _pedidosService.ObtenerArticulosYCantidadesDelPedido(id); // TODO: VER SI CAMBIAMOS POR VIEWMODELS

            return View(pedido);
        }

        [HttpPost]
        public IActionResult AgregarArticuloAlPedido(int idArticulo, int cantidad)
        {
            return View();
        }
    }
}
