using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Site_v3_dinamico.Models;

namespace FormacaoContext.Data
{
    public class FormacaoContext : DbContext
    {
        public FormacaoContext(DbContextOptions<FormacaoContext> options)
            : base(options)
        {
        }

        public DbSet<Formacao> Formacao { get; set; }
    }
}
