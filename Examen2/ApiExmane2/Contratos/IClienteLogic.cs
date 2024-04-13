using Examen.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiExmane2.Contratos
{
    public interface IClienteLogic
    {
        public Task<bool> InsertarCliente(Cliente cliente);
        public Task<bool> EliminarCliente(int id);
        public Task<List<Cliente>> ListarClientes();

    }
}
