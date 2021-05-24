using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Repositorios.Interfaces
{
    public interface IUsuariosRepository : IBaseRepository<Usuario> // Esta interface hereda todos los metodos del la interface del repositorio base
    {
        bool ValidarEmailExistente(string email);
    }
}
