using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Service
{
    public interface IMotoService
    {
        Task CreateMoto(string Ano, string modelo,string placa);
        Task DeleteMoto(long id);
        Task UpdatePlacaMoto(long id, string placa);
        Task<Moto> GetMotoByPlaca(string placa);
        Task<IEnumerable<Moto>> GetAllMotos();
    }
}
