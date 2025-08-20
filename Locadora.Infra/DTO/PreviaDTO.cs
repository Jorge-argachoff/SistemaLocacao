using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.DTO
{
    public class PreviaDTO
    {
        public decimal ValorDiaria { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataSolicitacao { get; set; }
    }
}
