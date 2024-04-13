using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Examen.Shared
{
    public class Detalle
    {
        [Key]
       public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set;}
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Subtotal { get; set;}

        [ForeignKey("IdPedido")]
        public virtual Pedido? Pedido { get; set; } = null!;
        [ForeignKey("IdProducto")]
        public virtual Producto? Producto { get; set; } = null!;

    }
}
