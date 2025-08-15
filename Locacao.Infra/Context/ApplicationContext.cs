using Locacao.Domain.Entities;
using Locacao.Infra.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }
        public DbSet<Locadora> Locacoes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {

            model.ApplyConfiguration(new EntregadorMapper());
            model.ApplyConfiguration(new MotoMapper());
            model.ApplyConfiguration(new LocacaoMapper());       




        }


    }
}
