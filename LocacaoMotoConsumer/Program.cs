using LocacaoMotoConsumer;
using Locadora.Domain.Interfaces.Repository;
using Locadora.Domain.Models;
using Locadora.Infra.Repository;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Lê a seção do appsettings.json e registra como IOptions<MinhaConfig>
        services.Configure<RabbitMQConfig>(context.Configuration.GetSection("RabbitMQ"));
        services.AddSingleton<IEventoRepositorio, EventoRepositorio>();
        // Registra o worker
        services.AddHostedService<Worker>();
    }).Build();

host.Run();
