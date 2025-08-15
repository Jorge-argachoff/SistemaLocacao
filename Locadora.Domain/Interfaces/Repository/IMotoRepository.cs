using Locadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces.Repository
{
    public interface IMotoRepository:IRepository<Moto,long>
    {
        public Task UpdatePlacaMoto(long motoId,string placa);

        public Task<Moto> GetByPlaca(string placa);
    }
}
