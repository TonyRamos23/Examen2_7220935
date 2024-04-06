using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ApiExmane2.Endpoint
{
    public class DetalleFunction
    {
        private readonly ILogger<DetalleFunction> _logger;

        public DetalleFunction(ILogger<DetalleFunction> logger)
        {
            _logger = logger;
        }

        [Function("DetalleFunction")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}
