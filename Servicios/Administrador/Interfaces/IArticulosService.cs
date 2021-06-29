using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Administrador.Interfaces
{ 
    public interface IArticulosService : IBaseService<Articulo> // Esta interface hereda el CRUD de Servicio Base
    {
        List<Articulo> FiltrarPorDescripcion(string cadena);
    }
}
