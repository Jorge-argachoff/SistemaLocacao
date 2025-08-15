using Locacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces.Repository
{
    public interface IMotoRepository:IRepository<Moto,long>
    {
        public Task UpdatePlacaMoto(long motoId,string placa);

        public Task<Moto> GetByPlaca(string placa);
    }
}
