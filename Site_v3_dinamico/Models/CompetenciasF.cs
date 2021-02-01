using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class CompetenciasF
    {
        public int CompetenciasFId { get; set; }

        [Display(Name = "Nome da ferramenta")]
        [Required(ErrorMessage = "Insira o nome da ferramenta.")]
        public string nomeComp { get; set; }

        [Display(Name = "Nível de domínio da ferramenta. (1-100)")]
        [Required(ErrorMessage = "Insira o nível de domínio da ferramenta.")]
        [Range(1, 100, ErrorMessage = "Insira um número de 1 a 100.")]
        public int nivelComp { get; set; }

        [Display(Name = "Logótipo da ferramenta")]
        public byte[] logo { get; set; }
    }
}
