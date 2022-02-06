using matrix.Models.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace matrix.Dominio
{
    public class cronosContext : IdentityDbContext<Pessoa>
    {
        public cronosContext()
        {
        }

        public cronosContext(DbContextOptions<cronosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Postagem> Postages { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=agenciacronos;user id=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        public DbSet<matrix.Models.Entidades.Equipe> Equipe { get; set; }

        public DbSet<matrix.Models.Entidades.Servicos> Servicos { get; set; }
    }
}
