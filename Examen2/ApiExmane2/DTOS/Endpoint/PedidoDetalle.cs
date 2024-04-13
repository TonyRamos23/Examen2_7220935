using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.DTOS.Endpoint
{
    public class PedidoDetalle
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Subtotal { get; set; }
    }
}
