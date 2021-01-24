using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Site_v3_dinamico.Models;

namespace Site_v3_dinamico.Data
{
    public class SiteDinamicoBdContext : DbContext
    {
        public SiteDinamicoBdContext(DbContextOptions<SiteDinamicoBdContext> options)
            : base(options)
        {
        }

        public DbSet<Site_v3_dinamico.Models.Competencias> Competencias { get; set; }
        public DbSet<Site_v3_dinamico.Models.Exp_profissional> Exp_profissional { get; set; }
        public DbSet<Site_v3_dinamico.Models.Formacao> Formacao { get; set; }

    }
}
