using Microsoft.EntityFrameworkCore;
using SisDoBem.Models;

namespace SisDoBem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Donatario> Donatario { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Saida> Saida { get; set; }
        public DbSet<Doador> Doador { get; set; }
        public DbSet<Estoque> Estoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estoque>().Property(e => e.categoria).HasConversion<string>();

        }

    }
}