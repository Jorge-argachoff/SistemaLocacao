using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Repository;
using Locadora.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Locadora.Application.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly ILocacaoRepository _locacaoRepository;

        public LocacaoService(ILocacaoRepository locacaoRepository)
        {
            _locacaoRepository = locacaoRepository;
        }
        public async Task Create(Locacao locacao)
        {

            await _locacaoRepository.CreateLocacao(locacao);
        }

        public Task<decimal> FinishFinishLocacao(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> FinishLocacao(long id)
        {
            await _locacaoRepository.AtualizarLocacao(id);

            var locacao = await _locacaoRepository.GetById(id);

            var previa = locacao.CalcularValor();

            return JsonSerializer.Serialize(previa);
        }

        public async Task<string> GetLocacao(long id)
        {
            var locacao = await _locacaoRepository.GetById(id);

            if (locacao is not null)
                locacao.DataTermino = DateTime.UtcNow;

            var previa = locacao.CalcularValor();

            return JsonSerializer.Serialize(previa);
        }


    }
}
