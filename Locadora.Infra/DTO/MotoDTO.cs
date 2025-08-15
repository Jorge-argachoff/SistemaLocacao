using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.DTO
{
    public class MotoDTO:DTOBase
    {
        public string Ano { get; set; }

        public string Modelo { get; set; }

        public string Placa { get; set; }
    }
}
