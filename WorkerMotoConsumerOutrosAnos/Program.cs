using Locadora.Domain.Models;
using WorkerMotoConsumerOutrosAnos;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.Configure<RabbitMQConfig>(builder.Configuration.GetSection("RabbitMQ"));


var host = builder.Build();
host.Run();
