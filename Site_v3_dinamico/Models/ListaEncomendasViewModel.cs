using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site_v3_dinamico.Models
{
    public class ListaEncomendasViewModel
    {
        public List<Encomenda> Encomenda { get; set; }
        public Paginacao Paginacao { get; set; }
    }
}
