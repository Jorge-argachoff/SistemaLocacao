using Locadora.Domain.Models;
using LocacaoMotoConsumer;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Lê a seção do appsettings.json e registra como IOptions<MinhaConfig>
        services.Configure<RabbitMQConfig>(context.Configuration.GetSection("RabbitMQ"));

        // Registra o worker
        services.AddHostedService<Worker>();
    }).Build();

host.Run();
