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
    public class LocacaoMapper : IEntityTypeConfiguration<Locacao>
    {

        public void Configure(EntityTypeBuilder<Locacao> entity)
        {
            entity.ToTable("Tb_Locacao");
            entity.Property(x => x.Id).ValueGeneratedOnAdd();

            entity.Property(x => x.DataTermino).IsRequired(false);



            entity.HasOne(X => X.Moto).WithOne(x => x.Locacao).HasForeignKey<Locacao>(f=>f.MotoId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(X => X.Entregador).WithOne(x => x.Locacao).HasForeignKey<Locacao>(f=> f.EntregadorId).OnDelete(DeleteBehavior.Restrict);

            

        }


    }
}
