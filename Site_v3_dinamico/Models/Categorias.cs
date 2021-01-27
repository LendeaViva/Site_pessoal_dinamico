using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Categorias
    {
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Categoria")]
        public string Nome { get; set; }

        public ICollection<Servicos> Servicos { get; set; }
    }
}
