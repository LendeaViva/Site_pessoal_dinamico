using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class CompetenciasP
    {
        public int CompetenciasPId { get; set; }

        [Display(Name = "Nome da Competência")]
        [Required(ErrorMessage = "Insira o nome da competência.")]
        public string nomeComp { get; set; }

        [Display(Name = "Descrição da Competência")]
        [Required(ErrorMessage = "Insira a descrição da competência.")]
        [StringLength(130, ErrorMessage = "A descrição não pode exceder 130 caracteres")]
        public string descricaoComp { get; set; }



    }
}
