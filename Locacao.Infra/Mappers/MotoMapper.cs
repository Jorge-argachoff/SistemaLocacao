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
    public class MotoMapper : IEntityTypeConfiguration<Moto>
    {

        public void Configure(EntityTypeBuilder<Moto> builder)
        {

           

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

        }


    }
   
}
