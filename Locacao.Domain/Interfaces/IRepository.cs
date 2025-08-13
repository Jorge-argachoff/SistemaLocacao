using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Interfaces
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        Task<TEntity> GetById(TPrimaryKey id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TPrimaryKey id);
    }

   
}
