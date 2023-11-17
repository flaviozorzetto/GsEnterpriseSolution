using GsEnterpriseSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GsEnterpriseSolution.Contexts
{
    public class PlataformaContext : DbContext
    {
        public DbSet<Login> Logins { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public PlataformaContext(DbContextOptions op) : base(op) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
