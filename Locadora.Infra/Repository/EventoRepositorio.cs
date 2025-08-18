using Locadora.Domain.Entities;
using Locadora.Domain.Interfaces.Repository;
using Locadora.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Repository
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public EventoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Insert(Eventos payload)
        {
           await _context.Eventos.AddAsync(payload);
            await _context.SaveChangesAsync();
        }
    }
}
