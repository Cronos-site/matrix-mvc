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
                optionsBuilder.UseMySql("server=mysqlserver.cmkbevv79elb.us-east-2.rds.amazonaws.com;database=agenciacronos;user id=admin;password=47616d610d0a2202osruc", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        public DbSet<matrix.Models.Entidades.Equipe> Equipe { get; set; }

        public DbSet<matrix.Models.Entidades.Servicos> Servicos { get; set; }
    }
}
