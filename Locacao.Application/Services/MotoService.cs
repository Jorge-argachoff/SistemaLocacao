using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repository;
using Locacao.Domain.Interfaces.Service;
using Locacao.Infra.DTO;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Locacao.Application.Services
{
    public class MotoService : IMotoService
    {
        private readonly IMotoRepository _motoRepository;
        public ConnectionFactory Factory { get; set; }
        IConnection connection;
        IChannel channel;
        public MotoService(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;

            Factory = new ConnectionFactory { HostName = "localhost" };
            connection = Factory.CreateConnectionAsync().Result;
            channel = connection.CreateChannelAsync().Result;
        }

        public async Task CreateMoto(string ano, string modelo, string placa)
        {            
            var moto = new Moto(ano, modelo, placa);

            await Task.WhenAll(
                 _motoRepository.Add(moto),
                 PublishMessage(ano));
        }

        public async Task DeleteMoto(long id)
        {
            await _motoRepository.Delete(id);
        }

        public async Task<IEnumerable<Moto>> GetAllMotos()
        {
            return await _motoRepository.GetAll();
        }

        public async Task<Moto> GetMotoByPlaca(string placa)
        {
            return await _motoRepository.GetByPlaca(placa);
        }

        public async Task UpdatePlacaMoto(long id,string novaPlaca)
        {      
           await _motoRepository.UpdatePlacaMoto(id,novaPlaca);              
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
