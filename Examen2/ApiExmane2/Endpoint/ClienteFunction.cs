using ApiExmane2.Contratos;
using ApiExmane2.Implementacion;
using Examen.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiExmane2.Endpoint
{
    public class ClienteFunction
    {
        
        private readonly ILogger<ClienteFunction> _logger;
        private readonly IClienteLogic clienteLogic;

        public ClienteFunction(ILogger<ClienteFunction> logger, IClienteLogic clienteLogic)
        {
            _logger = logger;
            this.clienteLogic = clienteLogic;
          
        }

        [Function("Reporte")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequestData req,
            FunctionContext executionContext)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var reporte = clienteLogic.ObtenerReporte();

            return new OkObjectResult(reporte);
        }
    }
}
