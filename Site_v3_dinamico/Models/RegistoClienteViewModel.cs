﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class RegistoClienteViewModel
    {
        [Required]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telefone Inválido")]
        [StringLength(9, MinimumLength = 9)]
        public string Telemóvel { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(256)]
        [Compare("Password", ErrorMessage = "Palavra-passe não coincidente")]
        [Display(Name = "Confirme a password")]
        [DataType(DataType.Password)]
        public string ConfirmePassword { get; set; }
    }
}
