using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Formacao
    {
        public int FormacaoId { get; set; }
        public string nomeInstituicao { get; set; }
        public string dataIniciodataFim { get; set; }
        public DateTime dataFim { get; set; }
        public string nomeCurso { get; set; }
        public string conteudos { get; set; }

    }
}
