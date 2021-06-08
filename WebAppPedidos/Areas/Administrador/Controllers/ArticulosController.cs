﻿using DAL.Modelos;
using DAL.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador;
using Servicios.Administrador.Interfaces;
using Servicios.Helpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")]  // Defino a que area corresponde el controller
    [Authorize(Roles = "Administrador")] // Defino autorizacion para todos los metodos del controller, "Roles" es una property logica de la clase "Usuario"
    public class ArticulosController : Controller 
    {
        private readonly IArticulosService _articulosService;

        public ArticulosController(IArticulosService articulosService) // IoC en StartUp.cs
        {
            _articulosService = articulosService; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("AdministrarArticulos");
        }


        [HttpGet]
        public IActionResult AdministrarArticulos()
        {
            List<Articulo> listaArticulos = _articulosService.ObtenerTodos();
            return View(listaArticulos);
        }


        [HttpGet]
        public IActionResult AgregarArticulo()
        {
            return View();
        }


        [HttpGet]
        public IActionResult EditarArticulo(string id)
        {
            int IdArticulo = int.Parse(id);
            Articulo articulo = _articulosService.ObtenerPorId(IdArticulo);

            return View(articulo);
        }


        [HttpPost]
        public IActionResult AgregarArticulo(Articulo articulo)
        {
            /* Intentar realizar una validación cuando tenemos el atajo de agregar un articulo en la vista de administracion de articulos */
            if (!ModelState.IsValid)
            {
                TempData["toastr_error"] = "No ha ingresado correctamente la información del Artículo !";
                return View();
            }
            
            try
            {
                _articulosService.Insertar(articulo);
                TempData["toastr_success"] = "Se ha creado el artículo correctamente !";
                return RedirectToAction("AdministrarArticulos");
            }
            catch (ArticuloException e)
            {
                TempData["toastr_error"] = e.Message;
                return View();
            }

        }


        [HttpPost]
        public IActionResult EditarArticulo(Articulo articulo)
        {
            if (!ModelState.IsValid)
            {
                TempData["toastr_error"] = "No se ha podido editar el artículo correctamente !";
                return View();
            }

            _articulosService.Actualizar(articulo);
            TempData["toastr_success"] = "Se ha editado el artículo correctamente !";
            return RedirectToAction("AdministrarArticulos");
         }

        

        [HttpPost]
        public IActionResult EliminarArticulo(Articulo articulo) //TODO: Editar
        {
            _articulosService.Eliminar(articulo);

            TempData["toastr_info"] = "Se ha eliminado el artículo correctamente !";
            return RedirectToAction("AdministrarArticulos");
        }

    }
}
