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
    public class EntregadorMapper : IEntityTypeConfiguration<Entregador>
    {

        public void Configure(EntityTypeBuilder<Entregador> entity)
        {
            entity.ToTable("Tb_Entregador");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.HasIndex(x => x.CNPJ).IsUnique();
            entity.Property(x => x.CNPJ).HasMaxLength(14);
            entity.Property(x => x.Nome).HasMaxLength(150);
            entity.Property(x => x.NumeroCNH).HasMaxLength(30);
            entity.Property(x => x.TipoCNH).HasMaxLength(30);



        }


    }
}
