using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locacao.Domain.Entities
{
    public class Moto : EntidadeBase
    {
        public string Ano { get; private set; }

        public string Modelo { get; private set; }

        public string Placa { get; private set; }

        public Moto(string ano, string modelo, string placa)
        {
            if (string.IsNullOrEmpty(ano))
                throw new ArgumentNullException("ano deve ser preenchido");

            if (string.IsNullOrEmpty(modelo))
                throw new ArgumentNullException("modelo deve ser preenchido");

            if (string.IsNullOrEmpty(placa))
                throw new ArgumentNullException("placa deve ser preenchida");


            Ano = ano;
            Modelo = modelo;
            Placa = placa;
        }
        

    }
}
