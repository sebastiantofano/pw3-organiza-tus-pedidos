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
    /* Esta clase sera la que haga consultas contra la base de datos */
    public class ClientesDAOImpl : IClientesDAO
    {
       

        public Cliente ObtenerPorId(int id)
        {
            return ClientesDatos.listaClientes.Find(i => i.IdCliente == id);
        }

        public List<Cliente> ObtenerTodos()
        {
            return ClientesDatos.listaClientes;
        }

        public void Insertar(Cliente cliente)
        {
            int idUltimoCliente = ClientesDatos.listaClientes.Last().IdCliente;
            int IdnuevoCliente = idUltimoCliente + 1;
            cliente.IdCliente = IdnuevoCliente;
            ClientesDatos.listaClientes.Add(cliente);
        }

        public void Actualizar(Cliente cliente)
        {
            Cliente clienteEncontado = ClientesDatos.listaClientes.FirstOrDefault(x => x.IdCliente == cliente.IdCliente);
            clienteEncontado.Numero = cliente.Numero;
            clienteEncontado.Nombre = cliente.Nombre;
            clienteEncontado.FechaModificacion = DateTime.Today;
        }

        public void EliminarPorId(int id, string who)
        {
            Cliente clienteEncontado = ClientesDatos.listaClientes.FirstOrDefault(x => x.IdCliente == id);
            clienteEncontado.FechaBorrado = DateTime.Today;
            clienteEncontado.BorradoPor = "Alguien lo borró";
        }

        public void Eliminar(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}

