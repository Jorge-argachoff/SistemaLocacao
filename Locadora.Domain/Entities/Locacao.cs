using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Locadora.Domain.Entities
{
    public class Locacao:EntidadeBase
    {
        public Locacao()
        {
              DataInicio = DateTime.UtcNow.AddDays(1);
        }

        [JsonIgnore]
        public DateTime DataInicio { get; set; }
        [JsonIgnore]
        public DateTime? DataTermino { get; set; }

        public DateTime DataPrevisaoTermino { get; set; }

        [JsonIgnore]
        public virtual Entregador Entregador { get;set; }
        
        public long EntregadorId { get; set; }
        [JsonIgnore]
        public virtual Moto Moto { get;set; }

        public long PlanoId { get; set; } // Chave estrangeira
        
        [JsonIgnore]
        public Plano Plano { get; set; }

        public long MotoId { get; set; }

        public decimal CalcularValor()
        {

            TimeSpan diferenca = DataInicio - DataTermino.Value;
            decimal valor = 0;
           
                // <= 7:
                //    valor = diferenca.Days * 30;
                //case <= 15:
                //    return diferenca.Days * 28;
                //case <= 30:
                //    return diferenca.Days * 22;
                //case <= 45:
                //    return diferenca.Days * 20;
                //case <= 50:
                //    return diferenca.Days * 18;

                //default:
                    return 0;
            
           
        }
    }
}
