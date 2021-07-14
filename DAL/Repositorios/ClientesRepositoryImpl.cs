using DAL.Modelos;
using DAL.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
    public class ClientesRepositoryImpl : BaseRepositoryImpl<Cliente>, IClientesRepository
    {
        private readonly PedidosPW3Context _pedidosPW3Context;
        public ClientesRepositoryImpl(PedidosPW3Context pedidosPW3Context) : base(pedidosPW3Context) // IoC en StartUp.cs
        {
            _pedidosPW3Context = pedidosPW3Context;
        }

        public bool ValidarEmailExistente(string email)
        {

            Cliente clienteExistente = _pedidosPW3Context.Clientes.Where(o => o.Email == email).FirstOrDefault();
            if (clienteExistente == null || clienteExistente.Email == null)
            {
                return false;
            }
            return true;

        }

        public List<Cliente> FiltrarPorNombre(string cadena)
        {
            IQueryable<Cliente> matches = from c in _pedidosPW3Context.Clientes
                                          where c.Nombre.Contains(cadena)
                                          select c;

            return matches.ToList();
            //return (List<Cliente>)_pedidosPW3Context.Clientes.Where(c => EF.Functions.Like(c.Nombre, cadena));
        }

        public List<Cliente> ObtenerTodosOrdenAnalfabetico()
        {
            return _pedidosPW3Context.Clientes.OrderBy(o => o.Nombre).ToList();
        }

        public bool ValidarNumeroExistente(int numero)
        {
            Cliente clienteExistente = _pedidosPW3Context.Clientes.Where(o => o.Numero == numero).FirstOrDefault();
            if (clienteExistente == null)
            {
                return false;
            }
            return true;
        }
    }
}
