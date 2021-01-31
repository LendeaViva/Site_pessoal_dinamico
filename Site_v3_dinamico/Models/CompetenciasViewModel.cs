using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class CompetenciasViewModel
    {
        public List<CompetenciasD> CompetenciasD { get; set; }
        public List<CompetenciasF> CompetenciasF { get; set; }
        public List<CompetenciasP> CompetenciasP { get; set; }
    }
}
