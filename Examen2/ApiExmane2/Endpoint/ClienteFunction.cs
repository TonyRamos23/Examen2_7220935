using ApiExmane2.Contratos;
using Examen.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;

namespace ApiExmane2.Endpoint
{
    public class ClienteFunction
    {
        private readonly ILogger<ClienteFunction> _logger;
        private readonly IClienteLogic clienteLogic;

        public ClienteFunction(ILogger<ClienteFunction> logger)
        {
            _logger = logger;
            this.clienteLogic = clienteLogic;
        }

        [Function("ClienteFunction")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }

        [Function("ListarCliente")]
        [OpenApiOperation("Listarspec", "ListarCliente", Description = "Sirve para listar todos los clientes")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Cliente>), Description = "Mostrara una Lista de Clientes")]
        public async Task<HttpResponseData> ListarCliente([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ListarCliente")] HttpRequestData req)
        {

            try
            {
                var listaClientes = clienteLogic.ListarClientes();
                var respuesta = req.CreateResponse(HttpStatusCode.OK);
                await respuesta.WriteAsJsonAsync(listaClientes.Result);
                return respuesta;
            }
            catch (Exception e)
            {

                var error = req.CreateResponse(HttpStatusCode.InternalServerError);
                await error.WriteAsJsonAsync(e.Message);
                return error;
            }
        }

        [Function("InsertarCliente")]
        [OpenApiOperation("Insertarspec", "InsertarCliente", Description = "Sirve para Insertar un Cliente")]
        [OpenApiRequestBody("application/json", typeof(Cliente), Description = "Cliente modelo")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Cliente), Description = "Mostrara el Cliente Creado")]
        public async Task<HttpResponseData> InsertarCliente([HttpTrigger(AuthorizationLevel.Function, "post", Route = "InsertarCliente")] HttpRequestData req)
        {
            try
            {
                var cliente = await req.ReadFromJsonAsync<Cliente>() ?? throw new Exception("Debe ingresar un Cliente con todos sus datos");
                bool seGuardo = await clienteLogic.InsertarCliente(cliente);
                if (seGuardo)
                {
                    var respuesta = req.CreateResponse(HttpStatusCode.OK);
                    return respuesta;
                }
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {

                var error = req.CreateResponse(HttpStatusCode.InternalServerError);
                await error.WriteAsJsonAsync(e.Message);
                return error;
            }
        }

        [Function("EliminarCliente")]
        [OpenApiOperation("Eliminarspec", "EliminarCliente", Description = "Sirve para Eliminar un Cliente")]
        [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        public async Task<HttpResponseData> EliminarCliente([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "EliminarCliente/{id}")] HttpRequestData req, int id)
        {

            try
            {
                bool seElimino = await clienteLogic.EliminarCliente(id);
                if (seElimino)
                {
                    var respuesta = req.CreateResponse(HttpStatusCode.OK);
                    return respuesta;
                }
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {

                var error = req.CreateResponse(HttpStatusCode.InternalServerError);
                await error.WriteAsJsonAsync(e.Message);
                return error;
            }
        }
    }
}
