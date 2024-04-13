using Examen.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.Contratos
{
    public interface IProductoLogic
    {
        public Task<bool> InsertarProducto(Producto producto);
        public Task<List<Producto>> ListarProductos();
        public Task<List<Producto>> ListarProductosFechas(DateTime fecha1, DateTime fecha2);
    }
}
