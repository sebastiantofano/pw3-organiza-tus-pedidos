using Microsoft.AspNetCore.Mvc;
using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.Repositorios;
using Servicios.Administrador;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidos.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class UsuariosController : Controller
    {
        private readonly IUsuariosService usuariosService;

        public UsuariosController(/*IUsuariosService usuariosService*/)
        {
            //this.usuariosService = usuariosService;
            this.usuariosService = new UsuariosServiceImpl(new UsuariosRepositoryImpl(new UsuariosDAOImpl())); // Debo instanciar el servicio ya que todavia no tenemos inyeccion de dependencias
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdministrarUsuarios()
        {
            return View();
        }
        
        public IActionResult CrearUsuario()
        {
            return View();
        }
    }
}
