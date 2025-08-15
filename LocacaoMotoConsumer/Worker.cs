using Locacao.Domain.Entities;
using Locacao.Domain.Models;
using Locacao.Infra.DTO;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data.Common;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;

namespace LocacaoMotoConsumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConnection _connection;
        private IChannel _channel;
        private JsonSerializerOptions jsonOptions;
        private readonly RabbitMQConfig _config;

        public Worker(ILogger<Worker> logger, IOptions<RabbitMQConfig> config)
        {
            _config = config.Value;
            _logger = logger;
            InitializeRabbitMQ();
            
        }


        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    _logger.LogInformation($"Mensagem recebida: {message}");

                    MotoDTO moto = JsonSerializer.Deserialize<MotoDTO>(message);

                    if (moto.Ano.Equals("2024"))
                    {
                        //TODO salvar evento
                    }

                    _channel.BasicAckAsync(deliveryTag: ea.DeliveryTag, multiple: false);
                    _logger.LogInformation("Mensagem ACK");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao processar mensagem");

                    // NACK permite reenviar ou descartar
                     _channel.BasicNackAsync(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                    _logger.LogWarning("Mensagem NACK - será reenviada");
                }

                return Task.CompletedTask;
            };

            _channel.BasicConsumeAsync(queue: _config.QueueName,
                                  autoAck: false, // use false se quiser controle manual
                                  consumer: consumer);

            return Task.CompletedTask;            
        }

        public override void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            base.Dispose();
        }

        private void InitializeRabbitMQ()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _config.Host,
                UserName = _config.User,
                Password = _config.Password
            };

            _connection = factory.CreateConnectionAsync().Result;
            _channel = _connection.CreateChannelAsync().Result;

            _channel.QueueDeclareAsync(queue: _config.QueueName,
                                  durable: true,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

            _logger.LogInformation("Conectado ao RabbitMQ e aguardando mensagens...");
        }
    }
}
