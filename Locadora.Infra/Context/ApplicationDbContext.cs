using Locadora.Domain.Entities;
using Locadora.Infra.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Entregador> Entregadores { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new EntregadorMapper());
            modelBuilder.ApplyConfiguration(new MotoMapper());
            modelBuilder.ApplyConfiguration(new LocacaoMapper());       
            modelBuilder.ApplyConfiguration(new PlanosMapper());       
            modelBuilder.ApplyConfiguration(new EventoMapper());       




        }


    }
}
