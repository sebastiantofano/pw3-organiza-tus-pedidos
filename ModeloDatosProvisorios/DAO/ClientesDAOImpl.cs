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
            throw new NotImplementedException();
        }

        public List<Cliente> ObtenerTodos()
        {
            return ClientesDatos.listaClientes;
        }

        public void Insertar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void Actualizar(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public void EliminarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}

