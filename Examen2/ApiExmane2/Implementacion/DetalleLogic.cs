using ApiExmane2.Contratos;
using Examen.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.Implementacion
{
    public class DetalleLogic : IDetalleLogic
    {
        public Task<bool> EliminarDetalle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertarDetalle(Detalle detalle)
        {
            throw new NotImplementedException();
        }

        public Task<List<Detalle>> ListarDetalleTodos()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ModificarDetalle(Detalle detalle, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Detalle> ObtenerDetalleById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
