using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required (ErrorMessage = "Por favor introduza o seu nome.")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required (ErrorMessage = "Por favor introduza o seu contacto de telemóvel.")]
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telemóvel Inválido")]
        [StringLength(9, MinimumLength = 9)]
        public string Telemóvel { get; set; }

        [Required(ErrorMessage = "Por favor introduza o seu e-mail.")]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        public ICollection<Encomenda> Encomenda { get; set; }


    }
}
