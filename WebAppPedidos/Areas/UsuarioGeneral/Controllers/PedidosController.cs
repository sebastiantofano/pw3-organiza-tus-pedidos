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
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService) // IoC en StartUp.cs
        {
            _pedidosService = pedidosService;
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
