using ModeloDatosProvisorios.Helpers.Exceptions;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.UsuarioGeneral
{
    public class LoginServiceImpl : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        public LoginServiceImpl(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        public void CerrarSesion()
        {
            throw new NotImplementedException();
        }

        public Usuario IniciarSesion(Usuario usuario)
        {
            try
            {
                Usuario usuarioEncontrado = loginRepository.IniciarSesion(usuario);

                return usuarioEncontrado;
            }
            catch (InvalidLoginException)
            {
                throw;
            }
            
        }
    }
}
