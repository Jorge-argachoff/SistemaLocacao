using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Repository;
using Locadora.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<decimal> Devolucao(long id)
        {
            await _locacaoRepository.AtualizarLocacao(id);

            var locacao = await _locacaoRepository.GetById(id);

            return locacao.CalcularValor();


        }
    }
}
