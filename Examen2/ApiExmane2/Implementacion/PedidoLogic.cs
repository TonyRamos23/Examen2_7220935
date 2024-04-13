using ApiExmane2.Contratos;
using ApiExmane2.DTOS.Endpoint;
using ApiExmane2.DTOS.Reportes;
using Examen.Shared;
using ApiExmane2.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiExmane2.Implementacion
{
    public class PedidoLogic : IPedidoLogic
    {
        private readonly Contexto contexto;

        public PedidoLogic(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public async Task<bool> InsertarPedido(PedidoDetalleActualizar pedido)
        {
            bool sw = false;
            Pedido ped = new Pedido();
            ped.IdCliente = pedido.IdCliente;
            ped.Fecha = pedido.Fecha;
            ped.Total = pedido.Total;
            ped.Estado = pedido.Estado;
            ped.Cliente = null;
            ped.Detalles = null;
            contexto.Pedidos.Add(ped);
            contexto.SaveChanges();
            var idPedido = ped.IdPedido;
            foreach (var item in pedido.Detalles)
            {
                Detalle detalle = new Detalle();
                detalle.IdPedido = idPedido;
                detalle.IdProducto = item.IdProducto;
                detalle.Cantidad = item.Cantidad;
                detalle.Precio = item.Precio;
                detalle.Subtotal = item.Subtotal;
                detalle.Producto = null;
                detalle.Pedido = null;
                contexto.Detalles.Add(detalle);
            }
            int response = await contexto.SaveChangesAsync();
            if (response >= 1)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<List<Pedido>> ListarPedidos()
        {
            var lista = await contexto.Pedidos.ToListAsync();
            return lista;
        }

        public Task<List<Reporte1>> ListarReporte1()
        {
            throw new NotImplementedException();
        }

        public Task<List<Reporte2>> ListarReporte2()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ModificarPedido(PedidoDetalleActualizar pedido, int id)
        {
            bool sw = false;
            Pedido? existe = await contexto.Pedidos.FindAsync(id);
            if (existe != null)
            {
                existe.IdCliente = pedido.IdCliente;
                existe.Fecha = pedido.Fecha;
                existe.Total = pedido.Total;
                existe.Estado = pedido.Estado;
                contexto.SaveChanges();
                foreach (var item in pedido.Detalles)
                {
                    Detalle? existeDet = await contexto.Detalles.FindAsync(item.Id);
                    if (existeDet != null)
                    {
                        existeDet.IdProducto = item.IdProducto;
                        existeDet.Cantidad = item.Cantidad;
                        existeDet.Precio = item.Precio;
                        existeDet.Subtotal = item.Subtotal;
                    }


                }
                await contexto.SaveChangesAsync();
                sw = true;
            }
            return sw;
        }

        public async Task<Pedido> ObtenerPedidoById(int id)
        {
            Pedido? pedido = await contexto.Pedidos.FirstOrDefaultAsync(x => x.IdPedido == id);
            return pedido!;
        }
    }
}
