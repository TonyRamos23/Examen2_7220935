using ApiExmane2.Context;
using ApiExmane2.Contratos;
using Examen.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.Implementacion
{
    public class ProductoLogic : IProductoLogic
    {
        private readonly Contexto contexto;

        public ProductoLogic(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task<bool> InsertarProducto(Producto producto)
        {
            bool sw = false;
            contexto.Productos.Add(producto);
            int response = await contexto.SaveChangesAsync();
            if (response == 1)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<List<Producto>> ListarProductos()
        {
            var lista = await contexto.Productos.ToListAsync();
            return lista;
        }

        public async Task<List<Producto>> ListarProductosFechas(DateTime fecha1, DateTime fecha2)
        {
            var lista = await contexto.Detalles
            .Where(x => x.Pedido!.Fecha >= fecha1 && x.Pedido.Fecha <= fecha2)
            .OrderByDescending(y => y.Cantidad)
            .Select(prod => new Producto
            {
                IdProducto = prod.Producto!.IdProducto,
                Nombre = prod.Producto.Nombre
            })
            .ToListAsync();
            return lista;
        }
    }
}
