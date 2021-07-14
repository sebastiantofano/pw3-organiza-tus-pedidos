﻿using DAL.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador.Interfaces;
using System.Collections.Generic;


namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")] // Defino a que area corresponde el controller
    [Authorize(Roles = "Administrador")]
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

        [HttpGet]
        public IActionResult AgregarCliente()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AgregarCliente(Cliente cliente, string guardar)
        {
            if (ModelState.IsValid)
            {
                bool emailYaExistente = _clientesService.ValidarEmailExistente(cliente.Email);
                bool numeroYaExistente = _clientesService.ValidarNumeroExistente(cliente.Numero);

                if (emailYaExistente)
                {
                    TempData["toastr_error"] = "El email ya se encuentra registrado!";
                    return RedirectToAction("AdministrarClientes");
                }
                if (numeroYaExistente)
                {
                    TempData["toastr_error"] = "El numero de cliente ya se encuentra registrado!";
                    return RedirectToAction("AdministrarClientes");
                }

                _clientesService.Insertar(cliente);

                if (guardar.ToLower().Equals("guardar"))
                {
                    TempData["toastr_success"] = "Se ha creado al cliente correctamente !";
                    return RedirectToAction("AdministrarClientes");
                }
                TempData["toastr_success"] = "Se ha creado al cliente correctamente !";
                return RedirectToAction("AgregarCliente");

            }

            TempData["toastr_error"] = "No se ha podido crear el cliente correctamente !";
            return View();
        }

        public IActionResult AdministrarClientes()
        {

            List<Cliente> listaClientes = _clientesService.ObtenerTodos();
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult EditarCliente(string id)
        {
            int idCliente = int.Parse(id);
            Cliente cliente = _clientesService.ObtenerPorId(idCliente);

            return View(cliente);
        }

        [HttpPost]
        public IActionResult EditarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clientesService.Actualizar(cliente);

                TempData["toastr_success"] = "¡Se ha editado el cliente correctamente!";
                return RedirectToAction("AdministrarClientes");

            }
            else
            {
                TempData["toastr_error"] = "No se ha podido editar al cliente correctamente";
                return View(cliente);
            }
        }

        public IActionResult eliminarCliente(string id)
        {
            int idCliente = int.Parse(id);
            Cliente cliente = _clientesService.ObtenerPorId(idCliente);
            _clientesService.Eliminar(cliente);
            return RedirectToAction("AdministrarClientes");
        }

    }
}
