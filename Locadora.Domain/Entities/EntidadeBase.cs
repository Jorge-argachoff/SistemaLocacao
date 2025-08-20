using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Locadora.Domain.Entities
{
    public class EntidadeBase
    {

        [JsonIgnore]
        public long Id { get; set; }
        [JsonIgnore]
        public DateTime DataCadastro { get { return DateTime.UtcNow; } set { } }

    }
}
