using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ApiExmane2.Endpoint
{
    public class PedidoFunction
    {
        private readonly ILogger<PedidoFunction> _logger;

        public PedidoFunction(ILogger<PedidoFunction> logger)
        {
            _logger = logger;
        }

        [Function("PedidoFunction")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
