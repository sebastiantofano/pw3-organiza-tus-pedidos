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
        public IActionResult Index()
        {
            return RedirectToAction("AdministrarArticulos");
        }

        public IActionResult AdministrarArticulos()
        {
            IArticulosService articulosService = new ArticulosServiceImpl();

            List<Articulo> listaArticulos = articulosService.ObtenerTodos();
            return View(listaArticulos);
        }
        public IActionResult AgregarArticulo()
        {
            return View();
        }

        public IActionResult EditarArticulo()
        {
            return View();
        }
    }
}
