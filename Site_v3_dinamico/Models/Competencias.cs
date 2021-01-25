using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Competencias
    {
        public int CompetenciasId { get; set; }

        public string nomeComp { get; set; }

        public string descricaoComp { get; set; }

        public string nomeLinguagem { get; set; }
        public int nivelComp { get; set; }

    }
}
