using ModeloDatosProvisorios.DAO.Interfaces;
using ModeloDatosProvisorios.Helpers.Exceptions;
using ModeloDatosProvisorios.Modelos;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Repositorios
{
    public class LoginRepositoryImpl : ILoginRepository
    {
        private readonly IUsuariosDAO usuariosDAO;

        public LoginRepositoryImpl(IUsuariosDAO usuariosDAO)
        {
            this.usuariosDAO = usuariosDAO;
        }
        public void CerrarSesion()
        {
            throw new NotImplementedException();
        }

        public Usuario IniciarSesion(Usuario usuario)
        {
            bool usuarioValidado = usuariosDAO.ValidarUsuarioYContrasenaCorrecta(usuario);
            if (!usuarioValidado)
            {
                    throw new InvalidLoginException("Credenciales invalidas");
            }

            Usuario usuarioEncontrado = usuariosDAO.ObtenerPorEmail(usuario.Email);
            return usuarioEncontrado;
        }
    }
}
