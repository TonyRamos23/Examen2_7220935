using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.DTOS.Reportes
{
    public class Reporte1
    {
        public string NombreCliente { get; set; } = null!;
        public DateTime FechaPedido { get; set; }
        public string NombreProducto { get; set; } = null!;
        public double Subtotal { get; set; }
    }
}
