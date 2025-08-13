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
        Task DeleteMoto();
        Task UpdateMoto();
        Task<Moto> GetMotos();
        Task<List<Moto>> GetAllMotos();
    }
}
