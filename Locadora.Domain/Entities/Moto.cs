using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Locadora.Domain.Entities
{
    public class Moto : EntidadeBase
    {
        public Moto(string ano, string modelo, string placa)
        {
            if (string.IsNullOrEmpty(ano) || ano.Length > 4 )
                throw new ArgumentNullException("ano deve ser preenchido");

            if (string.IsNullOrEmpty(modelo))
                throw new ArgumentNullException("modelo deve ser preenchido");

            if (string.IsNullOrEmpty(placa))
                throw new ArgumentNullException("placa deve ser preenchida");


            Ano = ano;
            Modelo = modelo;
            Placa = placa.ToUpper();
            DataCadastro = DateTime.UtcNow;
        }

        public string Ano { get; private set; }

        public string Modelo { get; private set; }

        public string Placa { get; private set; }

        [JsonIgnore]
        public virtual Locacao Locacao { get; set; }
       

    }
}
