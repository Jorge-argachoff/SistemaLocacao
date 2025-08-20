using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Repository;
using Locadora.Domain.Interfaces.Service;
using Locadora.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repository
{
    public class MotoRepository : IMotoRepository
    {

        private readonly ApplicationDbContext _context;

        public MotoRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task Add(Moto entity)
        {
            _context.Motos.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto != null)
            {
                _context.Motos.Remove(moto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Moto>> GetAll()
        {
            
              var motos =   await _context.Motos.ToListAsync();
            return motos;
        }

    

        public async Task<Moto> GetById(long id)
        {
            return await _context.Motos.FindAsync(id);
        }

        public async Task<IEnumerable<Moto>> GetByPlaca(string placa)
        {
            return await _context.Motos.Where(x=>x.Placa.Contains(placa)).ToListAsync();
        }

        

        public async Task Update(Moto entity)
        {
            _context.Motos.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlacaMoto(long motoId, string placa)
        {
            await _context.Set<Moto>().Where(e => e.Id == motoId)
                                .ExecuteUpdateAsync(s => s.SetProperty(e => e.Placa, placa));
        }


    }
}
