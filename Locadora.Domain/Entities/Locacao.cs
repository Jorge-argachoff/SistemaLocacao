using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Locadora.Domain.Entities
{
    public class Locacao : EntidadeBase
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
        public decimal ValorTotal { get; set; }

        [JsonIgnore]
        public virtual Entregador Entregador { get; set; }

        public long EntregadorId { get; set; }
        [JsonIgnore]
        public virtual Moto Moto { get; set; }

        public long PlanoId { get; set; } // Chave estrangeira

        [JsonIgnore]
        public Plano Plano { get; set; }

        public long MotoId { get; set; }

        public dynamic CalcularValor()
        {

            TimeSpan diferenca =  DataTermino.Value - DataInicio;
            TimeSpan diferencaPrevisao =   DataPrevisaoTermino - DataTermino.Value;
            decimal valorTotal = 0;
            decimal valorDiarias = 0;
            decimal valorMultaDiarias = 0;

            if (PrevisaoCorreta())
            {
                valorTotal = diferenca.Days * Plano.ValorDia;
            }
            else
            {
                switch (Plano.Id)
                {
                    case (long)PlanosEnum.Plano7:
                        valorDiarias = diferenca.Days * Plano.ValorDia;
                        valorMultaDiarias = ((Plano.ValorDia * 20) / 100);
                        valorTotal = valorDiarias + (valorMultaDiarias * diferencaPrevisao.Days);
                        break;
                    case (long)PlanosEnum.Plano15:
                        valorDiarias = diferenca.Days * Plano.ValorDia;
                        valorMultaDiarias = (diferencaPrevisao.Days * 40) / 100;
                        valorTotal = valorDiarias + valorMultaDiarias;                        
                        break;
                    default:
                        valorTotal = diferenca.Days * Plano.ValorDia;
                        valorTotal += 50;
                        break;
                }

            }
            return new {ValorTotal = valorTotal,ValorMultaPorDiaria = valorMultaDiarias, ValorDiarias = valorDiarias};
             

        }

        public bool PrevisaoCorreta() => DataTermino.Value.Day == DataPrevisaoTermino.Day;
    }
}
