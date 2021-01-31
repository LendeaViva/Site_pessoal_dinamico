using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class FormacaoViewModel
    {
        public List<Formacao> Formacao { get; set; }

        public List<FormacaoComp> FormacaoComp { get; set; }
    }
}
