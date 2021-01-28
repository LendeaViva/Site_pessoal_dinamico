using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class Encomenda
    {
        public int EncomendaId { get; set; }

        public DateTime dataEncomenda { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente{ get; set; }

        [Display(Name = "Serviço")]
        public int ServicosId { get; set; }
        public Servicos Servicos { get; set; }



    }
}
