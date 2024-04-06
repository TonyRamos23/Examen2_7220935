using ApiExmane2.Contratos;
using Examen.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.Implementacion
{
    public class ProductoLogic : IProductoLogic
    {
        public Task<bool> EliminarProducto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertarProducto(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> ListarProductoTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModificarProducto(Producto producto, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> ObtenerProductoById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
