using ModeloDatosProvisorios.DAO.Interfaces;
using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.DAO
{  
    /* Esta clase simula ser una tabla de la base de datos */
    public class ArticulosDAOImpl : IArticulosDAO
    {
        
        public Articulo ObtenerPorId(int id)
        {
            return ArticulosDatos.ListaArticulos.Find(i => i.IdArticulo == id);
        }

        public List<Articulo> ObtenerTodos()
        {
            return ArticulosDatos.ListaArticulos;
        }

        public void Insertar(Articulo articulo)
        {
            int idUltimoArticulo = ArticulosDatos.ListaArticulos.Last().IdArticulo;
            int IdnuevoArticulo = idUltimoArticulo + 1;
            articulo.IdArticulo = IdnuevoArticulo;
            ArticulosDatos.ListaArticulos.Add(articulo);
        }

        public void Actualizar(Articulo entity)
        {
            Articulo articuloEncontrado = ArticulosDatos.ListaArticulos.FirstOrDefault(x => x.IdArticulo == entity.IdArticulo);
            articuloEncontrado.Codigo = entity.Codigo;
            articuloEncontrado.Descripcion = entity.Descripcion;
            articuloEncontrado.FechaModificacion = DateTime.Today;
        }

        public void Eliminar(Articulo entity)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(int id)
        {
            Articulo articuloEncontrado = ArticulosDatos.ListaArticulos.FirstOrDefault(x => x.IdArticulo == id);
            articuloEncontrado.FechaBorrado = DateTime.Today;
            articuloEncontrado.BorradoPor = "Alguien lo borró";
        }




    }
}
