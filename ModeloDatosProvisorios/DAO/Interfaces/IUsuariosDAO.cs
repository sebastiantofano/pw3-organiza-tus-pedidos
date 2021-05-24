using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.DAO.Interfaces
{
    public interface IUsuariosDAO : IDAO<Usuario>
    {
        bool ValidarUsuarioYContrasenaCorrecta(Usuario usuario);

        Usuario ObtenerPorEmail(string email);

        bool ValidarEmailExistente(string email);
    }
}
