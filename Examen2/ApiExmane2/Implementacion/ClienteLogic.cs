using ApiExmane2.Context;
using ApiExmane2.Contratos;
using Examen.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ApiExmane2.Contratos.IClienteLogic;

namespace ApiExmane2.Implementacion
{
    public class ClienteLogic : IClienteLogic
    {
        private readonly Contexto contexto;
        public ClienteLogic(Contexto _contexto)
        {
            this.contexto = _contexto;
        }
        public async Task<bool> EliminarCliente(int IdCliente)
        {
            bool sw = false;
            Cliente? existe = await contexto.Clientes.FindAsync(IdCliente);
            if (existe != null)
            {
                var existeListaPedidos = await contexto.Pedidos.Where(x => x.IdCliente == existe.IdCliente).ToListAsync();
                if (existeListaPedidos != null)
                {
                    foreach (var pedido in existeListaPedidos)
                    {
                        var existeDetalle = await contexto.Detalles.Where(x => x.IdPedido == pedido.IdPedido).ToListAsync();
                        if (existeDetalle != null)
                        {
                            foreach (var detalle in existeDetalle)
                            {
                                contexto.Detalles.Remove(detalle);
                            }
                        }
                        contexto.Pedidos.Remove(pedido);
                    }
                }

                contexto.Clientes.Remove(existe);
                await contexto.SaveChangesAsync();
                sw = true;
            }
            return sw;
        }

        public async Task<bool> InsertarCliente(Cliente cliente)
        {
            bool sw = false;
            contexto.Clientes.Add(cliente);
            int response = await contexto.SaveChangesAsync();
            if (response == 1)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<List<Cliente>> ListarClientes()
        {
            var lista = await contexto.Clientes.ToListAsync();
            return lista;
        }
    }
}
