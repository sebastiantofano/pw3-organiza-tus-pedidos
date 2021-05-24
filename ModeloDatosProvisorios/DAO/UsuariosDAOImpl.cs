using ModeloDatosProvisorios.DAO.Interfaces;
using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.DAO
{
    /* Esta clase simula ser una tabla de la base de datos */
    public class UsuariosDAOImpl : IUsuariosDAO
    {


        public void Actualizar(Usuario usuario)
        {
            Usuario usuarioEncontrado = UsuariosDatos.listaUsuarios.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);
            usuarioEncontrado.Nombre = usuario.Nombre ?? usuarioEncontrado.Nombre;
            usuarioEncontrado.Apellido = usuario.Apellido ?? usuarioEncontrado.Apellido;
            usuarioEncontrado.Email = usuario.Email ?? usuarioEncontrado.Email;
            usuarioEncontrado.FechaNacimiento = usuario.FechaNacimiento ?? usuarioEncontrado.FechaNacimiento;
            usuarioEncontrado.EsAdmin = usuario.EsAdmin;
            usuarioEncontrado.FechaModificacion = DateTime.Today;
        }

        public void EliminarPorId(int id)
        {
            Usuario usuarioEncontrado = UsuariosDatos.listaUsuarios.FirstOrDefault(x => x.IdUsuario == id);
            usuarioEncontrado.FechaBorrado = DateTime.Today;
            usuarioEncontrado.BorradoPor = "Alguien lo borró";
        }

        public void Insertar(Usuario usuario)
        {
            int idUltimoUsuario = UsuariosDatos.listaUsuarios.Last().IdUsuario;
            int IdnuevoUsuario = idUltimoUsuario + 1;
            usuario.IdUsuario = IdnuevoUsuario;
            UsuariosDatos.listaUsuarios.Add(usuario);
        }

        public Usuario ObtenerPorId(int id)
        {
            return UsuariosDatos.listaUsuarios.Find(i => i.IdUsuario == id);
        }

        public List<Usuario> ObtenerTodos()
        {
            return UsuariosDatos.listaUsuarios;
        }

        public void Eliminar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool ValidarUsuarioYContrasenaCorrecta(Usuario usuario)
        {
            string email = usuario.Email;
            string contrasena = usuario.Password;

            Usuario usuarioEncontrado = UsuariosDatos.listaUsuarios.Find(o => o.Email.Equals(email) && o.Password.Equals(contrasena));
            return (usuarioEncontrado is not null );

        }

        public Usuario ObtenerPorEmail(string email)
        {
            Usuario usuarioEncontrado = UsuariosDatos.listaUsuarios.Find(o => o.Email.Equals(email) );
            return usuarioEncontrado;
        }

        public bool ValidarEmailExistente(string email)
        {
            Usuario usuario = UsuariosDatos.listaUsuarios.FirstOrDefault(x => x.Email.Equals(email));
            return (usuario != null) ? true : false;
        }
    }
}
