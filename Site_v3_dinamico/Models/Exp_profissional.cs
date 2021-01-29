using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Exp_Profissional
    {
        public int Exp_ProfissionalId { get; set; }

        [Required(ErrorMessage = "Insira o nome da empresa.")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "O nome deve ter pelo menos 4 caracteres e não deve exceder os 200 caracteres.")]
        [Display(Name = "Nome da empresa")]
        public string nomeEmpresa { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de início")]
        public DateTime dataInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de fim")]
        public DateTime dataFim { get; set; }

        [Required(ErrorMessage = "Insira a função/cargo desempenhado")]
        [Display(Name = "Função/Cargo")]
        public string funcao { get; set; }
       
        [Display(Name = "Descrição da função/cargo")]
        public string descricaoFuncao { get; set; }

        [Display(Name = "Logótipo da empresa")]
        public byte[] logotipo { get; set; }


    }
}
