using DAL.Modelos;
using DAL.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService) // IoC en StartUp.cs
        {
            _usuariosService = usuariosService; 
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdministrarUsuarios()
        {
            List<Usuario> usuarios = _usuariosService.ObtenerTodos();
            ViewBag.todosUsuarios = usuarios;
            return View(usuarios);
        }
        [HttpPost]
        public IActionResult AdministrarUsuarios(int idUsuario, string email)
        {
            ViewBag.todosUsuarios = _usuariosService.ObtenerTodos();
            ViewBag.idUsuarioSeleccionado = idUsuario;
            ViewBag.emailSeleccionado = email;
            List<Usuario> usuarios = _usuariosService.ObtenerTodosPorIdUsuarioOPorEmail(idUsuario,email);
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
                bool emailYaExistente = _usuariosService.ValidarEmailExistente(usuario.Email);
                if (emailYaExistente)
                {
                    TempData["toastr_error"] = "El email ya se encuentra registrado!";
                    return RedirectToAction("AdministrarUsuarios");
                }
                _usuariosService.Insertar(usuario);
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
            Usuario usuario = _usuariosService.ObtenerPorId(idUsuario);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult EditarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuariosService.Actualizar(usuario);

                TempData["toastr_success"] = "Se ha editado el usuario correctamente !";
                return RedirectToAction("AdministrarUsuarios");

            }
            else
            {
                TempData["toastr_error"] = "No se ha podido editar al usuario correctamente";
                return View(usuario);
            }
        }
        public IActionResult EliminarUsuario(int id)
        {
            Usuario usuario = _usuariosService.ObtenerPorId(id);
            _usuariosService.Eliminar(usuario);
            TempData["toastr_info"] = "Se ha eliminado el usuario correctamente !";
            return RedirectToAction("AdministrarUsuarios");
        }




    }
  
}
