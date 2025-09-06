using Locadora.Domain.Models;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace WorkerMotoConsumerOutrosAnos
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
       
        private IConnection _connection;
        private IChannel _channel;
        private JsonSerializerOptions jsonOptions;
        private readonly RabbitMQConfig _config;
       


        public Worker(ILogger<Worker> logger, IOptions<RabbitMQConfig> config, IConfiguration configuration)
        {
            _config = config.Value;
            
            _logger = logger;          
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            await InitializeRabbitMQ();

            consumer.ReceivedAsync += async (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    _logger.LogInformation($"Mensagem recebida: {message}");

                  Console.WriteLine($"mensagem :{message}");

                    await _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                    _logger.LogInformation("Mensagem ACK");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar mensagem");

                    // NACK permite reenviar ou descartar
                    await _channel.BasicNackAsync(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                    _logger.LogWarning("Mensagem NACK - será reenviada");
                }

            };

            await _channel.BasicConsumeAsync(queue: _config.QueueName,
                                  autoAck: false, // use false se quiser controle manual
                                  consumer: consumer);

        }

        public override void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            base.Dispose();
        }

        private async Task InitializeRabbitMQ()
        {

            var factory = new ConnectionFactory()
            {
                HostName = _config.Host,
                UserName = _config.User,
                Password = _config.Password
            };

            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            await _channel.QueueDeclareAsync(queue: _config.QueueName, durable: false, exclusive: false, autoDelete: false);

            await _channel.ExchangeDeclareAsync(exchange: _config.ExchangeName, type: ExchangeType.Topic);

            await _channel.QueueBindAsync(queue: _config.QueueName, exchange: _config.ExchangeName, routingKey: $"ano.*");

            _logger.LogInformation("Conectado ao RabbitMQ e aguardando mensagens...");
        }
    }
}
