using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Service
{
    public interface ILocacaoService
    {
        Task Create(Locacao moto);
        Task<string> FinishLocacao(long id);
        Task<string> GetLocacao(long id);
       
        
    }
}
