using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.DTOS.Endpoint
{
    public class PedidoDetalleActualizar
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Estado { get; set; } = null!;
        public virtual List<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
    }
}
