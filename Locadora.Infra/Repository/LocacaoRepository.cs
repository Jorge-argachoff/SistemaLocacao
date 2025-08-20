using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Repository;
using Locadora.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repository
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public LocacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AtualizarLocacao(long id)
        {
            await _context.Set<Locacao>().Where(e => e.Id == id)
                               .ExecuteUpdateAsync(s => s.SetProperty(e => e.DataTermino, DateTime.UtcNow ));
        }

        public async Task CreateLocacao(Locacao entity)
        {
            _context.Locacoes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Locacao> GetById(long id)
        {
            return await _context.Locacoes.Include(p=>p.Plano).FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
