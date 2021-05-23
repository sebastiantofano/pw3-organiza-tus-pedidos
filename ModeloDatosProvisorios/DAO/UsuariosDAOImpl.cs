﻿using ModeloDatosProvisorios.DAO.Interfaces;
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
            throw new NotImplementedException();
        }

        public void EliminarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Usuario usuario)
        {
            throw new NotImplementedException();
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
    }
}
