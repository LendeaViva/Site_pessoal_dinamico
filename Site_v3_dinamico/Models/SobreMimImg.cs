using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class SobreMimImg
    {
        public int SobreMimImgId { get; set; }

        [Required]
        [Display(Name = "Imagem ilustrativa")]
        public byte[] imagem { get; set; }
    }
}
