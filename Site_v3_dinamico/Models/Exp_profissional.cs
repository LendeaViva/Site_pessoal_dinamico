using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Exp_Profissional
    {
        public int Exp_ProfissionalId { get; set; }

        public string nomeEmpresa { get; set; }
        public int dataInicio { get; set; }

        public int dataFim { get; set; }
        public int funcao { get; set; }

        public int descricaoFuncao { get; set; }


    }
}
