using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos
{
    public class ArticulosAccesoDatos : IAccesoDatos<Articulo>
    {
        private static Articulo art1 = new Articulo { IdArticulo = 1, Codigo = "COD_01", Descripcion = "Descripción del Articulo 1", FechaCreacion = new DateTime(2021, 10, 24), 
            CreadorPor = "Sebastian Tofano", FechaModificacion = new DateTime(2021, 11, 02), ModificadoPor = "Pepito Perez"};
        private static Articulo art2 = new Articulo { IdArticulo = 2, Codigo = "COD_02", Descripcion = "Descripción del Articulo 2", FechaBorrado = new DateTime(2021, 12, 24) };
        private static Articulo art3 = new Articulo { IdArticulo = 3, Codigo = "COD_03", Descripcion = "Descripción del Articulo 3" };
        private static Articulo art4 = new Articulo { IdArticulo = 4, Codigo = "COD_04", Descripcion = "Descripción del Articulo 4" , FechaBorrado = new DateTime(2021, 12, 24) };
        private static Articulo art5 = new Articulo { IdArticulo = 5, Codigo = "COD_05", Descripcion = "Descripción del Articulo 5" };
        private static Articulo art6 = new Articulo { IdArticulo = 6, Codigo = "COD_06", Descripcion = "Descripción del Articulo 6" };
        private static Articulo art7 = new Articulo { IdArticulo = 7, Codigo = "COD_07", Descripcion = "Descripción del Articulo 7", FechaBorrado = new DateTime(2021, 12, 24) };
        private static Articulo art8 = new Articulo { IdArticulo = 8, Codigo = "COD_08", Descripcion = "Descripción del Articulo 8" };


        public static readonly List<Articulo> listaArticulos = new() { art1, art2, art3 ,art4, art5 , art6, art7, art8 };

        public Articulo ObtenerPorId(int id)
        {
            return listaArticulos.Find(i => i.IdArticulo == id);
        }

        public List<Articulo> ObtenerTodos()
        {
            return listaArticulos;
        }

        public void Insertar(Articulo articulo)
        {
            listaArticulos.Add(articulo);
        }

        public void Actualizar(Articulo entity)
        {
            Articulo articuloEncontrado = listaArticulos.FirstOrDefault(x => x.IdArticulo == entity.IdArticulo);
            articuloEncontrado.Codigo = entity.Codigo;
            articuloEncontrado.Descripcion = entity.Descripcion;
            
        }
    }
}
