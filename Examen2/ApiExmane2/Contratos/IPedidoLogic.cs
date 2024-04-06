using Examen.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.Contratos
{
    public interface IPedidoLogic
    {
        public Task<bool> InsertarPedido(Pedido pedido);
        public Task<bool> ModificarPedido(Pedido pedido, int id);
        public Task<bool> EliminarPedido(int id);
        public Task<List<Pedido>> ListarPedidoTodos();
        public Task<Pedido> ObtenerPedidoById(int id);
    }
}
