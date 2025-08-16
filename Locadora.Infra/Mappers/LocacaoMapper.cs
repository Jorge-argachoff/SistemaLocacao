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

        public void Configure(EntityTypeBuilder<Locacao> builder)
        {

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

        }


    }
}
