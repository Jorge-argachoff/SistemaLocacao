using Locadora.Domain.Models;
using LocacaoMotoConsumer;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // L� a se��o do appsettings.json e registra como IOptions<MinhaConfig>
        services.Configure<RabbitMQConfig>(context.Configuration.GetSection("RabbitMQ"));

        // Registra o worker
        services.AddHostedService<Worker>();
    }).Build();

host.Run();
