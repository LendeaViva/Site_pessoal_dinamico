using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class CompetenciasD
    {
        public int CompetenciasDId { get; set; }

        [Display(Name = "Nome da Competência")]
        [Required(ErrorMessage = "Insira o nome da competência.")]
        public string nomeComp { get; set; }

        [Display(Name = "Nível da Competência (1-5)")]
        [Required(ErrorMessage = "Insira o nível da competência.")]
        [Range(1, 5, ErrorMessage = "Insira um número de 1 a 5.")]
        public int nivelComp { get; set; }
    }
}
