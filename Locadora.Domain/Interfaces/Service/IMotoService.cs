using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Service
{
    public interface IMotoService
    {
        Task CreateMoto(Moto moto);
        Task DeleteMoto(long id);
        Task UpdatePlacaMoto(long id, string placa);
        Task<IEnumerable<Moto>> GetAllMotos();
        Task<Moto> GetMotoByPlaca(string placa);
        Task<Moto> GetMotoById(long id);
        
    }
}
