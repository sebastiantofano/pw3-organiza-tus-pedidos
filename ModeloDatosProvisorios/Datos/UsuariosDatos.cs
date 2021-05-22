using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos
{
    /* Esta clase sera la que haga consultas contra la base de datos */
    public class UsuariosDatos
    {
        private static Usuario usu1 = new() { IdUsuario = 1, EsAdmin = true, Email = "usuario1@gmail.com", Password = "usuario1" };
        private static Usuario usu2 = new() { IdUsuario = 2, EsAdmin = false, Email = "usuario2@gmail.com", Password = "usuario2" };
        private static Usuario usu3 = new Usuario { IdUsuario = 3, EsAdmin = true, Email = "usuario3@gmail.com", Password = "usuario3" };
        private static Usuario usu4 = new Usuario { IdUsuario = 4, EsAdmin = false, Email = "usuario4@gmail.com", Password = "usuario4" };
        private static Usuario usu5 = new Usuario { IdUsuario = 5, EsAdmin = true, Email = "usuario5@gmail.com", Password = "usuario5" };
        private static Usuario usu6 = new Usuario { IdUsuario = 6, EsAdmin = false, Email = "usuario6@gmail.com", Password = "usuario6" };



        public static readonly List<Usuario> listaUsuarios = new() { usu1, usu2, usu3, usu4, usu5, usu6 };
    }
}
