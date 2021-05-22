using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloDatosProvisorios.Modelos;
using Servicios.Administrador;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class ArticulosController : Controller
    {
        private readonly IArticulosService articulosService;
        public ArticulosController(/*IArticulosService articulosService*/) 
        {
            //this.articulosService = articulosService;
            articulosService = new ArticulosServiceImpl(); // Debo instanciar el servicio ya que todavia no tenemos inyeccion de dependencias
        }
        public IActionResult Index()
        {
            return RedirectToAction("AdministrarArticulos");
        }

        public IActionResult AdministrarArticulos()
        {
            List<Articulo> listaArticulos = articulosService.ObtenerTodos();
            return View(listaArticulos);
        }

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
                articulosService.Insertar(articulo);
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
            Articulo articulo = articulosService.ObtenerPorId(IdArticulo);

            return View(articulo);
        }

        [HttpPost]
        public IActionResult EditarArticulo(Articulo articulo)
        {
            articulosService.Actualizar(articulo);

            TempData["toastr_success"] = "Se ha editado el artículo correctamente !";

            return RedirectToAction("AdministrarArticulos");
        }

        [HttpPost]
        public IActionResult EliminarArticuloPorId(string id)
        {
            int IdArticulo = int.Parse(id);
            articulosService.EliminarPorId(IdArticulo);

            TempData["toastr_info"] = "Se ha eliminado el artículo correctamente !";
            return RedirectToAction("AdministrarArticulos");
        }

    }
}
