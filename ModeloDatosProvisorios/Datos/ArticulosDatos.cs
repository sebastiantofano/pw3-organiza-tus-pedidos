using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos
{
    public static class ArticulosDatos 
    {
        static Articulo art1 = new Articulo { IdArticulo = 1, Codigo = "COD_01", Descripcion = "Descripción del Articulo 1" };
        static Articulo art2 = new Articulo { IdArticulo = 2, Codigo = "COD_02", Descripcion = "Descripción del Articulo 2", FechaBorrado = new DateTime(2021, 12, 24) };
        static Articulo art3 = new Articulo { IdArticulo = 3, Codigo = "COD_03", Descripcion = "Descripción del Articulo 3" };
        static Articulo art4 = new Articulo { IdArticulo = 3, Codigo = "COD_04", Descripcion = "Descripción del Articulo 4" , FechaBorrado = new DateTime(2021, 12, 24) };
        static Articulo art5 = new Articulo { IdArticulo = 3, Codigo = "COD_05", Descripcion = "Descripción del Articulo 5" };


        public static readonly List<Articulo> listaArticulos = new() { art1, art2, art3 ,art4, art5};

       

    }
}
