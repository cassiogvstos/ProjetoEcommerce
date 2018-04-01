using DesceUmaGeralada.Models;
using Microsoft.EntityFrameworkCore;

namespace DesceUmaGeralada.Dados
{
    public class BeerContext : DbContext
    {
        //internal object notas;

        public BeerContext(DbContextOptions<BeerContext> options) : base(options)
        {
        }

        public DbSet<NotaFiscal> NotasFiscais { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaFiscal>().ToTable("NotaFiscal");
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
        }
    }
}
