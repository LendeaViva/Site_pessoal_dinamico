using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Formacao
    {
        public int Id { get; set; }
        public string nomeInstituicao { get; set; }

       
        public string dataIniciodataFim { get; set; }
        public string nomeCurso { get; set; }
        public string conteudosCurso { get; set; }
    }
}
