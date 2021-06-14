using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios.Interfaces
{
    public interface IPedidosRepository : IBaseRepository<Pedido> // Esta interface hereda todos los metodos del la interface del repositorio base
    {
        Dictionary<Articulo, int> ObtenerArticulosYCantidadesDelPedido(int idPedido);
    }
}
