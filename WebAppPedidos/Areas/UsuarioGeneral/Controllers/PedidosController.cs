using DAL.Modelos;
using DAL.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador.Interfaces;
using Servicios.Helpers.Exceptions;
using Servicios.UsuarioGeneral;
using Servicios.UsuarioGeneral.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPedidos.Areas.UsuarioGeneral.Models;

namespace WebAppPedidos.Areas.UsuarioGeneral.Controllers
{
    [Area("UsuarioGeneral")] // Defino a que area corresponde el controller
    [Authorize(Roles = "Administrador, Moderador")]
    public class PedidosController : Controller
    {
        private readonly IPedidosService _pedidosService;
        private readonly IArticulosService _articulosService;
        private readonly IClientesService _clientesService;

        public PedidosController(IPedidosService pedidosService, IArticulosService articulosService, IClientesService clientesService) // IoC en StartUp.cs
        {
            _pedidosService = pedidosService;
            _articulosService = articulosService;
            _clientesService = clientesService;

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

            ViewBag.Articulos = _articulosService.ObtenerTodosNoEliminados(); // TODO: VER SI CAMBIAMOS POR VIEWMODELS
            ViewBag.Clientes = _clientesService.ObtenerTodosNoEliminados(); // TODO: VER SI CAMBIAMOS POR VIEWMODELS
            return View();
        }

        [HttpPost]
        public IActionResult AgregarPedido(Pedido pedido, PedidoArticulo pedidoArticulo, bool permanecerView) // TODO: ¿Puedo hacer esto, o conviene un ViewModel?
        {
            if (!ModelState.IsValid)
            {
                TempData["toastr_error"] = "No ha ingresado correctamente la información del pedido !";
                return RedirectToAction("AgregarPedido");
            }

            try
            {
                int idPedidoInsertado = _pedidosService.Insertar(pedido);
                pedidoArticulo.IdPedido = idPedidoInsertado;
                _pedidosService.AgregarArticuloYCantidadAlPedido(pedidoArticulo);
                TempData["toastr_success"] = $"Se ha creado exitosamente el pedido !";
                return (permanecerView) ? RedirectToAction("AgregarPedido") : RedirectToAction("EditarPedido", new { id = idPedidoInsertado });
            }
            catch (PedidoException e)
            {
                TempData["toastr_error"] = e.Message;
                return RedirectToAction("AgregarPedido");
            }
        }

        [HttpGet]
        public IActionResult EditarPedido(int id)
        {
            Pedido pedido = _pedidosService.ObtenerPorId(id);
            EditarPedidoViewModel editarPedidoViewModel = new() { Pedido = pedido };

            editarPedidoViewModel.SelectArticulosDisponibles = _articulosService.ObtenerTodosNoEliminados();
            editarPedidoViewModel.ArticulosYCantidadesDelPedido = _pedidosService.ObtenerArticulosYCantidadesDelPedido(id);

            return View(editarPedidoViewModel);
        }

        [HttpPost]
        public IActionResult EditarPedido(Pedido pedido)
        {
            _pedidosService.Actualizar(pedido);
            TempData["toastr_success"] = "Se ha actualizado el pedido exitosamente !";
            return RedirectToAction("EditarPedido", new { id = pedido.IdPedido });
        }

        [HttpPost]
        public IActionResult AgregarArticuloAlPedido(EditarPedidoViewModel editarPedidoViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["toastr_error"] = "No ha ingresado correctamente la información del Artículo !";
                return RedirectToAction("EditarPedido", new { id = editarPedidoViewModel.PedidoArticulo.IdPedido });
            }

            _pedidosService.AgregarArticuloYCantidadAlPedido(editarPedidoViewModel.PedidoArticulo);
            TempData["toastr_success"] = "Se ha añadido el artículo al pedido exitosamente !";
            return RedirectToAction("EditarPedido", new { id = editarPedidoViewModel.PedidoArticulo.IdPedido });
        }

        [HttpPost]
        public IActionResult EliminarArticuloAlPedido(PedidoArticulo pedidoArticulo)
        {
            _pedidosService.EliminarArticuloAlPedido(pedidoArticulo);
            TempData["toastr_success"] = "Se ha eliminado el artículo del pedido exitosamente !";
            return RedirectToAction("EditarPedido", new { id = pedidoArticulo.IdPedido });
        }

        [HttpPost]
        public IActionResult MarcarComoCerrado(Pedido pedido)
        {
            try
            {
                _pedidosService.MarcarComoCerrado(pedido.IdPedido);
                TempData["toastr_success"] = "Se ha cerrado el pedido exitosamente !";
                return RedirectToAction("EditarPedido", new { id = pedido.IdPedido });
            }
            catch (PedidoException e)
            {
                TempData["toastr_error"] = e.Message;
                return RedirectToAction("EditarPedido", new { id = pedido.IdPedido });
            }
        }

        [HttpPost]
        public IActionResult MarcarComoEntregado(Pedido pedido)
        {
            try
            {
                _pedidosService.MarcarComoEntregado(pedido.IdPedido);
                TempData["toastr_success"] = "Se ha entregado el pedido exitosamente !";
                return RedirectToAction("EditarPedido", new { id = pedido.IdPedido });
            }
            catch (PedidoException e)
            {
                TempData["toastr_error"] = e.Message;
                return RedirectToAction("EditarPedido", new { id = pedido.IdPedido });
            }
        }

        [HttpPost]
        public IActionResult EliminarPedido(Pedido pedido)
        {
            _pedidosService.Eliminar(pedido);

            TempData["toastr_info"] = "Se ha eliminado el pedido correctamente !";
            return RedirectToAction("GestionarPedidos");
        }

    }
}
