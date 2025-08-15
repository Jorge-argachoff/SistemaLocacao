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
    public class MotoMapper : IEntityTypeConfiguration<Moto>
    {

        public void Configure(EntityTypeBuilder<Moto> entity)
        {

            entity.Property(x => x.Id).ValueGeneratedOnAdd();
            entity.HasIndex(x => x.Placa).IsUnique();
            entity.Property(x => x.Placa).HasMaxLength(8);
            entity.Property(x => x.Modelo).HasMaxLength(100);
            entity.Property(x => x.Ano).HasMaxLength(4);            

        }


    }
   
}
