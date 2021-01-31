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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Encomenda>() // Lado N
                .HasOne(p => p.Servicos) // um produto tem uma categoria
                .WithMany(c => c.Encomenda) // que por sua vez tem vários produtos
                .HasForeignKey(p => p.ServicosId) // chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); // não permitir o cascade delete

            modelBuilder.Entity<Encomenda>() // Lado N
                .HasOne(p => p.Cliente) // um produto tem uma categoria
                .WithMany(c => c.Encomenda) // que por sua vez tem vários produtos
                .HasForeignKey(p => p.ClienteId) // chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); // não permitir o cascade delete

        }




        public DbSet<Site_v3_dinamico.Models.Competencias> Competencias { get; set; }
        public DbSet<Site_v3_dinamico.Models.Exp_Profissional> Exp_Profissional { get; set; }
        public DbSet<Site_v3_dinamico.Models.Formacao> Formacao { get; set; }
        public DbSet<Site_v3_dinamico.Models.FormacaoComp> FormacaoComp { get; set; }

        public DbSet<Site_v3_dinamico.Models.Servicos> Servicos { get; set; }

        public DbSet<Site_v3_dinamico.Models.Cliente> Cliente { get; set; }

        public DbSet<Site_v3_dinamico.Models.Encomenda> Encomenda { get; set; }

        public DbSet<Site_v3_dinamico.Models.SobreMim> SobreMim { get; set; }

        public DbSet<Site_v3_dinamico.Models.SobreMimImg> SobreMimImg { get; set; }

        //The preceding code creates a DbSet<Formacao> property for the entity set. 
        //In Entity Framework terminology, an entity set typically corresponds to 
        //a database table. An entity corresponds to a row in the table.

    }
}
