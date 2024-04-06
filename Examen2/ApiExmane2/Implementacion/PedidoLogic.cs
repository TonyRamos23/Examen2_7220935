using ApiExmane2.Contratos;
using Examen.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.Implementacion
{
    public class PedidoLogic : IPedidoLogic
    {
        private readonly Contexto contexto;

        public PedidoLogic(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task<bool> EliminarPedido(int id)
        {
            bool sw = false;
            Pedido existe = await contexto.Pedidos.FindAsync(id);
            if (existe != null)
            {
                contexto.Pedidos.Remove(existe);
                await contexto.SaveChangesAsync();
                sw = true;
            }
            return sw;
        }

        public async Task<bool> InsertarPedido(Pedido pedido)
        {
            bool sw = false;
            contexto.Pedidos.Add(pedido);
            int response = await contexto.SaveChangesAsync();
            if (response == 1)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<List<Pedido>> ListarPedidoTodos()
        {
            var lista = await contexto.Pedidos.ToListAsync();
            return lista;
        }

        public async Task<bool> ModificarPedido(Pedido pedido, int id)
        {
            bool sw = false;
            Pedido edit = await contexto.Pedidos.FindAsync();
            if (edit != null)
            {
                edit.Fecha = pedido.Fecha;
                edit.Total = pedido.Total;
                edit.Estado = pedido.Estado;
                await contexto.SaveChangesAsync();
                sw = true;
            }
            return sw;
        }

        public async Task<Pedido> ObtenerPedidoById(int id)
        {
            Pedido pedido = await contexto.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == id);
            return pedido;
        }
    }
}
