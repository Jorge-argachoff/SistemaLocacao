using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Service
{
    public interface IEntregadorService
    {
       
        Task<IEnumerable<Entregador>> GetAll(); 
        Task<Entregador> GetById(long id); 
        Task Create(Entregador entregador);
        Task Delete(long id);
    }
}
