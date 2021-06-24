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

            Usuario usuarioExistente = _pedidosPW3Context.Usuarios.Where(o => o.Email == email).FirstOrDefault();
            if (usuarioExistente == null)
            {
                return false;
            }

            return true;

        }

        public override void Actualizar(Usuario usuario)
        {
            // Pasa de estar en estado Detached a Unchanged
            _pedidosPW3Context.Set<Usuario>().Attach(usuario);

            //Specify the fields that should be updated.
            _pedidosPW3Context.Entry(usuario).Property(x => x.EsAdmin).IsModified = true;
            _pedidosPW3Context.Entry(usuario).Property(x => x.Email).IsModified = true;
            _pedidosPW3Context.Entry(usuario).Property(x => x.Password).IsModified = true;
            _pedidosPW3Context.Entry(usuario).Property(x => x.Nombre).IsModified = true;
            _pedidosPW3Context.Entry(usuario).Property(x => x.Apellido).IsModified = true;
            _pedidosPW3Context.Entry(usuario).Property(x => x.FechaNacimiento).IsModified = true;
            _pedidosPW3Context.Entry(usuario).Property(x => x.FechaUltLogin).IsModified = true;
            _pedidosPW3Context.Entry(usuario).Property(x => x.ModificadoPor).IsModified = true;
            _pedidosPW3Context.Entry(usuario).Property(x => x.FechaModificacion).IsModified = true;

            _pedidosPW3Context.SaveChanges();
        }

        public List<Usuario> ObtenerTodosPorIdUsuarioOPorEmail(int idUsuario, string email)
        {
            return _pedidosPW3Context.Usuarios.Where(o => (idUsuario == 0 || o.IdUsuario == idUsuario) && (string.IsNullOrEmpty(email) || o.Email == email)).ToList();
        }
    }
}
