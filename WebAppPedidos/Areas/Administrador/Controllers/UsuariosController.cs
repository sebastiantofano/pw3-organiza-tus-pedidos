using Microsoft.AspNetCore.Authorization;
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
    [Area("Administrador")] // Defino a que area corresponde el controller
    [Authorize(Roles = "Administrador")]
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
            List<Usuario> usuarios = usuariosService.ObtenerTodos();
            return View(usuarios);
        }

        [HttpGet]
        public IActionResult CrearUsuario()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Donde se debe validar si ya existe el email? En este Controller o en el Service
                bool emailYaExistente = usuariosService.ValidarEmailExistente(usuario.Email);
                if (emailYaExistente)
                {
                    TempData["toastr_error"] = "El email ya se encuentra registrado!";
                    return RedirectToAction("AdministrarUsuarios");
                }
                usuariosService.Insertar(usuario);
                TempData["toastr_success"] = "Se ha creado al usuario correctamente !";
                return RedirectToAction("AdministrarUsuarios");
            }

            TempData["toastr_error"] = "No se ha podido crear el usuario correctamente !";
            return View();
        }
        
        [HttpGet]
        public IActionResult EditarUsuario(string id)
        {
            int idUsuario = int.Parse(id);
            Usuario usuario = usuariosService.ObtenerPorId(idUsuario);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuariosService.Actualizar(usuario);

                TempData["toastr_success"] = "Se ha editado el usuario correctamente !";
                return RedirectToAction("AdministrarUsuarios");

            }
            else
            {
                TempData["toastr_error"] = "No se ha podido editar al usuario correctamente";
                return View(usuario);
            }
        }





    }
  
}
