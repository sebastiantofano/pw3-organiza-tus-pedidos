using Microsoft.AspNetCore.Mvc;
using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios;
using Servicios.Administrador;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")]// Defino a que area corresponde el controller
    public class ClientesController : Controller
    {
        private readonly IClientesService clientesService;
        public ClientesController(/*IClientesService clientesService*/)
        {
            //ClientesService = clientesService;
            this.clientesService = new ClientesServiceImpl(new ClientesRepositoryImpl(new ClientesDAOImpl())); // Debo instanciar el servicio ya que todavia no tenemos inyeccion de dependencias

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

            List<Cliente> listaClientes = clientesService.ObtenerTodos();
            return View(listaClientes);
        }

        public IActionResult EditarCliente()
        {
            return View();
        }
    }
}
