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
    public class EntregadorMapper : IEntityTypeConfiguration<Entregador>
    {

        public void Configure(EntityTypeBuilder<Entregador> builder)
        {



            builder.Property(x => x.Id).ValueGeneratedOnAdd();

        }


    }
}
