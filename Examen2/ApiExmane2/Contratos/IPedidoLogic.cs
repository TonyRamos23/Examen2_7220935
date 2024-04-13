using ApiExmane2.DTOS.Endpoint;
using ApiExmane2.DTOS.Reportes;
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
        public Task<bool> InsertarPedido(PedidoDetalleActualizar pedido);
        public Task<bool> ModificarPedido(PedidoDetalleActualizar pedido, int id);
        public Task<List<Pedido>> ListarPedidos();
        public Task<Pedido> ObtenerPedidoById(int id);
        public Task<List<Reporte1>> ListarReporte1();
        public Task<List<Reporte2>> ListarReporte2();
    }
}
