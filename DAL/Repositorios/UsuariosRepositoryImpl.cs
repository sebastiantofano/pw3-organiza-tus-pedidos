using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositorios.Interfaces;
using DAL.Modelos;

namespace DAL.Repositorios
{
    public class UsuariosRepositoryImpl : BaseRepositoryImpl<Usuario>, IUsuariosRepository
    {
        private readonly PedidosPW3Context _pedidosPW3Context;
        public UsuariosRepositoryImpl(PedidosPW3Context pedidosPW3Context) : base(pedidosPW3Context) // IoC en StartUp.cs
        {
            _pedidosPW3Context = pedidosPW3Context;
        }

        public bool ValidarEmailExistente(string email)
        {
            /*bool EsUsuarioExistente = usuariosDAO.ValidarEmailExistente(email);
            return EsUsuarioExistente;*/


            Usuario usuarioExistente = _pedidosPW3Context.Usuarios.Where(o => o.Email == email).FirstOrDefault();
            if (usuarioExistente == null)
            {
                return false;
            }

            return true;

        }
    }
}
