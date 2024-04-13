using ApiExmane2.Contratos;
using ApiExmane2.DTOS.Endpoint;
using ApiExmane2.DTOS.Reportes;
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
    public class PedidoFunction
    {
        private readonly ILogger<PedidoFunction> _logger;
        private readonly IPedidoLogic pedidoLogic;

        public PedidoFunction(ILogger<PedidoFunction> logger)
        {
            _logger = logger;
            this.pedidoLogic = pedidoLogic;
        }

        [Function("InsertarPedido")]
        [OpenApiOperation("Insertarspec", "InsertarPedido", Description = "Sirve para Insertar un Pedido")]
        [OpenApiRequestBody("application/json", typeof(PedidoDetalleActualizar), Description = "Idioma modelo")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(PedidoDetalleActualizar), Description = "Mostrara el Pedido Creado")]
        public async Task<HttpResponseData> InsertarPedido([HttpTrigger(AuthorizationLevel.Function, "post", Route = "InsertarPedido")] HttpRequestData req)
        {

            try
            {
                var pedido = await req.ReadFromJsonAsync<PedidoDetalleActualizar>() ?? throw new Exception("Debe ingresar un Pedido con todos sus datos");
                bool seGuardo = await pedidoLogic.InsertarPedido(pedido);
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


        [Function("ListarReporte1")]
        [OpenApiOperation("Listarspec", "ListarReporte1", Description = "Sirve para listar todos los Reporte1")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Reporte1>), Description = "Mostrara una Lista de Pedidos")]
        public async Task<HttpResponseData> ListarReporte1([HttpTrigger(AuthorizationLevel.Function, "get", Route = "ListarReporte1")] HttpRequestData req)
        {

            try
            {
                var listaIdiomas = pedidoLogic.ListarReporte1();
                var respuesta = req.CreateResponse(HttpStatusCode.OK);
                await respuesta.WriteAsJsonAsync(listaIdiomas.Result);
                return respuesta;
            }
            catch (Exception e)
            {

                var error = req.CreateResponse(HttpStatusCode.InternalServerError);
                await error.WriteAsJsonAsync(e.Message);
                return error;
            }
        }
        [Function("ListarReporte2")]
        [OpenApiOperation("Listarspec", "ListarReporte2", Description = "Sirve para listar todos los Reporte2")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Reporte2>), Description = "Mostrara una Lista de Pedidos")]
        public async Task<HttpResponseData> ListarReporte2([HttpTrigger(AuthorizationLevel.Function, "get", Route = "ListarReporte2")] HttpRequestData req)
        {

            try
            {
                var listaIdiomas = pedidoLogic.ListarReporte2();
                var respuesta = req.CreateResponse(HttpStatusCode.OK);
                await respuesta.WriteAsJsonAsync(listaIdiomas.Result);
                return respuesta;
            }
            catch (Exception e)
            {

                var error = req.CreateResponse(HttpStatusCode.InternalServerError);
                await error.WriteAsJsonAsync(e.Message);
                return error;
            }
        }

        [Function("ModificarPedido")]
        [OpenApiOperation("Modificarspec", "ModificarIdioma", Description = "Sirve para Modificar un Pedido")]
        [OpenApiRequestBody("application/json", typeof(PedidoDetalleActualizar), Description = "Pedido modelo")]
        [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(int))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(PedidoDetalleActualizar), Description = "Mostrara el Pedido Modificado")]
        public async Task<HttpResponseData> ModificarPedido([HttpTrigger(AuthorizationLevel.Function, "put", Route = "ModificarPedido/{id}")] HttpRequestData req, int id)
        {

            try
            {
                var pedido = await req.ReadFromJsonAsync<PedidoDetalleActualizar>() ?? throw new Exception("Debe ingresar un Pedido con todos sus datos");
                bool seModifico = await pedidoLogic.ModificarPedido(pedido, id);
                if (seModifico)
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
