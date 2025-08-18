using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Repository;
using Locadora.Domain.Interfaces.Service;
using Locadora.Domain.Models;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Locadora.Application.Services
{
    public class MotoService : IMotoService
    {
        private readonly IMotoRepository _motoRepository;
        public ConnectionFactory Factory { get; set; }
        IConnection connection;
        IChannel channel;
        private readonly RabbitMQConfig _config;
        public MotoService(IMotoRepository motoRepository, IOptions<RabbitMQConfig> config)
        {
            _motoRepository = motoRepository;
            _config = config.Value;

            Factory = new ConnectionFactory { HostName = "localhost" };
            connection = Factory.CreateConnectionAsync().Result;
            channel = connection.CreateChannelAsync().Result;
        }

        public async Task CreateMoto(Moto moto)
        {
            await _motoRepository.Add(moto);

            await PublishMessage(moto);
            //await Task.WhenAll(
            //     _motoRepository.Add(moto),
            //     PublishMessage(moto));
        }

        public async Task DeleteMoto(long id)
        {
            await _motoRepository.Delete(id);
        }

       
        public async Task UpdatePlacaMoto(long id, string novaPlaca)
        {
            await _motoRepository.UpdatePlacaMoto(id, novaPlaca);
        }
        public async Task<IEnumerable<Moto>> GetAllMotos(string placa)
        {   
            if(string.IsNullOrEmpty(placa))
                return await _motoRepository.GetAll();

            return await _motoRepository.GetByPlaca(placa);
        }

        public async Task<IEnumerable<Moto>> GetMotoByPlaca(string placa)
        {
            return await _motoRepository.GetByPlaca(placa);
        }


        public async Task<Moto> GetMotoById(long id)
        {
            return await _motoRepository.GetById(id);
        }


        private async Task PublishMessage(Moto moto)
        {
            await channel.ExchangeDeclareAsync(exchange: _config.ExchangeName, type: ExchangeType.Direct);
            var json = JsonSerializer.Serialize(moto);
            var body = Encoding.UTF8.GetBytes(json);
            await channel.BasicPublishAsync(exchange: _config.ExchangeName, routingKey: moto.Ano, body: body);
        }


    }
}
