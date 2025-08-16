using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Entities
{
    public class Locacao:EntidadeBase
    {
        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public DateTime DataPrevisaoTermino { get; set; }
    }
}
