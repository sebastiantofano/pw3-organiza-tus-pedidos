using DAL.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ResponseObjects
{
    public class PedidoResponse
    {

        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public string Estado { get; set; }
        public DateTime FechaModificacion { get; set; }
        public UsuarioResponse ModificadoPor { get; set; }
        public List<ArticuloPedidoResponse> Articulos { get; set; }



    }
}
