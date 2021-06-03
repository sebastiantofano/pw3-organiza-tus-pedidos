﻿using DAL.Modelos;
using DAL.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicios.Administrador;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")]  // Defino a que area corresponde el controller
    [Authorize(Roles = "Administrador")]
    public class ArticulosController : Controller 
    {
        private readonly IArticulosService _articulosService;
        public ArticulosController(IArticulosService articulosService) // IoC en StartUp.cs
        {
            _articulosService = articulosService; 
        }
        public IActionResult Index()
        {
            return RedirectToAction("AdministrarArticulos");
        }

        
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


        [HttpPost]
        public IActionResult AgregarArticulo(Articulo articulo)
        {
            /* Intentar realizar una validación cuando tenemos el atajo de agregar un articulo en la vista de administracion de articulos */
            if (ModelState.IsValid)
            {
                // Donde se debe validar si ya existe el articulo? En este Controller o en el Service
                bool codigoYaExistente = _articulosService.ValidarCodigoExistente(articulo.Codigo);
                if (codigoYaExistente)
                {
                    TempData["toastr_error"] = "El codigo de artículo que ha ingresado ya existe!";
                    return RedirectToAction("AdministrarArticulos");
                }
                _articulosService.Insertar(articulo);
                TempData["toastr_success"] = "Se ha creado el artículo correctamente !";
                return RedirectToAction("AdministrarArticulos");
            }

            TempData["toastr_error"] = "No se ha podido crear el artículo correctamente !";
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
        public IActionResult EditarArticulo(Articulo articulo)
        {
            _articulosService.Actualizar(articulo);

            TempData["toastr_success"] = "Se ha editado el artículo correctamente !";

            return RedirectToAction("AdministrarArticulos");
        }

        [HttpPost]
        public IActionResult EliminarArticuloPorId(string id, string who)
        {
            int IdArticulo = int.Parse(id);
            _articulosService.EliminarPorId(IdArticulo, who);

            TempData["toastr_info"] = "Se ha eliminado el artículo correctamente !";
            return RedirectToAction("AdministrarArticulos");
        }

    }
}
