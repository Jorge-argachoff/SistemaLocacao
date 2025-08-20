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
    public class EntregadorRepository : IEntregadorRepository
    {
        private readonly ApplicationDbContext _context;

        public EntregadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task Add(Entregador entity)
        {
            _context.Entregadores.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var moto = await _context.Entregadores.FindAsync(id);
            if (moto != null)
            {
                _context.Entregadores.Remove(moto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Entregador>> GetAll()
        {

            var motos = await _context.Entregadores.ToListAsync();
            return motos;
        }



        public async Task<Entregador> GetById(long id)
        {
            return await _context.Entregadores.FindAsync(id);
        }

  


        public async Task Update(Entregador entity)
        {
            _context.Entregadores.Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
