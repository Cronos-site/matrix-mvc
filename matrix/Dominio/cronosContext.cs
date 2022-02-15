using matrix.Models.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace matrix.Dominio
{
    public class cronosContext : IdentityDbContext<Pessoa>
    {
        IConfiguration _configuration;
        public cronosContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public cronosContext(DbContextOptions<cronosContext> options)
        //    : base(options)
        //{
        //}



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection = _configuration.GetSection("ConnectionStrings").GetSection("default").Value;
                optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
            }
        }

        public virtual DbSet<Postagem> Postages { get; set; } = null;
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<Servicos> Servicos { get; set; }


    }
}
