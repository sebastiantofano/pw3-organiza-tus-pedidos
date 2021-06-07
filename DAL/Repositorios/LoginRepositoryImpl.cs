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
        private readonly PedidosPW3Context _pedidosPW3Context;

        public LoginRepositoryImpl(PedidosPW3Context pedidosPW3Context) // IoC en StartUp.cs
        {
            _pedidosPW3Context = pedidosPW3Context;
        }
        public void CerrarSesion()
        {
            throw new NotImplementedException();
        }

        public Usuario IniciarSesion(Usuario usuario)
        {
            Usuario usuarioBuscado = _pedidosPW3Context.Usuarios.Where(x => x.Email == usuario.Email && x.Password == usuario.Password).FirstOrDefault(); //TODO
            return usuarioBuscado ?? null ; // Si encuentra al usuario devuelve al usuario, sino devuelve null
        }
    }
}
