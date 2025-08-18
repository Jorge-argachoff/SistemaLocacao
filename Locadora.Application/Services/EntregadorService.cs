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
    public class EntregadorService : IEntregadorService
    {
        private readonly IEntregadorRepository _entregadorRepository;

        public EntregadorService(IEntregadorRepository entregadorRepository)
        {
            _entregadorRepository = entregadorRepository;
        }
        public async Task Create(Entregador entregador)
        {
            await _entregadorRepository.Add(entregador);
        }

        public async Task Delete(long id)
        {
            await _entregadorRepository.Delete(id);
        }

        public async Task<IEnumerable<Entregador>> GetAll()
        {
            return await _entregadorRepository.GetAll();
        }

        public async Task<Entregador> GetById(long id)
        {
            return await _entregadorRepository.GetById(id);
        }
    }
}
