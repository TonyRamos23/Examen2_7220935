﻿using Examen.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.Contratos
{
    public interface IDetalleLogic
    {
        public Task<bool> InsertarDetalle(Detalle detalle);
        public Task<bool> EliminarDetalle(int id);
        public Task<List<Detalle>> ListarDetalle();
    }
}
