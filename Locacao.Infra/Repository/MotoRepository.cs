using Locacao.Domain.Entities;
using Locacao.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Infra.Repository
{
    public class MotoRepository : IMotoRepository
    {
        public async Task Add(Moto entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Moto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Moto> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Moto entity)
        {
            throw new NotImplementedException();
        }
    }
}
