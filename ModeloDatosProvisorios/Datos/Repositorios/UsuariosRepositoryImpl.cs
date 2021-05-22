using ModeloDatosProvisorios.Datos.Repositorios.Interfaces;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos.Repositorios
{
    public class UsuariosRepositoryImpl : BaseRepositoryImpl<Usuario> , IUsuariosRepository
    {
        public UsuariosRepositoryImpl() : base(new UsuariosDatos())
        {

        }
    }
}
