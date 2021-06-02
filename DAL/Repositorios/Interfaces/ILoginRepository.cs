using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios.Interfaces
{
    public interface ILoginRepository
    {
        Usuario IniciarSesion(Usuario usuario);
        void CerrarSesion();
    }
}
