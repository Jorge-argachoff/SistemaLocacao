using Locacao.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Infra.Mappers
{
    public class LocacaoMapper : IEntityTypeConfiguration<Locadora>
    {

        public void Configure(EntityTypeBuilder<Locadora> builder)
        {



            builder.Property(x => x.Id).ValueGeneratedOnAdd();

        }


    }
}
