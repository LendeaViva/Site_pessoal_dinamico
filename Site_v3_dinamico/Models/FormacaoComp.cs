using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class FormacaoComp
    {

      
        public int FormacaoCompId { get; set; }

        [Required(ErrorMessage = "Insira o nome da instituição de ensino/entidade formadora.")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "O nome deve ter pelo menos 4 caracteres e não deve exceder os 200 caracteres.")]
        [Display(Name = "Nome da instituição de ensino/entidade formadora")]
        public string nomeInstituicaoComp { get; set; }

        [Display(Name = "Data de conclusão da formação")]
        public DateTime dataIniciodataFimComp { get; set; }

        [Required(ErrorMessage = "Insira o nome da da formação/curso.")]
        [Display(Name = "Nome da formação/curso")]
        public string nomeCursoComp { get; set; }
    }
}
