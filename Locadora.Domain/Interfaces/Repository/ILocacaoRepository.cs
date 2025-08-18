using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Repository
{
    public interface ILocacaoRepository
    {
        Task CreateLocacao(Locacao locacao);
        Task AtualizarLocacao(long id);
        Task<Locacao> GetById(long id);
    }
}
