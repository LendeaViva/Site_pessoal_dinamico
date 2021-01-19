using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Site_v3_dinamico.Models;

namespace Formacao1.Data
{
    public class FormacaoBdContext : DbContext
    {
        public FormacaoBdContext(DbContextOptions<FormacaoBdContext> options)
            : base(options)
        {
        }

        public DbSet<Site_v3_dinamico.Models.Formacao> Formacao { get; set; }
    }
}
