using ApiExmane2.Contratos;
using Examen.Shared;
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

        public ClienteLogic(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task<bool> EliminarCliente(int id)
        {
            bool sw = false;
            Cliente existe = await contexto.Clientes.FindAsync(id);
            if (existe != null)
            {
                contexto.Clientes.Remove(existe);
                await contexto.SaveChangesAsync();
                sw = true;
            }
            return sw;
        }

        public Task<bool> InsertarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> ListarClienteTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModificarCliente(Cliente cliente, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> ObtenerClienteById(int id)
        {
            throw new NotImplementedException();
        }


        private readonly IPedidoLogic _pedidoRepository;
        private readonly IProductoLogic _productoRepository;

        public ClienteLogic(IPedidoLogic pedidoRepository, IProductoLogic productoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _productoRepository = productoRepository;
        }
        public IEnumerable<IClienteLogic.ReporteItem> ObtenerReporte(Task<List<Pedido>> pedidos)
        {
            var pedidos = _pedidoRepository.ListarPedidoTodos(); // Método para obtener todos los pedidos
            var productos = _productoRepository.ListarProductoTodos(); // Método para obtener todos los productos

            // Lógica para generar el reporte
            var reporte = from Pedido in pedidos
                          from detalle in pedido.Detalles
                          join producto in productos on detalle.ProductoId equals producto.ProductoId
                          select new ReporteItem
                          {
                              NombreCliente = Pedido.Cliente.Nombre,
                              FechaPedido = Pedido.Fecha,
                              NombreProducto = producto.Nombre,
                              Subtotal = detalle.Cantidad * producto.Precio
                          };

            return reporte;
        }
    }
}
