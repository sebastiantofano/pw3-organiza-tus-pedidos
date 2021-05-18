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

        public IActionResult EditarArticulo(string id)
        {
            int IdArticulo = int.Parse(id);
            Articulo articulo = ArticulosService.ObtenerPorId(IdArticulo);
            return View(articulo);
        }
    }
}
