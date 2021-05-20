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
        IArticulosService ArticulosService;
        public ArticulosController()
        {
            ArticulosService = new ArticulosServiceImpl();
        }
        public IActionResult Index()
        {
            return RedirectToAction("AdministrarArticulos");
        }

        public IActionResult AdministrarArticulos()
        {
            List<Articulo> listaArticulos = ArticulosService.ObtenerTodos();
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
                ArticulosService.Insertar(articulo);
                return RedirectToAction("AdministrarArticulos");
            }

            return View();

        }

        [HttpGet]
        public IActionResult EditarArticulo(string id)
        {
            int IdArticulo = int.Parse(id);
            Articulo articulo = ArticulosService.ObtenerPorId(IdArticulo);

            return View(articulo);
        }

        [HttpPost]
        public IActionResult EditarArticulo(Articulo articulo)
        {
            ArticulosService.Actualizar(articulo);

            return RedirectToAction("AdministrarArticulos");
        }

        [HttpPost]
        public IActionResult EliminarArticuloPorId(string id)
        {
            int IdArticulo = int.Parse(id);
            ArticulosService.EliminarPorId(IdArticulo);

            return RedirectToAction("AdministrarArticulos");
        }

    }
}
