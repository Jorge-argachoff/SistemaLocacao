using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repository;
using Locacao.Domain.Interfaces.Service;
using Locacao.Infra.DTO;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Locacao.Application.Services
{
    public class MotoService:IMotoService
    {
        private readonly IMotoRepository motoRepository;
        public ConnectionFactory Factory { get;  set; }
        IConnection connection;
        IChannel channel;
        public MotoService(IMotoRepository motoRepository)
        {
            this.motoRepository = motoRepository;

            Factory = new ConnectionFactory { HostName = "localhost"};
            connection = Factory.CreateConnectionAsync().Result;
            channel = connection.CreateChannelAsync().Result;
        }

        public async Task CreateMoto(string ano, string modelo, string placa)
        {
            var moto =  new Moto(ano, modelo, placa);
            

           await Task.WhenAll(
                this.motoRepository.Add(moto),
                PublishMessage(ano)

                );
        }

        public Task DeleteMoto()
        {
            throw new NotImplementedException();
        }

        public Task<List<Moto>> GetAllMotos()
        {
            throw new NotImplementedException();
        }

        public Task<Moto> GetMotos()
        {
            throw new NotImplementedException();
        }

        public Task UpdateMoto()
        {
            throw new NotImplementedException();
        }

        private async Task PublishMessage(string ano)
        {
            await channel.QueueDeclareAsync(queue: "moto-ano", durable: false, exclusive: false, autoDelete: false,
                                                arguments: null);
            var json = JsonSerializer.Serialize(ano);
            var body = Encoding.UTF8.GetBytes(json);
            await channel.BasicPublishAsync(exchange: "logs", routingKey: string.Empty, body: body);
        }
    }
}
