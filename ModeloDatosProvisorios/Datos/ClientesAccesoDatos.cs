using ModeloDatosProvisorios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDatosProvisorios.Datos
{
    public class ClientesAccesoDatos : IAccesoDatos<Cliente>
    {
        private static Cliente cli1 = new Cliente { IdCliente = 1, Numero = 1, Nombre = "Nombre Nombre Apellido 1", CUIT = 111111111111 };
        private static Cliente cli2 = new Cliente { IdCliente = 2, Numero = 2, Nombre = "Nombre Nombre Apellido 2", CUIT = 222222222222 };
        private static Cliente cli3 = new Cliente { IdCliente = 3, Numero = 3, Nombre = "Nombre Nombre Apellido 3", CUIT = 333333333333, FechaBorrado = new DateTime(2021, 12, 24) };
        private static Cliente cli4 = new Cliente { IdCliente = 4, Numero = 4, Nombre = "Nombre Nombre Apellido 4", CUIT = 444444444444 };
        private static Cliente cli5 = new Cliente { IdCliente = 5, Numero = 5, Nombre = "Nombre Nombre Apellido 5", CUIT = 555555555555 };
        private static Cliente cli6 = new Cliente { IdCliente = 6, Numero = 6, Nombre = "Nombre Nombre Apellido 6", CUIT = 666666666666 };
        private static Cliente cli7 = new Cliente { IdCliente = 7, Numero = 7, Nombre = "Nombre Nombre Apellido 7", CUIT = 777777777777 , FechaBorrado = new DateTime(2021, 12, 24) };
        private static Cliente cli8 = new Cliente { IdCliente = 8, Numero = 8, Nombre = "Nombre Nombre Apellido 8", CUIT = 888888888888 };
        private static Cliente cli9 = new Cliente { IdCliente = 9, Numero = 9, Nombre = "Nombre Nombre Apellido 9", CUIT = 999999999999 , FechaBorrado = new DateTime(2021, 12, 24) };


        public static readonly List<Cliente> listaClientes = new() { cli1, cli2, cli3, cli4, cli5, cli6, cli7, cli8, cli9 };

        public Cliente ObtenerPorId(int id)
        {
            return listaClientes.Find(i => i.IdCliente == id);
        }

        public List<Cliente> ObtenerTodos()
        {
            return listaClientes;
        }

        public void Insertar(Cliente cliente)
        {
            listaClientes.Add(cliente);
        }

        public void Actualizar(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}

