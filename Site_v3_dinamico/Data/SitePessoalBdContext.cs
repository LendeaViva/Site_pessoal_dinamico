using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Site_v3_dinamico.Models;

namespace SitePessoal.Data
{
    public class SitePessoalBdContext : DbContext
    {
        public SitePessoalBdContext(DbContextOptions<SitePessoalBdContext> options)
            : base(options)
        {
        }

        public DbSet<Site_v3_dinamico.Models.SitePessoal> Formacao { get; set; }
        public DbSet<Site_v3_dinamico.Models.SitePessoal> FormacaoComplementar { get; set; }
    }
}
