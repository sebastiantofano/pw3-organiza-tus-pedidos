using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloDatosProvisorios.Repositorios.Interfaces;
using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Datos.Repositorios;
using ModeloDatosProvisorios.DAO;
using ModeloDatosProvisorios.DAO.Interfaces;

namespace ModeloDatosProvisorios.Repositorios
{
    public class UsuariosRepositoryImpl : BaseRepositoryImpl<Usuario>, IUsuariosRepository
    {
        private readonly IUsuariosDAO usuariosDAO; 
        public UsuariosRepositoryImpl(IUsuariosDAO usuariosDAO) : base(usuariosDAO)
        {
            this.usuariosDAO = usuariosDAO;
        }

        public bool ValidarEmailExistente(string email)
        {
            bool EsUsuarioExistente = usuariosDAO.ValidarEmailExistente(email);
            return EsUsuarioExistente;

        }
    }
}
