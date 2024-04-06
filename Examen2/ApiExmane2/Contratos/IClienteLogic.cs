using Examen.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.Contratos
{
    public interface IClienteLogic
    {
        IEnumerable<ReporteItem> ObtenerReporte();
        public Task<bool> InsertarCliente(Cliente cliente);
        public Task<bool> ModificarCliente(Cliente cliente, int id);
        public Task<bool> EliminarCliente(int id);
        public Task<List<Cliente>> ListarClienteTodos();
        public Task<Cliente> ObtenerClienteById(int id);



        public class ReporteItem
        {
            public string NombreCliente { get; set; }
            public DateTime FechaPedido { get; set; }
            public string NombreProducto { get; set; }
            public decimal Subtotal { get; set; }
        }
    }
}
