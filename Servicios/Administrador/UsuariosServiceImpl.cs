using DAL.Modelos;
using DAL.Repositorios.Interfaces;
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
        private readonly IUsuariosRepository usuariosRepository;
        public UsuariosServiceImpl(IUsuariosRepository usuariosRepository) : base(usuariosRepository) // Hago el NEW porque todavia no vimos inyeccion de dependencias
        {
            this.usuariosRepository = usuariosRepository;
        }

        public bool ValidarEmailExistente(string email)
        {
            return usuariosRepository.ValidarEmailExistente(email);
        }
    }
}
