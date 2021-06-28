using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Administrador
{
    public class UsuariosServiceImpl : BaseServiceImpl<Usuario>, IUsuariosService
    {
        private readonly IUsuariosRepository _usuariosRepository;
        public UsuariosServiceImpl(IUsuariosRepository usuariosRepository, IHttpContextAccessor httpContextAccessor) : base(usuariosRepository, httpContextAccessor)
        {
            _usuariosRepository = usuariosRepository;
        }
        public bool ValidarEmailExistente(string email)
        {
            return _usuariosRepository.ValidarEmailExistente(email);
        }
        public List<Usuario> ObtenerTodosPorIdUsuarioOPorEmail(int idUsuario,string email)
        {
            return _usuariosRepository.ObtenerTodosPorIdUsuarioOPorEmail(idUsuario,email);
        }

    }
}
