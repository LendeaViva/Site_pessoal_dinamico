using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class SobreMim
    {
        public int SobreMimId { get; set; }

        [Display(Name = "Breve descrição sobre mim")]
        [StringLength(5000)]
        public string descricao { get; set; }
    }
}
