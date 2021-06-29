using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPedidosAPI.ResponseObjects
{
    public class ClienteResponse
    {
        public int IdCliente { get; set; }
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public long Telefono { get; set; }

        public ClienteResponse(int idCliente, string numero, string nombre, string direccion, long telefono)
        {
            IdCliente = idCliente;
            Numero = numero;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
