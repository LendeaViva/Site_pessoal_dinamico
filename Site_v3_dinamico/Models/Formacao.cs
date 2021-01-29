using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Formacao
    {
        public int FormacaoId { get; set; }

        [Required(ErrorMessage = "Insira o nome da instituição de ensino/entidade formadora.")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "O nome deve ter pelo menos 4 caracteres e não deve exceder os 200 caracteres.")]
        [Display(Name = "Nome da instituição de ensino/entidade formadora")]
        public string nomeInstituicao { get; set; }

        [Display(Name = "Website da instituição de ensino/entidade formadora")]
        public string website { get; set; }

        [Display(Name = "Logótipo da instituição de ensino/entidade formadora")]
        public byte[] logotipoForm { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de início da formação")]
        public DateTime dataInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de conclusão da formação")]
        public DateTime dataFim { get; set; }

        [Required(ErrorMessage = "Insira o nome da da formação/curso.")]
        [Display(Name = "Nome da formação/curso")]
        public string nomeCurso { get; set; }

        [Display(Name = "Descrição dos conteúdos lecionados")]
        public string conteudos { get; set; }



    }
}
