using Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Mappers
{
    public class PlanosMapper : IEntityTypeConfiguration<Plano>
    {

        public void Configure(EntityTypeBuilder<Plano> entity)
        {
            entity.ToTable("Tb_Plano");
           
            entity.HasKey(p => p.Id);
            entity.HasData(
                new Plano {Id = 1, ValorDia = 30.00m, Dias = 7 , Nome = "Plano 7"},
                new Plano { Id = 2, ValorDia = 28.00m, Dias = 15, Nome = "Plano 15" },
                new Plano { Id = 3, ValorDia = 22.00m, Dias = 30, Nome = "Plano 30" },
                new Plano { Id = 4, ValorDia = 20.00m, Dias = 45, Nome = "Plano 45" },
                new Plano { Id = 5, ValorDia = 18.00m, Dias = 50, Nome = "Plano 50" }
                );

            entity.HasMany(p => p.Locacoes)
            .WithOne(l => l.Plano)
            .HasForeignKey(l => l.PlanoId).OnDelete(DeleteBehavior.Restrict);

        }


    }
}
