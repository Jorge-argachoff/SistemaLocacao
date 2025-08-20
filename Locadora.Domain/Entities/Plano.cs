using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Locadora.Domain.Entities
{
    public class Plano
    {
        public long Id { get; set; }
        public int Dias { get; set; }
        public decimal ValorDia { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<Locacao> Locacoes { get; set; }

    }
}
