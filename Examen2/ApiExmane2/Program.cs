using ApiExmane2.Context;
using ApiExmane2.Contratos;
using ApiExmane2.Implementacion;
using Examen.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureServices(services =>
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddDbContext<Contexto>(options => options.UseSqlServer(
                     configuration.GetConnectionString("cadenaConexion")));


        services.AddTransient<IClienteLogic, ClienteLogic>();
        services.AddTransient<IPedidoLogic, PedidoLogic>();
        services.AddTransient<IDetalleLogic, DetalleLogic>();
        services.AddTransient<IProductoLogic, ProductoLogic>();


    }).ConfigureFunctionsWebApplication(x =>
    {
    })
    .Build();

host.Run();