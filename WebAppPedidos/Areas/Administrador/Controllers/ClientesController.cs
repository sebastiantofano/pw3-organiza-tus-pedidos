using DAL.Modelos;
using DAL.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")] // Defino a que area corresponde el controller
    //[Authorize(Roles = "Administrador")]
    public class ClientesController : Controller
    {
        private readonly IClientesService _clientesService;
        public ClientesController(IClientesService clientesService) // IoC en StartUp.cs
        {
            _clientesService = clientesService;

        }
        public IActionResult Index()
        {
            return RedirectToAction("AdministrarClientes");
        }

        public IActionResult AgregarCliente()
        {
            return View();
        }

        public IActionResult AdministrarClientes()
        {

            List<Cliente> listaClientes = _clientesService.ObtenerTodos();
            return View(listaClientes);
        }

        public IActionResult EditarCliente()
        {
            return View();
        }
    }
}
