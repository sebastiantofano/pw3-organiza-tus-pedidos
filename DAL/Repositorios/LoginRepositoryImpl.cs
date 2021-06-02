using DAL.Helpers.Exceptions;
using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public class LoginRepositoryImpl : ILoginRepository
    {
        private readonly PedidosPW3Context pedidosPW3Context;

        public LoginRepositoryImpl(PedidosPW3Context pedidosPW3Context)
        {
            this.pedidosPW3Context = pedidosPW3Context;
        }
        public void CerrarSesion()
        {
            throw new NotImplementedException();
        }

        public Usuario IniciarSesion(Usuario usuario)
        {

            Usuario usuarioValidado = pedidosPW3Context.Usuarios.Where(x => x.Email == usuario.Email && x.Password == usuario.Password).FirstOrDefault();

            if (usuarioValidado != null)
            {
                throw new InvalidLoginException("Credenciales invalidas");
            }
            return usuarioValidado;
            /*bool usuarioValidado = usuariosDAO.ValidarUsuarioYContrasenaCorrecta(usuario);
            if (!usuarioValidado)
            {
                throw new InvalidLoginException("Credenciales invalidas");
            }

            Usuario usuarioEncontrado = usuariosDAO.ObtenerPorEmail(usuario.Email);
            return usuarioEncontrado*/
        }
    }
}
