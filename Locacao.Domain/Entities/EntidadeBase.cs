using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Entities
{
    public class EntidadeBase
    {
        public long Id { get; set; }

        public DateTime DataCadastro { get; set; }

    }
}
