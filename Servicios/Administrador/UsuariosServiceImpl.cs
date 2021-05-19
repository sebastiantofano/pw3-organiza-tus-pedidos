using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Modelos;
using Servicios.Administrador.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Administrador
{
    public class UsuariosServiceImpl : BaseServiceImpl<Usuario>, IUsuariosServices
    {
        public UsuariosServiceImpl(IAccesoDatos<Usuario> entity) : base(entity) // CAMBIAR ESTO, ESTO ES POR DEFECTO
        {
        }
    }
}
