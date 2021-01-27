using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Servicos
    {
        public int ServicosId { get; set; }

        [Required(ErrorMessage = "Deve preencher o nome.")]
        [StringLength(200, MinimumLength = 4, ErrorMessage = "O nome deve ter pelo menos 4 caracteres e não deve exceder os 200 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }



    }
}
