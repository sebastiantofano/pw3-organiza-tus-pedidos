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

namespace ModeloDatosProvisorios.Repositorios
{
    public class UsuariosRepositoryImpl : BaseRepositoryImpl<Usuario>, IUsuariosRepository
    {
        public UsuariosRepositoryImpl() : base(new UsuariosDaoImpl())
        {

        }
    }
}
