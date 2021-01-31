using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class CompetenciasF
    {
        public int CompetenciasFId { get; set; }

        public string nomeComp { get; set; }

        public int nivelComp { get; set; }

        public byte[] logo { get; set; }
    }
}
