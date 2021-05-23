using ModeloDatosProvisorios.DAO.Interfaces;
using ModeloDatosProvisorios.Datos;
using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.DAO
{  
   /* Clase que se conectará con la base de datos*/
    public class ArticulosDAOImpl : IArticulosDAO
    {
        public ArticulosDAOImpl()
        {

        }

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

        public void Actualizar(Articulo articulo)
        {
            Articulo articuloEncontrado = ArticulosDatos.ListaArticulos.FirstOrDefault(x => x.IdArticulo == articulo.IdArticulo);
            articuloEncontrado.Codigo = articulo.Codigo;
            articuloEncontrado.Descripcion = articulo.Descripcion;
            articuloEncontrado.FechaModificacion = DateTime.Today;
        }

        public void Eliminar(Articulo articulo)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(int id)
        {
            Articulo articuloEncontrado = ArticulosDatos.ListaArticulos.FirstOrDefault(x => x.IdArticulo == id);
            articuloEncontrado.FechaBorrado = DateTime.Today;
            articuloEncontrado.BorradoPor = "Alguien lo borró";
        }

        public bool ValidarCodigoExistente(string codigo)
        {
            Articulo articulo = ArticulosDatos.ListaArticulos.FirstOrDefault(x => x.Codigo.Equals(codigo));
            return (articulo != null) ? true : false;

        }
    }
}
