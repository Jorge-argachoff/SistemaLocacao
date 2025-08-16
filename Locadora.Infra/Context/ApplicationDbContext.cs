using Locadora.Domain.Entities;
using Locadora.Infra.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new EntregadorMapper());
            modelBuilder.ApplyConfiguration(new MotoMapper());
            modelBuilder.ApplyConfiguration(new LocacaoMapper());       




        }


    }
}
